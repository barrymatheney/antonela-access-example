using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access
{
    public class AccessContext : DbContext
    {
        public object Orders { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseAccess("DataSource=C:\\temp\\Test.accdb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder
               .HasAnnotation("ProductVersion", "5.0.1");


            // Creating tables, defining PK


            modelBuilder.Entity("Access.Models.Orders", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INT");


                b.Property<string>("ShipCity")
                    .HasColumnType("VARCHAR");

                b.HasKey("Id");

                b.ToTable("Orders");
            });

        }
    }
}
