namespace OnlineTicariOtomasyon.Models.Classes
{
    using Glimpse.Core.Setting;
    using Microsoft.EntityFrameworkCore;
    using OnlineTicariOtomasyon.Models.Classes;
    
    public class Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information).UseLazyLoadingProxies().UseSqlServer("Server =ERHAN-KESKIN; Database=deneme3; User=sa; Password =erhankeskin61");
           
            
        }
      


        public DbSet<Admin> Admins { get; set; }

        public DbSet<Bill_Item> Bill_Items { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Current> Currents { get; set; 
        }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
       
       
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesActivity> SalesActivities { get; set; }
      
         
        

    }
     
}
