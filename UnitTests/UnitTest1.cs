using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeathValley_by_Alexandr.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSingleton()
        {
            
            ChartDBContext context1=ChartDBContext.Instance;
            ChartDBContext context2=ChartDBContext.Instance;

            Assert.AreEqual(context1, context2);

        }

        [TestMethod]
        public void TestFactory()
        {

            Creators creator1=new ChartDataCreator();
            Creators creator2=new CoordinateCreator();

            Entities entity1 = creator1.CreateEntity();
            Entities entity2 = creator2.CreateEntity();

            Assert.AreEqual(entity1.GetType(), typeof(ChartData));
            Assert.AreEqual(entity2.GetType(), typeof(Сoordinates));

        }

    }
}
