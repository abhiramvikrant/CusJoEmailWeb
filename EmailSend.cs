using System;
using System.Collections.Generic;
using System.Text;

namespace CusJoEmailWeb
{
    public class EmailSend
    {
       
        public List<EmailList> GetAllEmails()
        {
            using (EmailDBContext context = new EmailDBContext())
            {
                var newList = new List<EmailList>();
                var list = context.EmailList;
                foreach (var item in list)
                {
                    newList.Add(new EmailList()
                    {
                        Id = item.Id,
                        email = item.email,
                        emailverified = item.emailverified,
                        countsent = item.countsent,
                        replysent = item.replysent
                    });

                }
                return newList;
            }
            
        }
    }
}
