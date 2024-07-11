using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TheFinalProject.core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aboutu> Aboutus { get; set; } = null!;
        public virtual DbSet<Contactu> Contactus { get; set; } = null!;
        public virtual DbSet<Credential> Credentials { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Hall> Halls { get; set; } = null!;
        public virtual DbSet<Homepage> Homepages { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VisaChecker> VisaCheckers { get; set; } = null!;
        public virtual DbSet<Visainfo> Visainfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id=C##THEFINALPROJECT;PASSWORD=12345;Persist Security Info=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##THEFINALPROJECT")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Aboutu>(entity =>
            {
                entity.HasKey(e => e.AboutusId)
                    .HasName("SYS_C008614");

                entity.ToTable("ABOUTUS");

                entity.Property(e => e.AboutusId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUTUS_ID");
            });

            modelBuilder.Entity<Contactu>(entity =>
            {
                entity.HasKey(e => e.ContactusId)
                    .HasName("SYS_C008612");

                entity.ToTable("CONTACTUS");

                entity.Property(e => e.ContactusId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTUS_ID");
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.ToTable("CREDENTIALS");

                entity.HasIndex(e => e.Email, "SYS_C008581")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "SYS_C008582")
                    .IsUnique();

                entity.Property(e => e.CredentialId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CREDENTIAL_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Credential)
                    .HasForeignKey<Credential>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CREDENTIALS_FOREIGN_KEY");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("FEEDBACK");

                entity.Property(e => e.FeedbackId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FEEDBACK_ID");

                entity.Property(e => e.CreationDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATION_DATE")
                    .HasDefaultValueSql("SYSTIMESTAMP");

                entity.Property(e => e.FeedbackContent)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("FEEDBACK_CONTENT");

                entity.Property(e => e.HallId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HALL_ID");

                entity.Property(e => e.Rating)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RATING");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FEEDBACK_HALL_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FEEDBACK_USER_FK");
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.ToTable("HALLS");

                entity.Property(e => e.HallId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HALL_ID");

                entity.Property(e => e.FloorNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FLOOR_NUMBER");

                entity.Property(e => e.Hall1ImagePath)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("HALL1_IMAGE_PATH");

                entity.Property(e => e.Hall2ImagePath)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("HALL2_IMAGE_PATH");

                entity.Property(e => e.Hall3ImagePath)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("HALL3_IMAGE_PATH");

                entity.Property(e => e.Hall4ImagePath)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("HALL4_IMAGE_PATH");

                entity.Property(e => e.Hall5ImagePath)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("HALL5_IMAGE_PATH");

                entity.Property(e => e.Hall6ImagePath)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("HALL6_IMAGE_PATH");

                entity.Property(e => e.Hall7ImagePath)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("HALL7_IMAGE_PATH");

                entity.Property(e => e.HallAvailabilityDate)
                    .HasPrecision(6)
                    .HasColumnName("HALL_AVAILABILITY_DATE")
                    .HasDefaultValueSql("systimestamp");

                entity.Property(e => e.HallCapacity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HALL_CAPACITY");

                entity.Property(e => e.HallIdentity)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HALL_IDENTITY");

                entity.Property(e => e.HallLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HALL_LOCATION");

                entity.Property(e => e.HallName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HALL_NAME");

                entity.Property(e => e.HallNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HALL_NUMBER");

                entity.Property(e => e.Isavailable)
                    .HasPrecision(1)
                    .HasColumnName("ISAVAILABLE")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Meridians)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MERIDIANS");

                entity.Property(e => e.NumberOfChairs)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_CHAIRS");

                entity.Property(e => e.NumberOfTables)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_TABLES");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Services)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SERVICES");

                entity.Property(e => e.StatusId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS_ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Halls)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("HSFOREIGN_KEY");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Halls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("HUFOREIGN_KEY");
            });

            modelBuilder.Entity<Homepage>(entity =>
            {
                entity.ToTable("HOMEPAGE");

                entity.Property(e => e.HomePageid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOME_PAGEID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("STATUS");

                entity.Property(e => e.StatusId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STATUS_ID");

                entity.Property(e => e.Status1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIALS");

                entity.Property(e => e.TestimonialId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIAL_ID");

                entity.Property(e => e.CreationDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATION_DATE")
                    .HasDefaultValueSql("systimestamp");

                entity.Property(e => e.Isdeleted)
                    .HasPrecision(1)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TestimonialContent)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONIAL_CONTENT");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("TESTIMONIAL_FOREIGN_KEY");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ROLE_FOREIGN_KEY");
            });

            modelBuilder.Entity<VisaChecker>(entity =>
            {
                entity.HasKey(e => e.VisaChecherId)
                    .HasName("SYS_C008600");

                entity.ToTable("VISA_CHECKER");

                entity.HasIndex(e => e.CardNumber, "SYS_C008601")
                    .IsUnique();

                entity.Property(e => e.VisaChecherId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VISA_CHECHER_ID");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.CardHolderName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CARD_HOLDER_NAME");

                entity.Property(e => e.CardNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARD_NUMBER");

                entity.Property(e => e.Cvc)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CVC");
            });

            modelBuilder.Entity<Visainfo>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("SYS_C008592");

                entity.ToTable("VISAINFO");

                entity.HasIndex(e => e.CardNumber, "SYS_C008593")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "SYS_C008594")
                    .IsUnique();

                entity.Property(e => e.PaymentId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAYMENT_ID");

                entity.Property(e => e.CardHolderName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CARD_HOLDER_NAME");

                entity.Property(e => e.CardNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARD_NUMBER");

                entity.Property(e => e.Cvc)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CVC");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Visainfo)
                    .HasForeignKey<Visainfo>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("UVFOREIGN_KEY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
