using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; } //TODO: Would it be to have a one to many relatioship here?
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime SupposedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; } = null;
    }
}
