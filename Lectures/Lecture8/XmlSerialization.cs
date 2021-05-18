using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Lecture8
{
    public class XmlSerialization
    {
        private const string OrderFilePath = "products.xml";

        public Order CollectOrder()
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                Status = OrderStatus.Undefined,
                Products = new[]
                {
                    new Product
                    {
                        Category = new Category
                        {
                            Id = Guid.NewGuid(),
                            Description = "Holds cellphones",
                            Name = "Phones",
                        },
                        Description = "iPhone 12 Pro 128GB Graphite",
                        Id = Guid.NewGuid(),
                        Name = "iPhone 12 Pro",
                    },

                    new Product
                    {
                        Category = new Category
                        {
                            Id = Guid.NewGuid(),
                            Description = "Holds laptops",
                            Name = "Phones",
                        },
                        Description = "Apple New MacBook Air M1 13.3'' 256Gb MGN63 Space Grey 2020",
                        Id = Guid.NewGuid(),
                        Name = "MacBook Air M1 13.3",
                    },
                }
            };
        }

        public void SerializeOrder(Order order)
        {
            var serializer = new XmlSerializer(typeof(Order));
            using var file = new FileStream(OrderFilePath, FileMode.Create);

            serializer.Serialize(file, order);
        }

        public Order DeserializeOrder()
        {
            var serializer = new XmlSerializer(typeof(Order));
            var xmlReaderSettings = new XmlReaderSettings
            {
                IgnoreComments = true,
                IgnoreWhitespace = true,
            };

            using var xmlTextReader = XmlReader.Create(Path.Combine(new[] { AppDomain.CurrentDomain.BaseDirectory, OrderFilePath }), xmlReaderSettings); // XmlTextReader.Create() vs new XmlTextReader, implementaion of XmlReader
            xmlTextReader.ReadToDescendant(nameof(Order));

            return (Order)serializer.Deserialize(xmlTextReader);
        }
    }

    public class Product
    {
        [XmlElement("identifier")]
        public Guid Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class Order
    {
        public Guid Id { get; set; }

        public Product[] Products { get; set; } // IEnumerable vs arrays.

        public OrderStatus Status { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Status: {Status}";
        }
    }

    public enum OrderStatus
    {
        [XmlEnum("NoValue")]
        Undefined,

        Cancelled,
        Purchased,
        Delivered,
        Packed,
    }
}