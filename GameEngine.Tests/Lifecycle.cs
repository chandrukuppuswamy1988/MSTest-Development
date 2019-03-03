using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
    [TestClass]
    public class Lifecycle
    {

        [ClassInitialize]
        public static void LifecycleClassInitialize(TestContext context)
        {
            Console.WriteLine("  ClassInitialize Lifecycle");
        }

        [ClassCleanup]
        public static void LifecycleClassCleanUp(TestContext context)
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
        }

        [TestMethod]
        public void TestB()
        {
            Console.WriteLine("     Test B Starting");
        }

    }
}
