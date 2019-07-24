﻿// <auto-generated />
using System;
using CrudWithEventSource.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudWithEventSource.Web.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("CrudWithEventSource.Web.Domain.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<Guid>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CrudWithEventSource.Web.Domain.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdentificationNumber")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CrudWithEventSource.Web.Domain.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CrudWithEventSource.Web.EventsModel.StoredEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action")
                        .IsRequired();

                    b.Property<string>("AggregateId")
                        .IsRequired();

                    b.Property<string>("AggregateIdType")
                        .IsRequired();

                    b.Property<int>("AggregateNumber");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Data")
                        .IsRequired();

                    b.Property<string>("User")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("StoredEvents");
                });

            modelBuilder.Entity("CrudWithEventSource.Web.Domain.Address", b =>
                {
                    b.HasOne("CrudWithEventSource.Web.Domain.Student")
                        .WithOne("Address")
                        .HasForeignKey("CrudWithEventSource.Web.Domain.Address", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
