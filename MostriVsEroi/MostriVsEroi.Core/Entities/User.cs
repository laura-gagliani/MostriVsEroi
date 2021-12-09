using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; } = false;

        public List<Eroe> Eroi { get; set; } = new List<Eroe>();

    }
}
