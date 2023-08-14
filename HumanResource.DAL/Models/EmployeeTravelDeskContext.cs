using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.DAL.Models;

public partial class EmployeeTravelDeskContext : DbContext
{
    public EmployeeTravelDeskContext()
    {
    }

    public EmployeeTravelDeskContext(DbContextOptions<EmployeeTravelDeskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<GradesHistory> GradesHistories { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<ReimbursementRequest> ReimbursementRequests { get; set; }

    public virtual DbSet<ReimbursementType> ReimbursementTypes { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ReservationDoc> ReservationDocs { get; set; }

    public virtual DbSet<ReservationType> ReservationTypes { get; set; }

    public virtual DbSet<TravelBudgetAllocation> TravelBudgetAllocations { get; set; }

    public virtual DbSet<TravelRequest> TravelRequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//# warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//=> optionsBuilder.UseSqlServer("Data Source=SHUBHAM\\SQLEXPRESS;Initial Catalog=EmployeeTravelDesk;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GradesHistory>(entity =>
        {
            entity.ToTable("GradesHistory");

            entity.Property(e => e.AssignedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.Employee).WithMany(p => p.GradesHistories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GradesHistory_Users");

            entity.HasOne(d => d.Grade).WithMany(p => p.GradesHistories)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GradesHistory_Grades");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReimbursementRequest>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DocumentUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DocumentURL");
            entity.Property(e => e.InvoiceDate).HasColumnType("date");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.RequestProcessedOn).HasColumnType("date");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.ReimbursementType).WithMany(p => p.ReimbursementRequests)
                .HasForeignKey(d => d.ReimbursementTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReimbursementRequests_ReimbursementTypes");

            entity.HasOne(d => d.RequestProcessedByEmployee).WithMany(p => p.ReimbursementRequestRequestProcessedByEmployees)
                .HasForeignKey(d => d.RequestProcessedByEmployeeId)
                .HasConstraintName("FK_ReimbursementRequests_Users1");

            entity.HasOne(d => d.RequestRaisedByEmployee).WithMany(p => p.ReimbursementRequestRequestRaisedByEmployees)
                .HasForeignKey(d => d.RequestRaisedByEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReimbursementRequests_Users");

            entity.HasOne(d => d.TravelRequest).WithMany(p => p.ReimbursementRequests)
                .HasForeignKey(d => d.TravelRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReimbursementRequests_TravelRequests1");
        });

        modelBuilder.Entity<ReimbursementType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Type)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConfirmationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ConfirmationID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReservationDate).HasColumnType("date");
            entity.Property(e => e.ReservationDoneWithEntity)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ReservationType).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ReservationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservations_ReservationTypes");

            entity.HasOne(d => d.TravelRequest).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TravelRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservations_TravelRequests");
        });

        modelBuilder.Entity<ReservationDoc>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DocumentUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DocumentURL");

            entity.HasOne(d => d.Reservation).WithMany(p => p.ReservationDocs)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationDocs_Reservations");
        });

        modelBuilder.Entity<ReservationType>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.Property(e => e.TypeId).ValueGeneratedNever();
            entity.Property(e => e.TypeName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TravelBudgetAllocation>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ApprovedHotelStarRating)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedModeOfTravel)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.TravelRequest).WithMany(p => p.TravelBudgetAllocations)
                .HasForeignKey(d => d.TravelRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TravelBudgetAllocations_TravelRequests");
        });

        modelBuilder.Entity<TravelRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.Property(e => e.RequestId).ValueGeneratedNever();
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.Priority)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PurposeOfTravel)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RequestApprovedOn).HasColumnType("date");
            entity.Property(e => e.RequestRaisedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ToBeApprovedByHrid).HasColumnName("ToBeApprovedByHRId");
            entity.Property(e => e.ToDate).HasColumnType("date");

            entity.HasOne(d => d.Location).WithMany(p => p.TravelRequests)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TravelRequests_Locations");

            entity.HasOne(d => d.RaisedByEmployee).WithMany(p => p.TravelRequestRaisedByEmployees)
                .HasForeignKey(d => d.RaisedByEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TravelRequests_Users");

            entity.HasOne(d => d.ToBeApprovedByHr).WithMany(p => p.TravelRequestToBeApprovedByHrs)
                .HasForeignKey(d => d.ToBeApprovedByHrid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TravelRequests_Users1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.CurrentGrade).WithMany(p => p.Users)
                .HasForeignKey(d => d.CurrentGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Grades");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
