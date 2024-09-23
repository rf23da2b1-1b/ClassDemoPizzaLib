using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoPizzaLib.model
{
    public class Pizza1 : IPizza
    {
        private int _id;
        private string _name;
        private string _description;
        private double _price;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("Pizza name must be at  least 3 characters");
                }
                _name = value;
            }

        }
        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 10)
                {
                    throw new ArgumentException("Pizza description must be at least 10 characters");
                }
                _description = value;
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Pizza price must be over zero");
                }
                _price = value;
            }
        }

        public Pizza1() : this(-1, "dummy", "some text should be here", 1)
        {
        }

        public Pizza1(int id, string name, string description, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Description)}={Description}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
