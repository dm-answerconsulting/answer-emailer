using System.Collections.Generic;
using System.Linq;

namespace Answer.Emailer.Validation
{
    public class ValidationResult
    {
        private readonly IList<ValidationError> _errors = new List<ValidationError>();


        public IList<ValidationError> Errors { get { return _errors; } }

        public bool IsValid { get { return _errors.Any() == false; } }


        public void AddError(string property, string message)
        {
            _errors.Add(new ValidationError { Property = property, Message = message });
        }

        public void Clear()
        {
            _errors.Clear();
        }
    }
}
