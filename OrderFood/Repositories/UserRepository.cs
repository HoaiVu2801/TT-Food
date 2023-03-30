using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderFood.Data;
using OrderFood.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OrderFood.Repositories
{
    public class UserRepository
    {
        private readonly API_OrderFood_Entities _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserRepository(API_OrderFood_Entities context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<TokenModel> LoginAsync(UserModel Model)
        {
            try
            {
                var userLogin = _mapper.Map<User>(Model);

                var user = await _context.Users!.FirstOrDefaultAsync(x => x.UserName == userLogin.UserName);

                if (user == null || user!.Password != userLogin.Password)
                {
                    throw new ApplicationException();
                }

                var token = await GenerateToken(user);

                return token;
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }

        private async Task<TokenModel> GenerateToken(User user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: authClaims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signingCredentials
                );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = GenerateRefreshToken();

            var newRefreshToken = new RefreshToken()
            {
                TokenID = Guid.NewGuid().ToString(),
                Token = refreshToken,
                Jti = token.Id,
                IsUsed = false,
                IsRevoked = false,
                UserID = user.UserID,
                ExpiredAt = DateTime.UtcNow.AddMinutes(30),
                CreatedAt = DateTime.UtcNow
            };

            _context.RefreshTokens!.Add(newRefreshToken);

            await _context.SaveChangesAsync();



            return new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserID = user.UserID,
            };
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new Byte[64];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        public async Task<bool> RegisterAsync(UserModel Model)
        {
            try
            {
                Model.UserID = Guid.NewGuid().ToString();
                var exist = await _context.Users!.AnyAsync(x => x.Email == Model.Email);

                if (exist)
                {
                    throw new ApplicationException();
                }

                var user = _mapper.Map<User>(Model);

                _context.Users!.Add(user);

                await _context.SaveChangesAsync();

                return true;

            }
            catch (ApplicationException ex)
            {
                if (ex.InnerException != null)
                {
                    throw new ApplicationException(ex.InnerException.Message);
                }
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<TokenModel> RefreshToken(TokenModel Model)

        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var jwtValidateParams = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,

                ValidAudience = _configuration["JWT:Audience"],
                ValidIssuer = _configuration["JWT:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),

                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var tokenInVerification = jwtTokenHandler.ValidateToken(Model.AccessToken, jwtValidateParams, out var tokenValidated);

                if (tokenValidated is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (!result)
                    {
                        throw new ApplicationException();
                    }
                }

                var tokenStored = await _context.RefreshTokens!.FirstOrDefaultAsync(x => x.Token == Model.RefreshToken);

                if (tokenStored == null)
                {
                    throw new ApplicationException();
                }
                else if ((bool)tokenStored.IsUsed!)
                {
                    throw new ApplicationException();
                }
                else if ((bool)tokenStored.IsRevoked!)
                {
                    throw new ApplicationException();
                }
                else
                {
                    var Jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;

                    if (tokenStored.Jti != Jti)
                    {
                        throw new ApplicationException();
                    }

                    var tokenExpiredDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)!.Value);

                    var expiredDate = ConvertUnixToDateTime(tokenExpiredDate);

                    if (expiredDate > DateTime.UtcNow)
                    {
                        throw new ApplicationException();
                    }
                    else
                    {
                        tokenStored.IsUsed = true;
                        tokenStored.IsRevoked = true;

                        _context.RefreshTokens!.Update(tokenStored);
                        await _context.SaveChangesAsync();

                        var user = await _context.Users!.FindAsync(tokenStored.UserID);

                        var token = await GenerateToken(user!);

                        return token;
                    }
                }
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        public DateTime ConvertUnixToDateTime(long tokenExpiredDate)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(tokenExpiredDate);

            return dateTimeOffset.UtcDateTime;
        }

        public async Task<bool> LogoutAsync(TokenModel Model)
        {
            var token = await _context.RefreshTokens!.FirstOrDefaultAsync(x => x.Token!.Equals(Model.RefreshToken));

            if (token == null)
            {
                return false;
            }

            token.IsRevoked = true;
            _context.RefreshTokens!.Update(token);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
