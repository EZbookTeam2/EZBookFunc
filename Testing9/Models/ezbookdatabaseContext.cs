using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Testing9.Models
{
    public partial class ezbookdatabaseContext : DbContext
    {
        public ezbookdatabaseContext()
        {
        }

        public ezbookdatabaseContext(DbContextOptions<ezbookdatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Cancellation> Cancellation { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Slot> Slot { get; set; }
        public virtual DbSet<Testing> Testing { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\localdbezbook;Initial Catalog=ezbookdatabase;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId)
                    .HasColumnName("booking_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsersId)
                    .HasColumnName("users_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Booking__room_id__2E1BDC42");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__Booking__users_i__2D27B809");
            });

            modelBuilder.Entity<Cancellation>(entity =>
            {
                entity.ToTable("cancellation");

                entity.Property(e => e.CancellationId)
                    .HasColumnName("cancellation_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookingId)
                    .HasColumnName("booking_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Cancellation)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__cancellat__booki__2F10007B");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.Property(e => e.SlotId)
                    .HasColumnName("slot_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Slot)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Slot__room_id__300424B4");
            });

            modelBuilder.Entity<Testing>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Testing__536C85E5D3B5718A");

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Salt).HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.UsersId)
                    .HasColumnName("users_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Names)
                    .HasColumnName("names")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasColumnName("nationality")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Passwords)
                    .HasColumnName("passwords")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Profilepic)
                    .HasColumnName("profilepic")
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
