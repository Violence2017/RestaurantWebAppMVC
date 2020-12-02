using System;
using System.Collections.Generic;

#nullable disable

namespace RestaurantWebAppMVC.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDishes = new HashSet<OrderDish>();
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string ClientName { get; set; }
        public string ClientLastname { get; set; }
        public string ClientPhone { get; set; }
        public bool IsCompleted { get; set; }
        public string PaymentMethod { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<OrderDish> OrderDishes { get; set; }
    }
}
