namespace ChainOfResponsibility.Models
{
    public class RequestModel
    {
        public int UserID { get; set; }
        public string IMEI { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}