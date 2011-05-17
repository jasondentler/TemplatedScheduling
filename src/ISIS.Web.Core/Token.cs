namespace ISIS.Web
{
    public class Token
    {
        private readonly string _templatingCode;

        public Token(string templatingCode)
        {
            _templatingCode = templatingCode;
        }

        public override string ToString()
        {
            return _templatingCode;
        }

    }
}
