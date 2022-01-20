using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADOExample
{
    class Class1
    {
        public class BaseClass {
    public BaseClass(){ }

    public void foo(){
        Console.WriteLine("Base foo");
    }

    public void callFoo() {
        foo();
    }
}

public class ChildClass : BaseClass {
    public ChildClass(){ }
  
    public new void foo() {
        Console.WriteLine("Child foo");
    }
}
        public static void Main()
        {
// the following code called in another function.
ChildClass cc = new ChildClass();
cc.callFoo();
        }
    }
}
