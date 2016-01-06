using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web;
using System.Data.Entity.Core.EntityClient;
using System.Data.Common;

namespace oblig3_s198530.Models
{
    public class Faq
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual Category Category { get; set; }

        public string Answer { get; set; }

        public string Title { get; set; }

        public string Question { get; set; }

        public int Clicks { get; set; }
    }

    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

       
    }

    public class Question
    {
        [Key]
        public int id { get; set; }
        public string question { get; set; }
        public string category { get; set; }
    }

    public class FAQContext : DbContext
    {
        public FAQContext()
          : base("name=FAQ")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Faq> Faq { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Question { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }


}