﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
   public class Context: IdentityDbContext<WriterUser,WriterRole,int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=CorePortfolioDb.mssql.somee.com;packet size=4096;user id=minel1313_SQLLogin_1;pwd=792httr7sb;data source=CorePortfolioDb.mssql.somee.com;persist security info=False;initial catalog=CorePortfolioDb");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Certficate> Certficates { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<WriterMessage> WriterMessages { get; set; }
        
    }
}
