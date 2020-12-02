using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantWebAppMVC.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            DishIngredients = new HashSet<DishIngredient>();
        }

        public int Id { get; set; }
        public string Provider { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
