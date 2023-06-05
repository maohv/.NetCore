using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

public class SendMailService
{
    MailSettings _mailsettings { set; get; }
    public SendMailService(IOptions<MailSettings> mailSettings)
    {
        _mailsettings = mailSettings.Value;
    }
    public async Task<string> SendMail(MailContent mailContent)
    {
        var email = new MimeMessage();
        email.Sender = new MailboxAddress(_mailsettings.DisplayName, _mailsettings.Mail);
        email.From.Add(new MailboxAddress(_mailsettings.DisplayName, _mailsettings.Mail));
        email.To.Add(new MailboxAddress(mailContent.To, mailContent.To));
        email.Subject = mailContent.Subject;

        var builder = new BodyBuilder();

        builder.HtmlBody = mailContent.Body;

        email.Body = builder.ToMessageBody();

        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        try
        {
            await smtp.ConnectAsync(_mailsettings.Host, _mailsettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailsettings.Mail, _mailsettings.Password);
            await smtp.SendAsync(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return "Loi" + e.Message;
        }


        smtp.Disconnect(true);

        return "GUI THANH CONG";
    }
}

public class MailContent
{
    public string To { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }



}