using ChainOfResponsibility.Models;

namespace ChainOfResponsibility
{
    public interface IRule
    {
        public bool Run(RequestModel model);
        public Platform Platform { get; set; }
        public IRule NextRule { get; set; }
    }


}