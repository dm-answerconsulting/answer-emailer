using Answer.Emailer.Validation;

namespace Answer.Emailer
{
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email using an SmptClient
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mail"></param>
        /// <param name="validator">If not specified the standard validator will be used</param>
        /// <returns>Mail result</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="mail"/> is null.</exception><exception cref="T:System.InvalidOperationException">This <see cref="T:System.Net.Mail.SmtpClient"/> has a <see cref="Overload:System.Net.Mail.SmtpClient.SendAsync"/> call in progress.-or- <see cref="P:System.Net.Mail.MailMessage.From"/> is null.-or- There are no recipients specified in <see cref="P:System.Net.Mail.MailMessage.To"/>, <see cref="P:System.Net.Mail.MailMessage.CC"/>, and <see cref="P:System.Net.Mail.MailMessage.Bcc"/> properties.-or- <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod"/> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network"/> and <see cref="P:System.Net.Mail.SmtpClient.Host"/> is null.-or-<see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod"/> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network"/> and <see cref="P:System.Net.Mail.SmtpClient.Host"/> is equal to the empty string ("").-or- <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod"/> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network"/> and <see cref="P:System.Net.Mail.SmtpClient.Port"/> is zero, a negative number, or greater than 65,535.</exception><exception cref="T:System.ObjectDisposedException">This object has been disposed.</exception><exception cref="T:System.Net.Mail.SmtpException">The connection to the SMTP server failed.-or-Authentication failed.-or-The operation timed out.-or-<see cref="P:System.Net.Mail.SmtpClient.EnableSsl"/> is set to true but the <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod"/> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.SpecifiedPickupDirectory"/> or <see cref="F:System.Net.Mail.SmtpDeliveryMethod.PickupDirectoryFromIis"/>.-or-<see cref="P:System.Net.Mail.SmtpClient.EnableSsl"/> is set to true, but the SMTP mail server did not advertise STARTTLS in the response to the EHLO command.</exception><exception cref="T:System.Net.Mail.SmtpFailedRecipientsException">The <paramref name="mail.Body"/> could not be delivered to one or more of the recipients in <see cref="P:System.Net.Mail.MailMessage.To"/>, <see cref="P:System.Net.Mail.MailMessage.CC"/>, or <see cref="P:System.Net.Mail.MailMessage.Bcc"/>.</exception>
        MailResult Send<T>(T mail, IMailValidator validator = null) where T : BaseMail;
    }
}