using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassDemoPizzaLib.model
{
    public class Pizza2:IPizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }


        public Pizza2() : this(-1, "dummy", "some text should be here", 1)
        {
        }

        public Pizza2(int id, string name, string description, double price)
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

        public static bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new ArgumentException("Pizza name must be at least 3 characters");
            }
            return true ;
        }

        public static bool ValidateDescription(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc) || desc.Length < 10)
            {
                throw new ArgumentException("Pizza description must be at  least 10 characters");
            }
            return true;
        }

        public static bool ValidatePrice(double price)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Pizza price must be over zero");
            }
            return true;
        }

        public bool Validate()
        {
            ValidateName(Name);
            ValidateDescription(Description);
            ValidatePrice(Price);

            return true;
        }
    }
}
