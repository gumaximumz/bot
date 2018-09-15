
using System;
using System.Collections.Generic;
using System.Text;

namespace TradingService.Interfaces
{
    public interface IClassService
    {
        void Create();

        void Update();

        void Delete(int id);

        string Get(int id);
    }
}
