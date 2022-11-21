using System.Net;
using System.Net.Mail;
using ETicaretAPI.Application.Abstraction.Services;
using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.Infrastructure.Services.Mail;

public class MailService : IMailService
{
    private readonly IConfiguration _configuration;

    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true)
    {
       
    }

    public async Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
    {
        MailMessage mail = new();
        mail.IsBodyHtml = isBodyHtml;
        foreach (var to in tos)
        {
            mail.To.Add(to);
        }

        mail.Subject = subject;
        mail.Body = body;
        mail.From = new("eyupkhrmn45@gmail.com","Kahraman Yazılım", System.Text.Encoding.UTF8);



        SmtpClient smtp = new();
        smtp.Credentials = new NetworkCredential(/*normalde buraya mail ve şifreyi koymamız gerekir*/);
    }
}