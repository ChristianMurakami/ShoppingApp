using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Models
{
    public class Item
    {  
        [Key]
        [Display(Name ="Id")]
        public int Id { private set; get; }

        [Display(Name = "Name")]
        [Editable(false)]
        public string Name {set;get;}

        [Display(Name = "Cost")]
        [Editable(false)]
        public decimal Cost { set; get; }      
        public int CategoryId { set; get; }
        public string ImagePath { set; get; }
        public string Description { set; get; }
        public Item(int id, string name, decimal cost) 
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}
