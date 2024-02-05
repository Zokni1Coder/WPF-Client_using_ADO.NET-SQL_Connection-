using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMNA24Beadando
{
    class korException : Exception
    {
        public korException(int kor)
        {
            Kor = kor;
        }
        public readonly int Kor;
    }
}
