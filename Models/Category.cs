using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace ShoppingApp.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { private set; get; }
        [Display(Name = "Name")]
        [Required]
        public string Name { set; get; }
        public string Description { set; get; }
        public string ImagePath { set; get; }

        public Category() { }
        public Category(int id,string name,string path) 
        {
            Id = id;
            Name = name;
            ImagePath = path;
        }
    }
}
