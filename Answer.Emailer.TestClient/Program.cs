namespace Answer.Emailer.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmailSender emailer = new EmailSender();

            var mail = new BaseMail
            {
                From = "no-reply@answerconsulting.com",
                Subject = "Test Answer.Emailer",
                Body = "<p>Test Html body.</p>"
            };
            
            mail.To.Add("daniel.morris@answerconsulting.com");
            mail.To.Add("jonny.smith@answerconsulting.com");

            mail.Cc.Add("phil.bottomley@answerconsulting.com");

            mail.Bcc.Add("carl.cox@answerconsulting.com");

            mail.Important = false;

            var result = emailer.Send(mail);

            if (result.Success)
            {
                var x = 2;
            }
        }
    }
}
