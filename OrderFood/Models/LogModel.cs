namespace OrderFood.Models
{
    public class LogModel
    {
        public string? LogID { get; set; }
        public string? Action { get; set; }
        public string? UserID { get; set; }
        public string? Table { get; set; }
        public DateTime? Time { get; set; }
        public string? Status { get; set; }
        public string? Content { get; set; }
    }
}
