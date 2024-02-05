using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMNA24Beadando
{
    class rajtszamORNevException : Exception
    {
        public rajtszamORNevException(string value, int which)
        {
            this.which = which;
            switch (which)
            {
                case 1:
                    kiiras = $"A rajtszám ({value}) már foglalt!";
                   
                    break;
                case 2:
                    kiiras = $"A név ({value}) már foglalt!";
                    break;
                case 3:
                    kiiras = $"A rajtszámnak ({value}) [1-99] intervallumban kell lennie!";
                    break;
                default:
                    break;
            }
        }
        public readonly string kiiras;
        public readonly int which;
    }
}
