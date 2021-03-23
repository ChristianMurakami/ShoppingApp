using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class Order
    {
        [Key]
        [Display(Name = "Order Id")]
        [Editable(false)]
        public int Id { private set; get; }            
        [Display(Name = "Date")]
        [Editable(false)]
        public DateTime DateSubMitted { set; get; } 
        [Display(Name = "Tax")]
        [Editable(false)]
        public decimal Tax { set; get; }
        [Display(Name = "Subtotal")]
        [Editable(false)]
        public decimal Subtotal {set; get; }
        [Display(Name = "Total")]
        [Editable(false)]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal Total {set; get; }
        public Order(decimal tax) 
        {
            Tax = tax;          
        }
        public List<ItemNCount> Items = new List<ItemNCount>();
        public decimal total(decimal sub, decimal tax)
        {
            decimal total = sub += (sub * tax);
            return total;
        }
        public decimal subtotal(List<ItemNCount> ItemsNCounts)
        {
            decimal sub = 0;
            foreach (ItemNCount t in ItemsNCounts)
            {
                sub += t.Cost * t.Count;
            }
            return sub;
        }
    }
}
