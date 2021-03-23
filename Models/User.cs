using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Models
{
    public class User
    {
        [Key]
        public int Id {private set; get; }
        [Display(Name = "Email")]
        [Required]
        public string Email { set; get; }

        [Display(Name = "Password")]
        [Required]
        public string Password { set; get; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { set; get; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { set; get; }

        [Display(Name = "Favorites")]
        public List<Item> FavoriteItems { set; get; }
        public User() { }
        public User( string email, string password,string firstName, string lastName) 
        {           
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
