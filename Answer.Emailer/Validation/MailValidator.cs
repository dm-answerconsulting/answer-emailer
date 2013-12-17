using System.Linq;

namespace Answer.Emailer.Validation
{
    internal class StandardMailValidator : IMailValidator
    {
        private readonly ValidationResult _result = new ValidationResult();

        public ValidationResult ValidateMail(BaseMail mail)
        {
            _result.Clear();

            if (mail == null)
            {
                _result.AddError("", "Mail parameter was null");

                return _result;
            }

            ValidateFrom(mail);
            ValidateTo(mail);
            ValidateCc(mail);
            ValidateBcc(mail);

            return _result;
        }
        
        private void ValidateFrom(BaseMail mail)
        {
            if (string.IsNullOrWhiteSpace(mail.From))
            {
                _result.AddError("From", "From is required.");
            }
        }

        private void ValidateTo(BaseMail mail)
        {
            if (mail.To.Any() == false)
            {
                _result.AddError("To", "At least one To address is required.");
            }
            else if (mail.To.Any(string.IsNullOrWhiteSpace))
            {
                _result.AddError("To", "Empty To address found.");
            }
        }

        private void ValidateCc(BaseMail mail)
        {
            if (mail.Cc.Any() == false)
            {
                return;
            }
            
            if (mail.Cc.Any(string.IsNullOrWhiteSpace))
            {
                _result.AddError("Cc", "Empty Cc address found.");
            }
        }

        private void ValidateBcc(BaseMail mail)
        {
            if (mail.Bcc.Any() == false)
            {
                return;
            }

            if (mail.Bcc.Any(string.IsNullOrWhiteSpace))
            {
                _result.AddError("Bcc", "Invalid Bcc address found.");
            }
        }
    }
}