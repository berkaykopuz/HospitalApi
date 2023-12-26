using HospitalApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<Citizen>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<HospitalClinic> HospitalClinics { get; set; }
        public DbSet<Doctor> Doctors  { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Timing> Timings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            modelBuilder.Entity<HospitalClinic>()
                    .HasKey(hc => new { hc.HospitalId, hc.ClinicId });
            modelBuilder.Entity<HospitalClinic>()
                    .HasOne(h => h.Hospital)
                    .WithMany(hc => hc.HospitalClinics)
                    .HasForeignKey(h => h.HospitalId);
            modelBuilder.Entity<HospitalClinic>()
                    .HasOne(h => h.Clinic)
                    .WithMany(hc => hc.HospitalClinics)
                    .HasForeignKey(c => c.ClinicId);

            
            
        }
        
    }
}
