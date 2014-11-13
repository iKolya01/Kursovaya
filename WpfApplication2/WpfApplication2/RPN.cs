using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication2
{
    class RPN
    {
        public RPN() { }

        private bool isANumber(string value)
        {
            string[] number = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            for (int i = 0; i < 10; i++)
            {
                if (value == number[i])
                    return true;
            }

            return false;
        }

        private string retEndDel(string returnString)
        {
            string result = "";

            result = returnString[returnString.Length - 1].ToString();

            return result;
        }

        public string inPostfix(string IN)
        {
            string result = "";
            string stack = "";

            int length = IN.Length, i = 0;

            while (i < length)
            {
                if (isANumber(IN[i].ToString()))
                {
                    result += IN[i];
                }

                switch (IN[i])
                {
                    case '(':
                        {
                            stack += '(';

                            break;
                        }
                    case ')':
                        {
                            int j = stack.Length - 1;
                            while (stack[j] != '(' && j >= 0)
                            {
                                result += retEndDel(stack);
                                j--;
                                stack = stack.Remove(stack.Length - 1);
                            }
                            stack = stack.Remove(stack.Length - 1);

                            break;
                        }
                    case '+':
                        {
                            stack += "+";

                            break;
                        }
                    case '-':
                        {
                            stack += "-";

                            break;
                        }
                    case '*':
                        {
                            stack += "*";

                            break;
                        }
                    case '/':
                        {
                            stack += "/";

                            break;
                        }
                    case '!':
                        {
                            stack += "!";

                            break;
                        }
                    case '=':
                        {
                            stack += "=";

                            break;
                        }
                    case '<':
                        {
                            stack += "<";

                            break;
                        }
                    case '>':
                        {
                            stack += ">";

                            break;
                        }
                }

                i++;
            }

            for (int j = stack.Length - 1; j >= 0; j--)
            {
                result += stack[j];
            }
                return result;
        }
    }
}
