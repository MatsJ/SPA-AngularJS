using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace oblig3_s198530.Models
{
    public class FAQ
    {
        public int id { get; set; }

        [Required]
        [RegularExpression("/^[a-zæøåA-ZÆØÅ. \\-]{2,30}$/")]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"/^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/")]
        public string email { get; set; }

        [Required]
        [RegularExpression("/^[a-zæøåA-ZÆØÅ. \\-]{2,30}$/")]
        public string category { get; set; }

        public int categoryID { get; set; }

        public string answer { get; set; }

        [Required]
        [RegularExpression("/^[a-zæøåA-ZÆØÅ. \\-]{2,30}$/")]
        public string title { get; set; }

        [Required]
        [RegularExpression("/^[a-zæøåA-ZÆØÅ. \\-]{2,200}$/")]
        public string question { get; set; }

        public int clicks { get; set; }
    }

    public class category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class question
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("/^[a-zæøåA-ZÆØÅ. \\-]{2,30}$/")]
        public string Question { get; set; }

        [Required]
        [RegularExpression("/^[a-zæøåA-ZÆØÅ. \\-]{2,30}$/")]
        public string Category { get; set; }
    }
}