using System.Collections.Generic;
using System.Linq;
using Answer.Emailer.Validation;

namespace Answer.Emailer
{
    public class MailResult
    {
        private readonly IList<ValidationError> _errors = new List<ValidationError>();


        public IList<ValidationError> Errors { get { return _errors; } } 

        public bool Success { get { return _errors.Any() == false; } }


        public void AddError(ValidationError error)
        {
            _errors.Add(error);
        }

        public void AddError(string message, string property = "", bool isException = false, bool isInnerException = false)
        {
            _errors.Add(new ValidationError { Property = property, Message = message, IsException = isException, IsInnerException = isInnerException});
        }

        public void Reset()
        {
            _errors.Clear();
        }
    }
}