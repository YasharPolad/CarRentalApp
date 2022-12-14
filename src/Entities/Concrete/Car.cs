using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; } //Price per day
        public string Description { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Color Color { get; set; }
        public Brand Brand { get; set; }

    }
}
