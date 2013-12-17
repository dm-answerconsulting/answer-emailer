using System.Collections.Generic;
using System.Net.Mail;
using Answer.Emailer.Validation;

namespace Answer.Emailer
{
    public class EmailSender : IEmailSender
    {
        private readonly MailResult _result = new MailResult();

        /// <summary>
        /// Sends an email using an SmptClient
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mail"></param>
        /// <param name="validator">If not specified the standard validator will be used</param>
        /// <returns>Mail result</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="mail"/> is null.</exception><exception cref="T:System.InvalidOperationException">This <see cref="T:System.Net.Mail.SmtpClient"/> has a <see cref="Overload:System.Net.Mail.SmtpClient.SendAsync"/> call in progress.-or- <see cref="P:System.Net.Mail.MailMessage.From"/> is null.-or- There are no recipients specified in <see cref="P:System.Net.Mail.MailMessage.To"/>, <see cref="P:System.Net.Mail.MailMessage.CC"/>, and <see cref="P:System.Net.Mail.MailMessage.Bcc"/> properties.-or- <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod"/> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network"/> and <see cref="P:System.Net.Mail.SmtpClient.Host"/> is null.-or-<see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod"/> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network"/> and <see cref="P:System.Net.Mail.SmtpClient.Host"/> is equal to the empty string ("").-or- <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod"/> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network"/> and <see cref="P:System.Net.Mail.SmtpClient.Port"/> is zero, a negative number, or greater than 65,535.</exception><exception cref="T:System.ObjectDisposedException">This object has been disposed.</exception><exception cref="T:System.Net.Mail.SmtpException">The connection to the SMTP server failed.-or-Authentication failed.-or-The operation timed out.-or-<see cref="P:System.Net.Mail.SmtpClient.EnableSsl"/> is set to true but the <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod"/> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.SpecifiedPickupDirectory"/> or <see cref="F:System.Net.Mail.SmtpDeliveryMethod.PickupDirectoryFromIis"/>.-or-<see cref="P:System.Net.Mail.SmtpClient.EnableSsl"/> is set to true, but the SMTP mail server did not advertise STARTTLS in the response to the EHLO command.</exception><exception cref="T:System.Net.Mail.SmtpFailedRecipientsException">The <paramref name="mail.Body"/> could not be delivered to one or more of the recipients in <see cref="P:System.Net.Mail.MailMessage.To"/>, <see cref="P:System.Net.Mail.MailMessage.CC"/>, or <see cref="P:System.Net.Mail.MailMessage.Bcc"/>.</exception>
        public MailResult Send<T>(T mail, IMailValidator validator = null) where T : BaseMail
        {
            _result.Reset();

            Validate(mail, validator ?? new StandardMailValidator());

            if (_result.Success)
            {
                TrySendMail(mail);
            }

            return _result;
        }
        
        private void Validate(BaseMail mail, IMailValidator validator)
        {
            var validationResult = validator.ValidateMail(mail);

            if (validationResult.IsValid)
            {
                return;
            }
            
            foreach (var validationError in validationResult.Errors)
            {
                _result.AddError(validationError);
            }
        }

        private void TrySendMail(BaseMail mail)
        {
            var mailMessage = CreateMailMessage(mail);

            new SmtpClient().Send(mailMessage);
        }

        private MailMessage CreateMailMessage(BaseMail mail)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(mail.From),
                Subject = mail.Subject,
                Body = mail.Body,
                IsBodyHtml = true,
                Priority = mail.Important ? MailPriority.High : MailPriority.Normal
            };

            AddToMailAddressCollection(mailMessage.To, mail.To);
            AddToMailAddressCollection(mailMessage.CC, mail.Cc);
            AddToMailAddressCollection(mailMessage.Bcc, mail.Bcc);

            return mailMessage;
        }

        private void AddToMailAddressCollection(MailAddressCollection collection, IEnumerable<string> inputList)
        {
            foreach (var item in inputList)
            {
                collection.Add(item);
            }
        }
    }
}