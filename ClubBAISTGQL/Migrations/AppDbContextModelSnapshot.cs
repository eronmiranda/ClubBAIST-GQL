﻿// <auto-generated />
using System;
using ClubBAISTGQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClubBAISTGQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ClubBAISTGQL.Models.Event", b =>
                {
                    b.Property<long>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.Member", b =>
                {
                    b.Property<long>("MemberNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AltPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyPostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MembershipID")
                        .HasColumnType("bigint");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberNumber");

                    b.HasIndex("MembershipID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.MemberTeeTime", b =>
                {
                    b.Property<long>("MemberNumber")
                        .HasColumnType("bigint");

                    b.Property<long>("TeeTimeID")
                        .HasColumnType("bigint");

                    b.Property<long?>("StandingTeeTimeID")
                        .HasColumnType("bigint");

                    b.HasKey("MemberNumber", "TeeTimeID");

                    b.HasIndex("StandingTeeTimeID");

                    b.HasIndex("TeeTimeID");

                    b.ToTable("MemberTeeTimes");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.Membership", b =>
                {
                    b.Property<long>("MembershipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MembershipID");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.RestrictedTime", b =>
                {
                    b.Property<long>("RestrictedTimeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("MembershipID")
                        .HasColumnType("bigint");

                    b.Property<string>("RestrictedDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("RestrictedTimeEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("RestrictedTimeStart")
                        .HasColumnType("time");

                    b.HasKey("RestrictedTimeID");

                    b.HasIndex("MembershipID");

                    b.ToTable("RestrictedTimes");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.StandingTeeTime", b =>
                {
                    b.Property<long>("StandingTeeTimeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StandingTeeTimeID");

                    b.ToTable("StandingTeeTimes");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.TeeTime", b =>
                {
                    b.Property<long>("TeeTimeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int?>("CartsRequested")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTeeTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("EventID")
                        .HasColumnType("bigint");

                    b.HasKey("TeeTimeID");

                    b.HasIndex("EventID");

                    b.ToTable("TeeTimes");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.Member", b =>
                {
                    b.HasOne("ClubBAISTGQL.Models.Membership", "Membership")
                        .WithMany("Members")
                        .HasForeignKey("MembershipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.MemberTeeTime", b =>
                {
                    b.HasOne("ClubBAISTGQL.Models.Member", "Member")
                        .WithMany("MemberTeeTimes")
                        .HasForeignKey("MemberNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClubBAISTGQL.Models.StandingTeeTime", "StandingTeeTime")
                        .WithMany("MemberTeeTimes")
                        .HasForeignKey("StandingTeeTimeID");

                    b.HasOne("ClubBAISTGQL.Models.TeeTime", "TeeTime")
                        .WithMany("MemberTeeTimes")
                        .HasForeignKey("TeeTimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("StandingTeeTime");

                    b.Navigation("TeeTime");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.RestrictedTime", b =>
                {
                    b.HasOne("ClubBAISTGQL.Models.Membership", "Membership")
                        .WithMany("RestrictedTimes")
                        .HasForeignKey("MembershipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.TeeTime", b =>
                {
                    b.HasOne("ClubBAISTGQL.Models.Event", "Event")
                        .WithMany("TeeTimes")
                        .HasForeignKey("EventID");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.Event", b =>
                {
                    b.Navigation("TeeTimes");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.Member", b =>
                {
                    b.Navigation("MemberTeeTimes");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.Membership", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("RestrictedTimes");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.StandingTeeTime", b =>
                {
                    b.Navigation("MemberTeeTimes");
                });

            modelBuilder.Entity("ClubBAISTGQL.Models.TeeTime", b =>
                {
                    b.Navigation("MemberTeeTimes");
                });
#pragma warning restore 612, 618
        }
    }
}
