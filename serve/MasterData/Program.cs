using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MasterData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new Trading: ");
                var name = Console.ReadLine();

                var trading = new Trading { Name = name };
                db.Tradings.Add(trading);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = db.Tradings.OrderBy(t => t.Name);

                Console.WriteLine("All tradings in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

    }

    public class BloggingContext : DbContext
    {
        public DbSet<BranchTrade> BranchTrades { get; set; }
        public DbSet<Trading> Tradings { get; set; }
    }
}
