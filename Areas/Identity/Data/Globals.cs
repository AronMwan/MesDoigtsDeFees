using MesDoigtsDeFees.Models;
using MesDoigtsDeFees.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace MesDoigtsDeFees.Areas.Identity.Data
{
    public class Globals
    {
        public static MesDoigtsDeFeesUser GlobalUser { get; set; }

        static public Dictionary<string, Parameter> Parameters { get; set; }

        static public WebApplication App { get; set; }


        static public void ConfigureMail()
        {
            MailKitEmailSender mailSender = (MailKitEmailSender)App.Services.GetService<IEmailSender>();
            var options = mailSender.Options;
            options.Server = Parameters["Mail.Server"].Value;
            options.Port = Convert.ToInt32(Parameters["Mail.Port"].Value);
            options.Account = Parameters["Mail.Account"].Value;
            options.Password = Parameters["Mail.Password"].Value;
            options.SenderEmail = Parameters["Mail.SenderEmail"].Value;
            options.SenderName = Parameters["Mail.SenderName"].Value;
            options.Security = Convert.ToBoolean(Parameters["Mail.Security"].Value);

        }
    }
}
