using System;
using System.Collections.Generic;

namespace MasterData
{
    public class Trading
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual List<TradingBranchTrade> BranchTrades { get; set; }
    }
}