using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Rules
{
    internal class CheckRefreshToken : Rule, IRule
    {
        public CheckRefreshToken()
        {
            NextRule = null;
        }
        public Platform Platform { get; set; }

        public bool Run(RequestModel model)
        {
            switch (Platform)
            {
                case Platform.Gsm:
                    if ((FakeData.TokenExpireDate.AddHours(2) - model.TokenExpireDate).TotalMinutes < 45)
                    {
                        if (FakeData.RefreshToken == model.RefreshToken)
                        {
                            FakeData.Token = "167948364512";
                            FakeData.RefreshToken = "73468317973648";
                            FakeData.TokenExpireDate = new DateTime();
                        }
                    }
                    break;
                case Platform.Web:
                    if ((FakeData.TokenExpireDate - model.TokenExpireDate).TotalMinutes < 45)
                    {
                        if (FakeData.RefreshToken == model.RefreshToken)
                        {
                            FakeData.Token = "12345678912";
                            FakeData.RefreshToken = "98765432219842";
                            FakeData.TokenExpireDate = new DateTime();
                        }
                    }
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}