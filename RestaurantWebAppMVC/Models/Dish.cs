using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantWebAppMVC.Models
{
    public partial class Dish
    {
        public Dish()
        {
            DishIngredients = new HashSet<DishIngredient>();
            MenuDishes = new HashSet<MenuDish>();
            OrderDishes = new HashSet<OrderDish>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CookingTime { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<DishIngredient> DishIngredients { get; set; }
        public virtual ICollection<MenuDish> MenuDishes { get; set; }
        public virtual ICollection<OrderDish> OrderDishes { get; set; }
    }
}
