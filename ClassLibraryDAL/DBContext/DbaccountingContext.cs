using System;
using System.Collections.Generic;
using ClassLibraryEntity.Models.Accounting;
using Microsoft.EntityFrameworkCore;

namespace ClassLibraryDAL;

public partial class DbaccountingContext : DbContext
{
    public DbaccountingContext()
    {
    }

    public DbaccountingContext(DbContextOptions<DbaccountingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolMenu> RolMenus { get; set; }

    public virtual DbSet<UserPerson> UserPeople { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        optionsBuilder.UseSqlServer("Server=localhost;Database=DBAccounting;User=localhost;Password=lmcdhc2358;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Category__CBD74706391BB0F5");

            entity.ToTable("Category");

            entity.Property(e => e.DateRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__4D7EA8E1FF41C5D7");

            entity.ToTable("Menu");

            entity.Property(e => e.Controller)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DateRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DescriptionMenu)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Icono)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PageAction)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMenuFatherNavigation).WithMany(p => p.InverseIdMenuFatherNavigation)
                .HasForeignKey(d => d.IdMenuFather)
                .HasConstraintName("FK__Menu__IdMenuFath__267ABA7A");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.IdPerson);

            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C06DA7CA6");

            entity.ToTable("Rol");

            entity.Property(e => e.DateRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolMenu>(entity =>
        {
            entity.HasKey(e => e.IdRolMenu).HasName("PK__RolMenu__79F10105356E1020");

            entity.ToTable("RolMenu");

            entity.Property(e => e.DateRegistration)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__RolMenu__IdMenu__2E1BDC42");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__RolMenu__IdRol__2D27B809");
        });

        modelBuilder.Entity<UserPerson>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__UserPers__B7C92638349EB001");

            entity.ToTable("UserPerson");

            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.CorreoUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NameUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TelephoneUser)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserPeople)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__UserPerso__IdRol__31EC6D26");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
