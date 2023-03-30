using AutoMapper;
using OrderFood.Data;
using OrderFood.Models;

namespace OrderFood.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FoodByRestaurantModel, FoodByRestaurant>();
            CreateMap<FoodByRestaurant, FoodByRestaurantModel>();

            CreateMap<FoodForUserModel, FoodForUser>();
            CreateMap<FoodForUser, FoodForUserModel>();

            CreateMap<LogModel, Log>();
            CreateMap<Log, LogModel>();

            CreateMap<OrderDetailModel, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailModel>();

            CreateMap<OrderModel, Order>();
            CreateMap<Order, OrderModel>();

            CreateMap<RoleModel, Role>();
            CreateMap<Role, RoleModel>();

            CreateMap<UnitModel, Unit>();
            CreateMap<Unit, UnitModel>();

            CreateMap<UserModel, User>()
                .ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password, "$2y$13$LtV/.ThienHoang@#2023H"))
                ); ;
            CreateMap<User, UserModel>();
        }
    }
}
