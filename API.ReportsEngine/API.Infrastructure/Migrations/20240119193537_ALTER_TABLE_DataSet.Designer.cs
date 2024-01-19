﻿// <auto-generated />
using API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Infrastructure.Migrations
{
    [DbContext(typeof(ReportsEngineContext))]
    [Migration("20240119193537_ALTER_TABLE_DataSet")]
    partial class ALTER_TABLE_DataSet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Domain.Entities.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("API.Domain.Entities.DBFieldsBModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AreaID")
                        .HasColumnType("int");

                    b.Property<string>("AreaName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntityID")
                        .HasColumnType("int");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FieldID")
                        .HasColumnType("int");

                    b.Property<string>("FieldName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DBFieldsBModel");
                });

            modelBuilder.Entity("API.Domain.Entities.DataSet", b =>
                {
                    b.Property<int>("DataSetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DataSetId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DataSetId");

                    b.ToTable("DataSets");
                });

            modelBuilder.Entity("API.Domain.Entities.DetFieldsOfDataSet", b =>
                {
                    b.Property<int>("DetFieldsOfDataSetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetFieldsOfDataSetId"));

                    b.Property<int>("DataSetId")
                        .HasColumnType("int");

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<string>("Filter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilterType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Order")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetFieldsOfDataSetId");

                    b.HasIndex("DataSetId");

                    b.HasIndex("FieldId");

                    b.ToTable("DetFieldsOfDataSet");
                });

            modelBuilder.Entity("API.Domain.Entities.Entity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntityId"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.HasIndex("AreaId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("API.Domain.Entities.Field", b =>
                {
                    b.Property<int>("FieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FieldId"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FieldId");

                    b.HasIndex("EntityId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("API.Domain.Entities.DetFieldsOfDataSet", b =>
                {
                    b.HasOne("API.Domain.Entities.DataSet", "DataSet")
                        .WithMany("DetFieldsOfDataSets")
                        .HasForeignKey("DataSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.Entities.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataSet");

                    b.Navigation("Field");
                });

            modelBuilder.Entity("API.Domain.Entities.Entity", b =>
                {
                    b.HasOne("API.Domain.Entities.Area", "Area")
                        .WithMany("Entities")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("API.Domain.Entities.Field", b =>
                {
                    b.HasOne("API.Domain.Entities.Entity", "Entity")
                        .WithMany("Fields")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entity");
                });

            modelBuilder.Entity("API.Domain.Entities.Area", b =>
                {
                    b.Navigation("Entities");
                });

            modelBuilder.Entity("API.Domain.Entities.DataSet", b =>
                {
                    b.Navigation("DetFieldsOfDataSets");
                });

            modelBuilder.Entity("API.Domain.Entities.Entity", b =>
                {
                    b.Navigation("Fields");
                });
#pragma warning restore 612, 618
        }
    }
}