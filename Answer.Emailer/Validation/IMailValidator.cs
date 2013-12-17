namespace Answer.Emailer.Validation
{
    public interface IMailValidator
    {
        ValidationResult ValidateMail(BaseMail mail);
    }
}
