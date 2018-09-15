using System.Collections.Generic;

namespace MasterData
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string CreateDate { get; set; }

        public Trading Trading { get; set; }

        public List<Token> Tokens { get; set; }
    }
}