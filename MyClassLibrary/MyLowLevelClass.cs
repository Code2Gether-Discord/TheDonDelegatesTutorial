using System;
using System.ComponentModel;

namespace MyClassLibrary
{
    // No longer needed.
    public delegate void MyDelegate(int number1, int number2);

    public class MyLowLevelClass
    {
        #region Delegates
        // We no longer need this.
        public event MyDelegate MyDelegate;

        // same as MyDelegate, no declaration needed.
        public event Action<int, int> MyAction;

        // same as: delegate long Func(int a, int b)
        public event Func<int, int, long> MyFunc;

        // Correct way of using events.
        // same as: delegate void EventHandler(object sender, TwoNumberEventArgs eventArgs)
        public event EventHandler<TwoNumbersEventArgs> MyEvent;
        #endregion

        #region Methods
        public void callDelegate()
        {
            MyDelegate?.Invoke(2, 3);

            var funcResult = MyFunc?.Invoke(4, 5);

            // Returns no result.
            MyAction?.Invoke(32, 44);

            MyEvent?.Invoke(this, new TwoNumbersEventArgs(44, 55));
        }
        #endregion
    }
}
