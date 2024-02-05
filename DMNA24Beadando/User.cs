using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMNA24Beadando
{
    public class User
    {
        private string nev;
        private string kod;
        public bool adminE;

        public User(string nev, string kod, bool adminE)
        {
            this.nev = nev;
            this.kod = kod;
            this.adminE = adminE;
        }
    }
}
