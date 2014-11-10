using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2
{
    class TestChek
    {
        RPN newRPN = new RPN();

        public TestChek() { }

        public bool getChek(string Etal, string User)
        {
            string EtalRPN = newRPN.inPostfix(Etal);
            string UserRPN = newRPN.inPostfix(User);

            if (EtalRPN == UserRPN)
                return true;

            return false;
        }
    }
}
