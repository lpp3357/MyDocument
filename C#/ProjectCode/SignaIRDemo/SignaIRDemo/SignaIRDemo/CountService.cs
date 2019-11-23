using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignaIRDemo
{
    public class CountService
    {
        private int _count = 0;

        public int GetLatestCount()
        {
            return _count++;
        }
    }
}
