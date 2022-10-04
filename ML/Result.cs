namespace ML
{
    public class Result
    {

        public string? ErrorMessage { set; get; }

        public Exception? exception { set; get; }

        public bool correct { set; get; }

        public List<object>? Objects { set; get; }

        public object Object { set; get; }

    }
}