using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace REALtor1._2.Data.Models
{
    public class House
    {
        public int? id { get; set; }
        public string CodeWord { get; set; }
        public bool coldWater { get; set; }
        public bool hotWater { get; set; }
        public bool electricity { get; set; }
        public bool gas { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? CountOfRooms { get; set; }
        public string Img { get; set; }
        public ulong? Price { get; set; }
        //район
        public string Area { get; set; }
        //новстройка, хрущевка, застройка...
        public string StatusOfHome { get; set; }
        //Площадь
        public double? Square { get; set; }
        public string Despription { get; set; }
        public bool Available { get; set; }

        public virtual Person Seller { get; set; }
    }
}
