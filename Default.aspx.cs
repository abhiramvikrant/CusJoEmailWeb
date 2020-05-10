using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CusJoEmailWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EmailSend es = new EmailSend();
                List<EmailList> eList = es.GetAllEmails();
                var FilterEmail = eList.Where(x => x.countsent < 4 && x.emailverified == false).ToList();
                foreach (var item in FilterEmail)
                {
                    MailMessage message = new MailMessage("abhiramvikrant@gmail.com", item.email);
                    string mailbody = $"https://localhost:44383/about.aspx?id={item.Id}";
                    message.Subject = "Introduction Email";
                    message.Body = mailbody;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    EmailHelper eh = new EmailHelper();
                    eh.SendEmail(message);
                    UpdateCountSent(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                closepage();
            }
            
           



        }

        private void closepage()
        {
            string closeWindowScript = "<script language=javascript>window.top.close();</script>";
            if ((!ClientScript.IsStartupScriptRegistered("clientScript")))
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", closeWindowScript);
            }
        }

        private void UpdateCountSent(EmailList model)
        {
            model.countsent += 1;
            using (EmailDBContext context = new EmailDBContext())
            {
                context.EmailList.Update(model);
                context.SaveChanges();
            }

        }

    }
}