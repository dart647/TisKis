using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TisKis.Models;

namespace TisKis.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<UploadImage> UploadImages { get; set; }
        public DbSet<ConvertedImage> ConvertedImages { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
