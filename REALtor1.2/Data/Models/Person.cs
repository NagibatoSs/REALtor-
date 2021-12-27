using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace REALtor1._2.Data.Models
{
    public class Person
    {
        public int? id { get; set; }
        public string Fio { get; set; }
        public string NumberOfPhone { get; set; }
        public string Email { get; set; }
        public string Requirements { get; set; }
        //покупатель или разместитель
        public string Status { get; set; }
        public virtual List<House> Houses { get; set; }
    }
}
