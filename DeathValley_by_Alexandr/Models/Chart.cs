using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DeathValley_by_Alexandr.Models
{
    public class Chart
    {

        public List<Point> XY(string a, string b, string c, string step, string x1, string x2)
        {
            try
            {
                int A, B, C;
                if (string.IsNullOrEmpty(a)) A = 1;
                else A = int.Parse(a);
                if (string.IsNullOrEmpty(b)) B = 1;
                else B = int.Parse(b);
                if (string.IsNullOrEmpty(c)) C = 0;
                else C = int.Parse(c);
                int Step = int.Parse(step);
                if (Step <= 0)
                    throw new Exception("Error! The step value can not be negative or equal to zero.");
                int X1 = int.Parse(x1);
                int X2 = int.Parse(x2);
                if (X1 >= X2)
                    throw new Exception("Error! The value of X1 can not be greater than or equal to the value of X2");
                List<Point> data = new List<Point>();
                for (int i = X1; i <= X2; i += Step)
                {
                    data.Add(new Point {X = i, Y = (A * i * i + B * i + C)});
                }
                return data;
            }
            catch (FormatException)
            {
                throw new FormatException("Error! All numbers must be integers.");
            }



        }

        
        
    }
}