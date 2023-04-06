using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI
{
    public class ContactContext : IdentityDbContext<ApplicationUser>
    {
        public ContactContext(DbContextOptions<ContactContext> options)  : base(options)
        {  
        }

        public DbSet<ApplicationUser>ApplicationUsers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Contact> Contacts  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>().HasData(


                new Contact()
                {
                    Id = 1,
                    FullName = "Jane Smith",
                    MobilePhone = "09087654321",
                    Email = "janesmith@example.com",
                    Address = "456 Elm Street",
                    ImageUrl = "https://example.com/janesmith.jpg",
                    CreatedDate = DateTime.Now,
                },


                new Contact()
                {
                    Id = 2,
                    FullName = "John Doe",
                    MobilePhone = "08012345678",
                    Email = "johndoe@example.com",
                    Address = "123 Main Street",
                    ImageUrl = "https://example.com/johndoe.jpg",
                    CreatedDate = DateTime.Now,
                },

               new Contact()
               {
                   Id = 3,
                   FullName = "Bob Johnson",
                   MobilePhone = "07011223344",
                   Email = "bobjohnson@example.com",
                   Address = "789 Oak Street",
                   ImageUrl = "https://example.com/bobjohnson.jpg",
                   CreatedDate = DateTime.Now,
               });
            
        }
        
    }
}
