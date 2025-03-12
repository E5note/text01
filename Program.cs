namespace 线性存储和链式存储
{
    //1.定义委托(委托的声明)
    public delegate void GetNumber();  //无参无返回值

    public delegate int Fun(int a, string b);  //有参有返回值

    //事件event


//我们可以定义一个事件，然后订阅事件，触发事件。event可以定义多个方法，可以订阅多个方法。
public class MyClass
{
    public event Action MyEvent; //定义一个事件

    public MyClass()
    {
        MyEvent += MyMethod; //订阅事件
        MyEvent.Invoke(); //触发事件
    }
    public void MyMethod()
    {
        Console.WriteLine("事件触发了");
    }
}

    internal class Program
    {
        static void Main(string[] args)
        {
            //2.实例化委托 - 并将函数存入委托中
            GetNumber funDIv = new GetNumber(SayHello);
            funDIv += SayName;//多播委托 - 委托可以存入多个函数


            //！！！系统定义好的委托！！！

            //无参无返回值的委托
            Action action = SayHello;

            //有返回值的委托
            Func<string> Fun2 = ()=>"Hello World!";

            //可以传n个参数 1-16个
            Action<int, string> action2 = (a, b) => Console.WriteLine(a + b);

            //有返回值 有参数
            Func<string, int,string> func = (a,b)=>"Hello! 我是 " + a + " 今年" + b+ "岁.";  //最后一个跟的是返回值


            Fun fun = ReturnNum;

            //3.调用委托
            funDIv.Invoke();
            fun(10, "Hello");

            Console.WriteLine("--------------   事件   --------------");

            MyClass myclass = new MyClass();

            myclass.MyMethod();
            myclass.MyEvent += SayHello;

            //不能直接调用
            //myclass.MyEvent();

            Func<string> func11 = delegate ()
            {
                return "匿名函数";
            };

            

            Console.WriteLine(func11());
            actionReturnAction()();
        }

        static void SayHello()
        {
            Console.WriteLine("Hello World!");
        }

        static void SayName()
        {
            Console.WriteLine("My name is John.");
        }

        static int ReturnNum(int a, string b)
        {
            Console.WriteLine(a + b);
            return a;
        }

        static string ReturnString(int a, string b)
        {
            Console.WriteLine(a + b);
            return b;
        }

        static Action actionReturnAction()
        {
            Action action = delegate () {
                Console.WriteLine("匿名函数actionReturnAction");
            };
            return action;
        }
    }
    //委托就是装载函数的一个容器
    //可以用委托变量 来存储或传递参数
    //action : 没有返回值，参数提供了0-16个委托给我们
    //Func : 有返回值，参数提供了0-16个委托给我们


    public class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T data)
        {
            this.data = data;
            this.next = null;
        }
    }
}