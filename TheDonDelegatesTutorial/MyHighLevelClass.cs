using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDonDelegatesTutorial
{
    public class MyHighLevelClass
    {
        public MyLowLevelClass lowLevelClass { get; set; }

        #region Constructor
        public MyHighLevelClass()
        {
            lowLevelClass = new MyLowLevelClass();

            // Method Handlers
            lowLevelClass.MyFunc += AddValue;
            lowLevelClass.MyAction += MultiplyValue;

            // Anonymous Delegates
            lowLevelClass.MyFunc += delegate(int a, int b) 
            {
                return a + b;
            };

            lowLevelClass.MyAction += delegate(int a, int b)
            {
                Console.WriteLine(a * b);
            };

            // Lambdas
            lowLevelClass.MyFunc += (a, b) => a + b; // No "return" needed.
            lowLevelClass.MyAction += (a, b) => Console.WriteLine(a + b);

            // All the previous handlers do the exact same thing.

            // Event w/ EventHandler
            lowLevelClass.MyEvent += LowLevelClass_MyEvent;

            // Only a non-event delegate can do this. Events won't allow this.
            // lowLevelClass.MyDel?.Invoke(4, 5);

            // Telling my lower-level class to invoke the events.
            lowLevelClass.callDelegate();
        }
        #endregion

        #region Methods
        public static long AddValue(int a, int b)
        {
            Console.WriteLine(a + b);
            return a + b;
        }

        public static void MultiplyValue(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        private void LowLevelClass_MyEvent(object sender, TwoNumbersEventArgs e)
        {
            // Do something here.
        }
        #endregion
    }
}
