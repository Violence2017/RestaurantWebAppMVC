using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantWebAppMVC.Models
{
    public partial class Menu
    {
        public Menu()
        {
            MenuDishes = new HashSet<MenuDish>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MenuDish> MenuDishes { get; set; }
    }
}
