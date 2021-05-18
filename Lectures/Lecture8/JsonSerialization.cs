using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lecture8
{
    public class JsonSerialization
    {
        private const string OrderFilePathJson = "products.json";

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

        public void SerializeAndSaveOrder(Order order)
        {
            var serialized = JsonSerializer.Serialize(order);

            using var file = new FileStream(OrderFilePathJson, FileMode.Create);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.Write(serialized);

            Console.WriteLine(serialized);
        }

        public Order DeserializeOrderFromSaved()
        {
            using var file = new FileStream(OrderFilePathJson, FileMode.Open);
            using var stream = new StreamReader(file, Encoding.UTF8);

            var order = stream.ReadToEnd();

            return JsonSerializer.Deserialize<Order>(order);
        }

        public class Product
        {
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

            public IEnumerable<Product> Products { get; set; } // IEnumerable vs arrays.

            public OrderStatus Status { get; set; }

            public override string ToString()
            {
                return $"Id: {Id}, Status: {Status}";
            }
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum OrderStatus
        {
            Undefined,

            Cancelled,
            Purchased,
            Delivered,
            Packed,
        }
    }
}