using System;
using System.Collections.Generic;

namespace MasterDotnetFrameworkData
{
    public class BranchTrade
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public string CoinName { get; set; }

        public int TradingId { get; set; }

        public virtual List<TradingBranchTrade> Trading { get; set; }
    }
}