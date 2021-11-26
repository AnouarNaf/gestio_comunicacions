using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConnexioPostgresql
{
    public partial class dualfctContext : DbContext
    {
        public dualfctContext()
        {
        }

        public dualfctContext(DbContextOptions<dualfctContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumne> Alumnes { get; set; }
        public virtual DbSet<Asociat> Asociada { get; set; }
        public virtual DbSet<Cicle> Cicles { get; set; }
        public virtual DbSet<CicleContacte> CicleContactes { get; set; }
        public virtual DbSet<Comunicacio> Comunicacions { get; set; }
        public virtual DbSet<Contacte> Contactes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Pertany> Pertanys { get; set; }
        public virtual DbSet<Usuari> Usuaris { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=172.24.127.7;Port=5432;Database=dualfct;Username=dualuser;Password=Dual123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Alumne>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("Alumnes_pkey");

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .HasColumnName("DNI")
                    .IsFixedLength(true);

                entity.Property(e => e.CognomAlumne)
                    .HasMaxLength(20)
                    .HasColumnName("Cognom_Alumne")
                    .IsFixedLength(true);

                entity.Property(e => e.NomAlumne)
                    .HasMaxLength(20)
                    .HasColumnName("Nom_Alumne")
                    .IsFixedLength(true);

                entity.Property(e => e.NomCicle)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Nom_cicle")
                    .IsFixedLength(true);

                entity.Property(e => e.TipusPractica)
                    .HasMaxLength(20)
                    .HasColumnName("Tipus_Practica")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Nom_Cicle)
                    .WithMany(p => p.Alumnes)
                    .HasForeignKey(d => d.NomCicle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Nom_Cicle");
            });

            modelBuilder.Entity<Asociat>(entity =>
            {
                entity.HasKey(e => new { e.CicleNom, e.EmpresaNif })
                    .HasName("Pk_Asociada");

                entity.Property(e => e.CicleNom)
                    .HasMaxLength(10)
                    .HasColumnName("Cicle_Nom")
                    .IsFixedLength(true);

                entity.Property(e => e.EmpresaNif)
                    .HasMaxLength(20)
                    .HasColumnName("Empresa_NIF")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Cicle_Nom)
                    .WithMany(p => p.Asociada)
                    .HasForeignKey(d => d.CicleNom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Cicle_Nom");

                entity.HasOne(d => d.Empresa_Nif)
                    .WithMany(p => p.Asociada)
                    .HasForeignKey(d => d.EmpresaNif)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Empresa_Nif");
            });

            modelBuilder.Entity<Cicle>(entity =>
            {
                entity.HasKey(e => e.NomCicle)
                    .HasName("Cicle_pkey");

                entity.ToTable("Cicle");

                entity.Property(e => e.NomCicle)
                    .HasMaxLength(10)
                    .HasColumnName("Nom_Cicle")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<CicleContacte>(entity =>
            {
                entity.HasKey(e => new { e.CicleNom, e.ContacteDni });

                entity.ToTable("Cicle_Contacte");

                entity.Property(e => e.CicleNom)
                    .HasMaxLength(10)
                    .HasColumnName("Cicle_Nom")
                    .IsFixedLength(true);

                entity.Property(e => e.ContacteDni)
                    .HasMaxLength(10)
                    .HasColumnName("Contacte_DNI")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Cicle_Nom)
                    .WithMany(p => p.CicleContactes)
                    .HasForeignKey(d => d.CicleNom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Cicle_Nom");

                entity.HasOne(d => d.Contacte_Dni)
                    .WithMany(p => p.CicleContactes)
                    .HasForeignKey(d => d.ContacteDni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Contacte_Dni");
            });

            modelBuilder.Entity<Comunicacio>(entity =>
            {
                entity.HasKey(e => new { e.UsuariNom, e.ContacteDni })
                    .HasName("Pk_Comunicacions");

                entity.Property(e => e.UsuariNom)
                    .HasMaxLength(20)
                    .HasColumnName("Usuari_Nom")
                    .IsFixedLength(true);

                entity.Property(e => e.ContacteDni)
                    .HasMaxLength(10)
                    .HasColumnName("Contacte_DNI")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Contacte_Dni)
                    .WithMany(p => p.Comunicacions)
                    .HasForeignKey(d => d.ContacteDni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Dni_Contacte");

                entity.HasOne(d => d.Usuari_Nom)
                    .WithMany(p => p.Comunicacions)
                    .HasForeignKey(d => d.UsuariNom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Nom_Usuari");
            });

            modelBuilder.Entity<Contacte>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("Contacte_pkey");

                entity.ToTable("Contacte");

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .HasColumnName("DNI")
                    .IsFixedLength(true);

                entity.Property(e => e.Especialització)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.NifEmpresa)
                    .HasMaxLength(20)
                    .HasColumnName("NIF_Empresa")
                    .IsFixedLength(true);

                entity.Property(e => e.Nom)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Telèfon)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Nif_Empresa)
                    .WithMany(p => p.Contactes)
                    .HasForeignKey(d => d.NifEmpresa)
                    .HasConstraintName("Fk_Nif_Empresa");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Nif)
                    .HasName("Empresa_pkey");

                entity.ToTable("Empresa");

                entity.Property(e => e.Nif)
                    .HasMaxLength(20)
                    .HasColumnName("NIF")
                    .IsFixedLength(true);

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Telèfon)
                    .HasMaxLength(9)
                    .IsFixedLength(true);

                entity.Property(e => e.Ubicació)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Pertany>(entity =>
            {
                entity.HasKey(e => new { e.AlumnesDni, e.AsociadaCicleNom, e.AsociadaEmpresaNif })
                    .HasName("Pk_Pertany");

                entity.ToTable("Pertany");

                entity.Property(e => e.AlumnesDni)
                    .HasMaxLength(10)
                    .HasColumnName("Alumnes_DNI")
                    .IsFixedLength(true);

                entity.Property(e => e.AsociadaCicleNom)
                    .HasMaxLength(10)
                    .HasColumnName("Asociada_Cicle_Nom")
                    .IsFixedLength(true);

                entity.Property(e => e.AsociadaEmpresaNif)
                    .HasMaxLength(20)
                    .HasColumnName("Asociada_Empresa_NIF")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Alumnes_Dni)
                    .WithMany(p => p.Pertanys)
                    .HasForeignKey(d => d.AlumnesDni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Alumnes_Dni");

                entity.HasOne(d => d.Asociada)
                    .WithMany(p => p.Pertanys)
                    .HasForeignKey(d => new { d.AsociadaCicleNom, d.AsociadaEmpresaNif })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Asociada_Cicle");
            });

            modelBuilder.Entity<Usuari>(entity =>
            {
                entity.HasKey(e => e.Nom)
                    .HasName("Usuari_pkey");

                entity.ToTable("Usuari");

                entity.Property(e => e.Nom)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Administrador)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Contrasenya)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.NomCicle)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Nom_Cicle")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Nom_Cicle)
                    .WithMany(p => p.Usuaris)
                    .HasForeignKey(d => d.NomCicle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Usuri_Cicle");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
