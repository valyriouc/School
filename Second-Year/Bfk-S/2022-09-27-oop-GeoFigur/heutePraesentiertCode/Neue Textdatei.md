using System;

namespace Test

{

    class Program

    {

        static void Main(string[] args)

        {

            C c1 = new C();

            Console.WriteLine("Hello World!");

        }

    }

    class A

    {

        public A()

        {

        }

        public A(int i)

        {

        }

    }

    class B : A

    {

        public B()

        {

        }

        public B(int i)

        { }

    }

     

    class C : B

    {

        public C()

        { }

        public C(int i)

        { }

    }

}