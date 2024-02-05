using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMNA24Beadando
{
    class userNameFoglalt : Exception
    {
        public userNameFoglalt(string nev)
        {
            this.nev = nev;
        }
        public readonly string nev;
    }
}
