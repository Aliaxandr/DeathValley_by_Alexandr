using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using DeathValley_by_Alexandr.Models;

using System.Web.Mvc;
using Newtonsoft.Json;


namespace DeathValley_by_Alexandr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        public JsonResult DrawChart(string a, string b, string c, string step, string x1, string x2)
        {


            Chart chart=new Chart();
            JsonResult response = null;
            List<Point> data=new List<Point>();
            try
            {
                data = GetData(a + b + c + step + x1 + x2);
                if (data.Count==0)
                {
                    data = chart.XY(a, b, c, step, x1, x2);
                    AddNewItemDB(data, a+b+c+step+x1+x2);
                }
                
                return Json(new {Countries = data}, JsonRequestBehavior.AllowGet);
            }
            

            catch (Exception e)
            {
                response = Json(new { er = e.Message }, JsonRequestBehavior.AllowGet);
                return response;
            }


        }


        List<Point> GetData(string data)
        {
            //ChartDBContext context=new ChartDBContext();
            ChartDBContext context=ChartDBContext.Instance;
            List<Point> points = new List<Point>();
            var getId = GetId(data);
            if (getId != null)
            {
                int id = 0;
                foreach (int item in getId)
                {
                    id = item;
                }
                var items = from c in context.Сoordinates
                    where c.IdData == id
                    select new
                    {
                        X = c.X,
                        Y = c.Y
                    };
               
                foreach (var item in items)
                {
                    points.Add(new Point {X = item.X, Y = item.Y});
                }
                return points;
            }
            return points;
        }

        private static IQueryable<int> GetId(string data)
        {
            //ChartDBContext context=new ChartDBContext();
            ChartDBContext context = ChartDBContext.Instance;
            var getId = context.ChartData.Where(s => s.InputData.Equals(data)).Select(i => i.Id);
            return getId;
        }

        void AddNewItemDB(List<Point> points, string data)
        {
            //ChartDBContext context=new ChartDBContext();
            ChartDBContext context = ChartDBContext.Instance;
            //ChartData chartData = new ChartData {InputData = data};
            Creators creators=new ChartDataCreator();
            ChartData chartData = (ChartData) creators.CreateEntity();
            chartData.InputData = data;
            context.ChartData.Add(chartData);
            context.SaveChanges();
            int id = 0;
            foreach (var item in GetId(data))
            {
                id = item;
            }

            Creators creator =new CoordinateCreator();

            foreach (var item in points)
            {
                //Сoordinates coordinates = new Сoordinates();
                Сoordinates coordinates = (Сoordinates) creator.CreateEntity();
                coordinates.IdData = id;
                coordinates.X = item.X;
                coordinates.Y = item.Y;
                context.Сoordinates.Add(coordinates);
            }
            context.SaveChanges();
        }
       
       
    }
}