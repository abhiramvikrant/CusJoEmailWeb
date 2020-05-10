using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace CusJoEmailWeb
{
    public class EmailDBContext : DbContext
    {

        public virtual DbSet<EmailList> EmailList { get; set; }
        public EmailDBContext(DbContextOptions<EmailDBContext> options)
            : base(options)
        {
        }

        public EmailDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=cusjoapi;Trusted_Connection=True;");
        }
    }
}