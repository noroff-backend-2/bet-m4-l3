using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Linq;
using mysqlefcore;

namespace DBPopulation
{
    public class Population
    {
        public void PopulateDatabase()
        {
            using (var context = new HardwareStoreContext())
            {
                //Add categories
                var cat1 = new Category { Name = "Hand Tools" };
                context.Category.Add(cat1);
                var cat2 = new Category { Name = "Power Tools" };
                context.Category.Add(cat2);

                //Add suppliers
                var sup1 = new Supplier { Name = "AllTools", Location = "Norway" };
                context.Supplier.Add(sup1);
                var sup2 = new Supplier { Name = "MegaHardware", Location = "USA" };
                context.Supplier.Add(sup2);
                var sup3 = new Supplier { Name = "Construction Co.", Location = "Germany" };
                context.Supplier.Add(sup3);

                //Add brands
                var brand1 = new Brand { Name = "Bosch" };
                context.Brand.Add(brand1);
                var brand2 = new Brand { Name = "Ryobi" };
                context.Brand.Add(brand2);
                var brand3 = new Brand { Name = "Makita" };
                context.Brand.Add(brand3);

                //Adds tools
                context.Tool.Add(new Tool
                {
                    ID = "B123",
                    Name = "Hammer",
                    Price = 80.00,
                    StockQuantity = 5,
                    Brand = brand1,
                    Category = cat1,
                    Supplier = sup1
                });
                context.Tool.Add(new Tool
                {
                    ID = "RY1884",
                    Name = "Hammer",
                    Price = 75.00,
                    StockQuantity = 0,
                    Brand = brand2,
                    Category = cat1,
                    Supplier = sup1
                });
                context.Tool.Add(new Tool
                {
                    ID = "M002435",
                    Name = "Hammer",
                    Price = 90.00,
                    StockQuantity = 50,
                    Brand = brand3,
                    Category = cat1,
                    Supplier = sup3
                });

                context.Tool.Add(new Tool
                {
                    ID = "B546",
                    Name = "Circular Saw",
                    Price = 500.00,
                    StockQuantity = 12,
                    Brand = brand1,
                    Category = cat2,
                    Supplier = sup2
                });
                context.Tool.Add(new Tool
                {
                    ID = "RY2086",
                    Name = "Circular Saw",
                    Price = 320.00,
                    StockQuantity = 16,
                    Brand = brand2,
                    Category = cat2,
                    Supplier = sup3
                });
                context.Tool.Add(new Tool
                {
                    ID = "M003980",
                    Name = "Circular Saw",
                    Price = 750.00,
                    StockQuantity = 3,
                    Brand = brand3,
                    Category = cat2,
                    Supplier = sup2
                });

                context.Tool.Add(new Tool
                {
                    ID = "B357",
                    Name = "Impact Driver",
                    Price = 750.00,
                    StockQuantity = 0,
                    Brand = brand1,
                    Category = cat2,
                    Supplier = sup3
                });
                context.Tool.Add(new Tool
                {
                    ID = "RY1902",
                    Name = "Impact Driver",
                    Price = 480.00,
                    StockQuantity = 25,
                    Brand = brand2,
                    Category = cat2,
                    Supplier = sup3
                });
                context.Tool.Add(new Tool
                {
                    ID = "M005860",
                    Name = "Impact Driver",
                    Price = 810.00,
                    StockQuantity = 3,
                    Brand = brand3,
                    Category = cat2,
                    Supplier = sup1
                });

                //Saves changes
                context.SaveChanges();
            }
        }

    }

}