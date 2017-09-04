namespace DeathValley_by_Alexandr.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    //public partial class ChartDBContext : DbContext
    //{
    //    public ChartDBContext()
    //        : base("name=ChartDB")
    //    {
    //        Database.SetInitializer(new CreateDatabaseIfNotExists<ChartDBContext>());
    //    }


    //    public virtual DbSet<ChartData> ChartData { get; set; }
    //    public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    //    public virtual DbSet<Сoordinates> Сoordinates { get; set; }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<ChartData>()
    //            .Property(e => e.InputData)
    //            .IsUnicode(false);

    //        modelBuilder.Entity<ChartData>()
    //            .HasMany(e => e.Сoordinates)
    //            .WithRequired(e => e.ChartData)
    //            .HasForeignKey(e => e.IdData)
    //            .WillCascadeOnDelete(false);
    //    }
    //}

    //---Singleton--- 

#region Singleton

    public partial class ChartDBContext : DbContext
    {
        private static readonly Lazy<ChartDBContext> instanceHolder =
            new Lazy<ChartDBContext>(() => new ChartDBContext());

        private ChartDBContext()
            : base("name=ChartDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ChartDBContext>());
        }

        public static ChartDBContext Instance
        {
            get { return instanceHolder.Value; }
        }

#endregion

        public virtual DbSet<ChartData> ChartData { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Сoordinates> Сoordinates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChartData>()
                .Property(e => e.InputData)
                .IsUnicode(false);

            modelBuilder.Entity<ChartData>()
                .HasMany(e => e.Сoordinates)
                .WithRequired(e => e.ChartData)
                .HasForeignKey(e => e.IdData)
                .WillCascadeOnDelete(false);
        }
    }

}
