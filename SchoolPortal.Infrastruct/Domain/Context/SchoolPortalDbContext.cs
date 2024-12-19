using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolPortal.Infrastruct.Domain.Entities;

namespace SchoolPortal.Infrastruct.Domain.Context
{
	public class SchoolPortalDbContext : DbContext
	{
		public SchoolPortalDbContext(DbContextOptions<SchoolPortalDbContext> options) : base(options) { }
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseNpgsql(
		//		"Server=localhost, 5436;Database=SchoolDB;User Id=school_user;Password=school_password");
		//}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SchoolDetail>(entity =>
			{
				entity.ToTable("SchoolDetail");
			});
			modelBuilder.Entity<UserInfo>(entity =>
			{
				entity.ToTable("UserInfo");
			});
			modelBuilder.Entity<UserAddress>(entity =>
			{
				entity.ToTable("UserAddress");
			});
			modelBuilder.Entity<ExamInfo>(entity =>
			{
				entity.ToTable("ExamInfo");
			});
			modelBuilder.Entity<ExamInfoDetail>(entity =>
			{
				entity.ToTable("ExamInfoDetail");
			});
		}

		public DbSet<SchoolDetail> SchoolDetail { get; set; }
		public DbSet<UserInfo> UserInfo { get; set; }
		public DbSet<UserAddress> UserAddress { get; set; }
		public DbSet<ExamInfo> ExamInfo { get; set; }
		public DbSet<ExamInfoDetail> ExamInfoDetail { get; set; }

	}
}
