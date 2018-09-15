using TradingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TradingService.Services
{
    public class ClassService : IClassService
    {

        public ClassService()
        {

        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string Get(int id)
        {
            var model = "test";

            return model;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
