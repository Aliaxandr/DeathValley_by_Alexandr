using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeathValley_by_Alexandr.Models
{
    //----Factory-------

    public abstract class Entities
    { }
    public abstract class Creators
    {
        public abstract Entities CreateEntity();
    }

    public class ChartDataCreator:Creators
    {
        public override Entities CreateEntity()
        {
            return new ChartData();
        }
    }

    public class CoordinateCreator:Creators
    {
        public override Entities CreateEntity()
        {
            return new Сoordinates();
        }
    }
}