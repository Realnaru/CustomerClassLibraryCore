using CustomerClassLibraryCore.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerClassLibraryCore.Data.EFData
{
    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext() : base()       
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-QTLFNRNOL1C\\SQL2019;Database=customer_lib_Opishniak_R;Trusted_Connection=True;");
            //"Server=GUS1WS-00202\\SQLEXPRESS;"
            //Server=WIN-QTLFNRNOL1C\\SQL2019
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> AdressesList { get; set; }

        public DbSet<CustomerNote> Note { get; set; }
    }
}
