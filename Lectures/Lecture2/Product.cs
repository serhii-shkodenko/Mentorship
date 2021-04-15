using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2
{
    public class Product : Entity
    {
        static string ActionName { get; set; }

        public string Name { get; set; }

        static Product()
        {
            ActionName = "Value";
        }

        public Product(int id) : base(id)
        {

        }

        public override decimal GetFullPrice()
        {
            var value = base.GetFullPrice();
            return value + 20;
        }
    }

    public class Entity
    {
        public int Id { get; set; }

        public Entity(int id)
        {
            Id = id;
        }

        public virtual decimal GetFullPrice()
        {
            return 10;
        }
    }

    public class Store
    {
        public void PrintProduct()
        {
            var product = new Product(20);
            
            
        }
    }

    public abstract class PersonAbstract
    {
        public string Name { get; set; }

        public abstract string GetFullname();

        public PersonAbstract(int id)
        {

        }
    }

    public class PersonDerived : PersonAbstract
    {
        public PersonDerived(int id) : base(id)
        {
        }

        public override string GetFullname()
        {
            throw new NotImplementedException();
        }

        public string ReturnValue(ProductType productType)
        {
            return productType switch
            {
                ProductType.None => throw new NotImplementedException(),
                ProductType.Computer => throw new NotImplementedException(),
                ProductType.Tv => throw new NotImplementedException(),
            };
        }
    }

}
