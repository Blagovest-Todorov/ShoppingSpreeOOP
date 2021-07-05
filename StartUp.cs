using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = parts[0];
                string productName = parts[1];

                Person person = people[personName];
                Product product = products[productName];

                try
                {
                    person.AddProduct(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static Dictionary<string, Product> ReadProducts()
        {
            var result = new Dictionary<string, Product>();

            string[] parts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                string[] productData = part
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);
                var product = productData[0];
                var cost = decimal.Parse(productData[1]);

                result[product] = new Product(product, cost);
            }

            return result;
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            var result = new Dictionary<string, Person>();

            string[] parts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                string[] personData = part
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);
                var name = personData[0];
                var money = decimal.Parse(personData[1]);

                result[name] = new Person(name, money);
            }

            return result;
        }
    }
}
