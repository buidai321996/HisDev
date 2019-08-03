using Datas.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperModules.Datas
{
   public  class DeveloperContext : DbContext
    {
        public DeveloperContext(DbConnection dbConnection):base(dbConnection,true)
        {
            Database.SetInitializer<DeveloperContext>(new CreateDatabaseIfNotExists<DeveloperContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BUIDAI");
            modelBuilder.Entity<Student>().ToTable("StudentInfo");
              
              
           
            // modelBuilder.Entity<Developer>()
            // .Property(e => e.DeveloperName)
            // .IsUnicode(false);
            // modelBuilder.Entity<DeliveryUnit>()
            //.Property(e => e.DeliveryUnitName)
            //.IsUnicode(false);
        }
    }
   
     
}
