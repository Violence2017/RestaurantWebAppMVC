using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantWebAppMVC.Models
{
    public partial class DishIngredient
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int IngredientId { get; set; }
        public int Amount { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
