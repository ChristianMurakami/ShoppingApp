using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.Models
{
    public class ItemNCount
    {
        [Key]
        public int Id { set; get; }
        public string ItemName { set; get; }
        public int ItemId { set; get; }
        public string ItemImage { set; get; }
        public decimal Cost { set; get; }
        public int Count { set; get; }
        public int ForeignKey { set; get; }

        public ItemNCount(){}
        public ItemNCount(int itemId,string Name, string image, int count,int foreignKey,decimal cost) 
        {
            ItemId = itemId;
            ItemName = Name;
            ItemImage = image;
            Count = count;
            ForeignKey = foreignKey;
            Cost = cost;
        }
    }
}
