using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace mid.Models
{
    public class Calculation
    {

        [Key]
        public long id { get; set; }

        public String decision { get; set; }
         
        public DateTime dateTime { get; set; }
    }
}
