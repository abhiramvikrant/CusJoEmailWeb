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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                try
                {
                if (Request["Id"] != null)
                {
                    Guid oId = Guid.Parse(Request["Id"].ToString());
                    SetVerifyEmail(oId);
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
        private void SetVerifyEmail(Guid id)
        {

            using (EmailDBContext context = new EmailDBContext())
            {
                var eList = new EmailSend().GetAllEmails()
                    .Where(x => x.Id == id && x.emailverified == false).FirstOrDefault();
                if (eList != null)
                {
                    eList.emailverified = true;

                    MailMessage message = new MailMessage("abhiramvikrant@gmail.com", eList.email);
                    string mailbody = "Thank you for verifying the email";
                    message.Subject = "Thank you Email";
                    message.Body = mailbody;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    EmailHelper eh = new EmailHelper();
                    eh.SendEmail(message);
                    eList.replysent = true;
                    context.Update(eList);
                    context.SaveChanges();

                }
            }
        }
    }
}