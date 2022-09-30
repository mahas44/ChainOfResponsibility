using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Rules
{
    internal class CheckTokenExpireRule : Rule, IRule
    {
        public CheckTokenExpireRule()
        {
            NextRule = new CheckRefreshToken();
        }
        public Platform Platform { get; set; }

        public bool Run(RequestModel model)
        {
            switch (Platform)
            {
                case Platform.Gsm:
                    NextRule.Platform = Platform.Gsm;
                    return model.TokenExpireDate < FakeData.TokenExpireDate.AddHours(2);
                case Platform.Web:
                    NextRule.Platform = Platform.Web;
                    return model.TokenExpireDate < FakeData.TokenExpireDate;
                default:
                    return false;
            }
        }
    }
}