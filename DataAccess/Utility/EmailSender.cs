using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
namespace WebPWrecover.Services;
public class EmailSender : IEmailSender
{
    private readonly ILogger _logger;
    private readonly IConfiguration _configuration;
    public EmailSender(IConfiguration configuration,
                       ILogger<EmailSender> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }
    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(_configuration["SendGridKey"]))
        {
            throw new Exception("Null SendGridKey");
        }
        await Execute(subject, message, toEmail);
    }
    public Task Execute(string subject, string message, string toEmail)
    {
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_configuration["AdminEmail:Email"], _configuration["AdminEmail:Password"]),
        };
        var mail = new MailMessage(from: _configuration["AdminEmail:Email"],
                            to: toEmail,
                            subject,
                            message
                            );
        mail.IsBodyHtml = true;
        return client.SendMailAsync(mail);
    }
    public class AuthMessageSenderOptions
    {
        public string? SendGridKey { get; set; }
    }
}