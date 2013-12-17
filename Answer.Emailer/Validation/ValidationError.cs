namespace Answer.Emailer.Validation
{
    public class ValidationError
    {
        public string Property { get; set; }

        public string Message { get; set; }

        public bool IsException { get; set; }

        public bool IsInnerException { get; set; }
    }
}