using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test345
{
    class Cards
    {
        public int Value { get; set; }
        public int Suit { get; set; }

        public Cards(int value, int suit)
        {
            Value = value;
            Suit = suit;
        }
    }

}
