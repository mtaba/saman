﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace saman.Models.DomainModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SamanEntities : DbContext
    {
        public SamanEntities()
            : base("name=SamanEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Cheque> Cheques { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<HealthInsurance> HealthInsurances { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Letter> Letters { get; set; }
        public virtual DbSet<Mardrak> Mardraks { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Person_Madraks> Person_Madraks { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Retiree> Retirees { get; set; }
        public virtual DbSet<RetirementType> RetirementTypes { get; set; }
        public virtual DbSet<TreatmentType> TreatmentTypes { get; set; }
    }
}
