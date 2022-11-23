using System;
using System.Collections.Generic;
using System.Text;

namespace SkinCare.Model
{
    public class SkinCareItems
    {
        public int ProductID { get; set; }
        public object ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public string RatingDetail { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}
