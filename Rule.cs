namespace ChainOfResponsibility
{
    public class Rule
    {
        public IRule NextRule { get; set; }
    }
}