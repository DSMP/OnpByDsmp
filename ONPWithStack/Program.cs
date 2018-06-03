using System;
using System.Collections.Generic;

namespace ONPWithStack
{
    class Program
    {
        static List<char> _output;
        static void Main(string[] args)
        {
            _output = new List<char>();
            Console.Write("Podaje poprawne wyrażenie: ");
            //string input = Console.ReadLine();
            string input = "((2*5+1)/2)=";
            if (input[input.Length-1] != '=')
            {
                input += '=';
            }
            NormalToONP(input);
            Console.Write("Output: ");
            foreach (var item in _output)
            {
                Console.Write(item + " ");
            }

        }
        static public void NormalToONP(string normalArg)
        {
            Stack OnpStack = new Stack();
            foreach (char item in normalArg.ToCharArray())
            {
                if (item == '(' || _isOperator(item))
                {
                    char onStack = OnpStack.Pop();
                    if (onStack != '\0')
                    {
                        if ((item == '*' || item == '/') && (onStack == '+' || onStack == '-') ||
                            (item == '^') && (onStack == '+' || onStack == '-' || onStack == '*' || onStack == '/'))
                        {
                            _output.Add(item);
                            continue;
                        }
                        OnpStack.Push(onStack);
                        if ((item == '+' || item == '-') && (onStack == '*' || onStack == '/'))
                        {
                            _output.Add(OnpStack.Pop());
                            OnpStack.Push(item);
                            continue;
                        }
                    }
                    OnpStack.Push(item);
                    continue;
                }
                if (_isNumeric(item))
                {
                    _output.Add(item);
                }
                if (item == ')')
                {
                    char c;
                    while ((c = OnpStack.Pop()) != '(')
                    {
                        _output.Add(c);
                    }
                }
                if (item == '=')
                {
                    while (OnpStack.Length > 0)
                    {
                        _output.Add(OnpStack.Pop());
                    }
                }
            }
        }

        private static bool _isOperator(char item)
        {
            if (item == '+' || item == '-' || item == '*' || item == '/')
            {
                return true;
            }
            return false;
        }

        private static bool _isNumeric(char item)
        {
            try
            {
                var numnber = Convert.ToInt32(item);
                if (item == '=' || item == ')')
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
