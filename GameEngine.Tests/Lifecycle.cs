using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
    [TestClass]
    public class Lifecycle
    {
        static string SomeTestContext; // for simplicity we use string this might be some complex object whc is ver expensive to create

        [ClassInitialize]
        public static void LifecycleClassInitialize(TestContext context)
        {
            Console.WriteLine("  ClassInitialize Lifecycle");

            Console.WriteLine("  data loaded from disk or from expensive object");
            SomeTestContext = "42";

        }

        [ClassCleanup]
        public static void LifecycleClassCleanUp()
        {
            Console.WriteLine("  ClassCleanup Lifecycle");
        }

        [TestInitialize]
        public void LifecycleInit()
        {
            Console.WriteLine("  TestInitialize Lifecycle");
        }

        [TestCleanup]
        public void LifecycleClean()
        {
            Console.WriteLine("  TestCleanup Lifecycle");
        }


        [TestMethod]
        public void TestA()
        {
            Console.WriteLine("     Test A Starting");
            Console.WriteLine($"     Shared Test Context ${SomeTestContext}");
        }

        [TestMethod]
        public void TestB()
        {
            Console.WriteLine("     Test B Starting");
        }

    }
}
