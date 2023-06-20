using AutoMapper.Execution;
using BusinessObject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository
{
    public class GameStoreContext : IdentityDbContext<User>
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<GameKey> GameKeys { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UserFavoriteGame>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GameId })
                   .HasName("PK_UserGame_Favorite");

           

                entity.HasOne(d => d.User)
          .WithMany(p => p.FavoriteGames)
          .HasForeignKey(d => d.UserId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_User_Games");

                entity.HasOne(d => d.Game)
          .WithMany(p => p.FavoriteUsers)
          .HasForeignKey(d => d.GameId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Games_User");
            });
                modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.GameId })
                    .HasName("PK_Order_Details");

                entity.HasOne(d => d.Order)
             .WithMany(p => p.OrderDetails)
             .HasForeignKey(d => d.OrderId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_Order_Details_Orders");
                entity.HasOne(d => d.Game)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Games");
            });

            modelBuilder.Entity<GameKey>()
     .HasKey(c => new { c.GameId, c.Code });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.User)
           .WithMany(p => p.Orders)
           .HasForeignKey(d => d.UserId)
           .HasConstraintName("FK_Orders_Customers");

            });

        }
    }
}
