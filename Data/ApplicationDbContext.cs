//using IdentityManagerUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<ApplicationUser>().HasMany(p => p.Roles).WithOne().HasForeignKey(p => p.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //    builder.Entity<ApplicationUser>().HasMany(e => e.Claims).WithOne().HasForeignKey(e => e.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //    builder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //}
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<ApplicationUser>().HasMany(p => p.Roles).WithOne().HasForeignKey(p => p.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //    builder.Entity<ApplicationUser>().HasMany(e => e.Claims).WithOne().HasForeignKey(e => e.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        //    builder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<IdentityRoleClaim<string>>().HasOne(p => p.RoleId).WithMany().HasForeignKey(p => p.RoleId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        //}


    }
}
