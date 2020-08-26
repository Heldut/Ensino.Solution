using System;
using System.Linq;
using Ensino.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Ensino.Infraestrutura.Data.Mapeamento;

namespace Ensino.Infraestrutura.Data.Contexto
{
    public class ContextoDB : DbContext
    {
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<CargaDados> CargaDados { get; set; }

        public IDbContextTransaction Transaction { get; private set; }

        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options)
        {
            try
            {
                if (Database.GetPendingMigrations().Count() > 0)
                    Database.Migrate();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
        }

        public IDbContextTransaction InitTransacao()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }

        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Salvar();
            Commit();
        }
    }
}
