namespace Core.DataTypes
{
    public class Email
    {
        public Email()
        {
            From = new EmailAddress();
            To = new EmailAddress();
            EmailBody = new EmailBody();
        }
        public EmailAddress From { get; set; }
        public EmailAddress To { get; set; }
        public string Subject { get; set; }
        public EmailBody EmailBody { get; set; }
    }
}
