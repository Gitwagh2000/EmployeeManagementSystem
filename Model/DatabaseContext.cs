using Microsoft.EntityFrameworkCore;

namespace Employee_Management_Application.Model
{
    public partial class DatabaseContext : DbContext
    {
       // private readonly string Constr = "";

        //public DatabaseContext()
        //{
        //    Constr = ConnectionClass.connectionString;
        //}

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpID);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

           // OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
