using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Rules
{
    public class CheckPlatformRule : Rule, IRule
    {
        public CheckPlatformRule()
        {
            NextRule = new CheckTokenRule();
        }
        public Platform Platform { get; set; }

        public bool Run(RequestModel model)
        {
            if (string.IsNullOrWhiteSpace(model.IMEI))
            {
                NextRule.Platform = Platform.Web;
                return string.IsNullOrWhiteSpace(model.Token);
            }
            else if (!string.IsNullOrWhiteSpace(model.IMEI))
            {
                NextRule.Platform = Platform.Gsm;
                return (model.Token != null && model.Token != String.Empty) || (model.RefreshToken != null && model.RefreshToken != String.Empty);
            }
            return false;
        }
    }
}