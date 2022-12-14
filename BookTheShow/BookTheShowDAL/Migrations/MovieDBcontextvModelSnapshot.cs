// <auto-generated />
using System;
using BookTheShowDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookTheShowDAL.Migrations
{
    [DbContext(typeof(MovieDBcontextv))]
    partial class MovieDBcontextvModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookTheShowEntity.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("BookTheShowEntity.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingQuantity")
                        .HasColumnType("int");

                    b.Property<int>("BookingTotal")
                        .HasColumnType("int");

                    b.Property<int>("UservId")
                        .HasColumnType("int");

                    b.Property<int>("showId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("UservId");

                    b.HasIndex("showId");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("BookTheShowEntity.Moviev", b =>
                {
                    b.Property<int>("MovievId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImgPoster")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("MovieTicketPrice")
                        .HasColumnType("int");

                    b.Property<string>("MovievDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovievName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovievType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovievId");

                    b.ToTable("moviesv");
                });

            modelBuilder.Entity("BookTheShowEntity.ShowTimev", b =>
                {
                    b.Property<int>("ShowvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovievId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShowTimevv")
                        .HasColumnType("datetime2");

                    b.Property<int>("TheatrevId")
                        .HasColumnType("int");

                    b.HasKey("ShowvId");

                    b.HasIndex("MovievId");

                    b.HasIndex("TheatrevId");

                    b.ToTable("showtimingsv");
                });

            modelBuilder.Entity("BookTheShowEntity.Theatrev", b =>
                {
                    b.Property<int>("TheatrevId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TheatrevAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TheatrevComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TheatrevName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TheatrevId");

                    b.ToTable("theatresv");
                });

            modelBuilder.Entity("BookTheShowEntity.Userv", b =>
                {
                    b.Property<int>("UservId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UservEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UservName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UservId");

                    b.ToTable("userv");
                });

            modelBuilder.Entity("BookTheShowEntity.Booking", b =>
                {
                    b.HasOne("BookTheShowEntity.Userv", "userv")
                        .WithMany()
                        .HasForeignKey("UservId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookTheShowEntity.ShowTimev", "showTimev")
                        .WithMany()
                        .HasForeignKey("showId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookTheShowEntity.ShowTimev", b =>
                {
                    b.HasOne("BookTheShowEntity.Moviev", "moviev")
                        .WithMany()
                        .HasForeignKey("MovievId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookTheShowEntity.Theatrev", "theatrev")
                        .WithMany()
                        .HasForeignKey("TheatrevId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
