using System;
using System.Collections.Generic;
using DeathValley_by_Alexandr.Controllers;
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

        [TestMethod]
        public void TestCheckDB()
        {
            Random rand=new Random();
            string a = rand.Next(-10, 10).ToString();
            string b = rand.Next(-10, 10).ToString();
            string c = rand.Next(-10, 10).ToString();
            string step = "1";
            string x1 = "-3";
            string x2 = "3";

            HomeController controller=new HomeController();

            List<Point> points=new List<Point>();

            points = controller.GetData(a + b + c + step + x1 + x2);

            Assert.IsTrue(points.Count == 0);

            controller.DrawChart(a, b, c, step, x1, x2);

            points = controller.GetData(a + b + c + step + x1 + x2);

            Assert.IsTrue(points.Count > 0);
        }

    }
}
