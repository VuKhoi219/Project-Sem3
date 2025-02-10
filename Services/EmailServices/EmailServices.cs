using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Project_Sem3.Helper;

public class EmailServices 
{
    private readonly EmailSettings _emailSettings;

    public EmailServices(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body, Stream attachment = null, string attachmentName = null)
    {
        var smtpClient = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
        {
            Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password),
            EnableSsl = _emailSettings.EnableSsl
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.FromEmail, _emailSettings.FromName),
            Subject = subject,
            Body = body,
            IsBodyHtml = false // Set to true if sending HTML email
        };

        mailMessage.To.Add(toEmail);

        if (attachment != null && attachmentName != null)
        {
            attachment.Position = 0; // Ensure the stream position is set to the beginning
            mailMessage.Attachments.Add(new Attachment(attachment, attachmentName));
        }

        await smtpClient.SendMailAsync(mailMessage);
    }
}

public class EmailSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FromEmail { get; set; }
    public string FromName { get; set; }
    public bool EnableSsl { get; set; }
}