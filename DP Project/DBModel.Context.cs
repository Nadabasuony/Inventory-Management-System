﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DP_Project
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TradingCompanyEntities : DbContext
    {
        public TradingCompanyEntities()
            : base("name=TradingCompanyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Permissioned_Item> Permissioned_Item { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Store_Item> Store_Item { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Transfer_Item> Transfer_Item { get; set; }
    }
}
