using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDotnetFrameworkData
{
    public class MasterContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BranchTrade> BranchTrades { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<TradeLog> TradeLogs { get; set; }
        public DbSet<Trading> Tradings { get; set; }
        public DbSet<TradingBranchTrade> TradingBranchTrades { get; set; }
    }
}
