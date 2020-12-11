using System;

namespace MyClassLibrary
{
    public class TwoNumbersEventArgs : EventArgs
    {
        public int a { get; }
        public int b { get; }

        public TwoNumbersEventArgs(int aInput, int bInput)
        {
            this.a = aInput;
            this.b = bInput;
        }
    }
}
