
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using ENtityFrameWork_Test.Models;
using ENtityFrameWork_Test.Entities;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ENtityFrameWork_Test.Extensions
{
    public class TestContext : IdentityDbContext<User> 
    {
        public virtual DbSet<TestTable> TestTable { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<Symptoms> Symptoms { get; set; }
        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<AnimalDisease> AnimalDiseases { get; set; }
        public virtual DbSet<BreedDisease> BreedDiseases { get; set; }
        public virtual DbSet<DiseaseSymptom> DiseaseSymptoms { get; set; }
        public virtual DbSet<User> Users{ get; set; }

        public TestContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region HasKey

            modelBuilder.Entity<Animal>().HasKey(a => a.Id);

            modelBuilder.Entity<Breed>().HasKey(b => b.Id);

            modelBuilder.Entity<Disease>().HasKey(d => d.Id);

            modelBuilder.Entity<Symptoms>().HasKey(s => s.Id);

            modelBuilder.Entity<AnimalDisease>().HasKey(s => s.Id);

            modelBuilder.Entity<BreedDisease>().HasKey(s => s.Id);

            modelBuilder.Entity<DiseaseSymptom>().HasKey(s => s.Id);


            #endregion

            #region Property          

            #endregion

            #region Relations

            #region Animals

            modelBuilder.Entity<Animal>()
                .HasMany(a => a.Breeds)
                .WithOne(b => b.Animal)
                .HasForeignKey(b => b.AnimalId);

            modelBuilder.Entity<Animal>()
                .HasMany(a => a.AnimalDisease)
                .WithOne(b => b.Animal)
                .HasForeignKey(b => b.AnimalId);

            #endregion

            #region Disease 

            modelBuilder.Entity<Disease>()
                .HasMany(b => b.DiseaseSymptoms)
                .WithOne(d => d.Disease)
                .HasForeignKey(d => d.DiseaseId);

            modelBuilder.Entity<Disease>()
                .HasMany(d => d.AnimalDisease)
                .WithOne(a => a.Disease)
                .HasForeignKey(d => d.DiseaseId);

            modelBuilder.Entity<Disease>()
                .HasMany(d => d.DiseaseSymptoms)
                .WithOne(s => s.Disease)
                .HasForeignKey(d => d.DiseaseId);

            #endregion

            #region Breed

            modelBuilder.Entity<Breed>()
                .HasMany(d => d.BreedDisease)
                .WithOne(s => s.Breed)
                .HasForeignKey(d => d.BreedId);

            #endregion

            #region Symptoms

            modelBuilder.Entity<Symptoms>()
                .HasMany(d => d.DiseaseSymptom)
                .WithOne(s => s.Symptoms)
                .HasForeignKey(d => d.SymptomId);

            #endregion

            #region Identity

            #endregion

            #endregion
        }
    }
}
