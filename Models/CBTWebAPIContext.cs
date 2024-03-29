﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using rating.Data;

namespace CBTWebAPI.Models
{
    public class CBTWebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CBTWebAPIContext() : base("name=CBTWebAPIContext")
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<QuestionAndAnswer> QuestionAndAnswers { get; set; }
        // public System.Data.Entity.DbSet<CBTWebAPI.Models.Result> Results { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasMany(x => x.QuestionAndAnswers).WithRequired().WillCascadeOnDelete();
        }
    }
}
