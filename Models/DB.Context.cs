﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectSale.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class posEntities : DbContext
    {
        public posEntities()
            : base("name=posEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee_detail> Employee_detail { get; set; }
        public virtual DbSet<Employee_status> Employee_status { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Payment_status> Payment_status { get; set; }
        public virtual DbSet<Payment_type> Payment_type { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_department> Product_department { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Sale_detail> Sale_detail { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User_type> User_type { get; set; }
    }
}
