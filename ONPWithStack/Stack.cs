using System;
using System.Collections.Generic;
using System.Text;

namespace ONPWithStack
{
    public class Stack
    {
        public int Length { get; set; }
        List<char> _stack;
        int _index;
        public Stack()
        {
            _index = 0;
            _stack = new List<char>();
            Length = 0;
        }
        public void Push(char element)
        {
            lock (this)
            {
                _index++;
                Length++;
                _stack.Add(element);
            }
        }
        public char Pop()
        {
            lock(this)
            {
                try
                {
                    Length--;
                    char c = _stack[--_index];
                    _stack.RemoveAt(_index);
                    return c;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Length = 0;
                    _index = 0;
                    return '\0';
                }
            }
        }

    }
}
