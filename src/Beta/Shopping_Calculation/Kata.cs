using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codewars.Beta.Shopping_Calculation
{
    public class Kata
    {
        private class Product
        {
            public Product(string input)
            {
                var match = Regex.Match(input, @"^(?<product>.*)( is \$)(?<price>\d+)\.$");
                if (!match.Success)
                    throw new ArgumentException("Input does not match the expected pattern", nameof(input));

                Name = match.Groups["product"].Value.ToLower();
                Price = int.Parse(match.Groups["price"].Value);
            }

            public string Name { get; }

            public int Price { get; }

            public static bool operator ==(Product product, string productName)
            {
                if (product is null)
                    return false;

                return product.Name == productName || product.Name + "s" == productName;
            }

            public static bool operator !=(Product product, string productName)
            {
                return !(product == productName);
            }
        }

        private class Person
        {
            public Person(string input)
            {
                var match = Regex.Match(input, @"^(?<person>.*)( has \$)(?<money>\d+)\.$");
                if (!match.Success)
                    throw new ArgumentException("Input does not match the expected pattern", nameof(input));

                Name = match.Groups["person"].Value;
                Money = int.Parse(match.Groups["money"].Value);
            }

            public string Name { get; }
            public int Money { get; }
        }

        private class Purchase
        {
            public Purchase(string input)
            {
                var match = Regex.Match(input, @"^(?<person>.*)( buys )(?<amount>\d+) (?<product>.*)\.$");
                if (!match.Success)
                    throw new ArgumentException("Input does not match the expected pattern", nameof(input));

                Person = match.Groups["person"].Value;
                Amount = int.Parse(match.Groups["amount"].Value);
                Product = match.Groups["product"].Value;
            }

            public string Person { get; }
            public int Amount { get; }
            public string Product { get; }

            public override string ToString()
            {
                return $"{Amount} {Product}";
            }
        }

        public static List<(string, string, string)> ShoppingCalculation(List<string> input)
        {
            var products = input
                .Where(i => i.Contains(" is "))
                .Select(i => new Product(i))
                .ToList();

            var people = input
                .Where(i => i.Contains(" has "))
                .Select(i => new Person(i))
                .ToList();

            var purchases = input
                .Where(i => i.Contains(" buys "))
                .Select(i => new Purchase(i))
                .ToList();

            var result = new List<(string, string, string)>();

            foreach (var person in people)
            {
                var purchasesOfPerson = purchases.Where(p => p.Person == person.Name).ToList();
                var amountOfPurchase = purchasesOfPerson.Sum(purchase => products.Single(p => p == purchase.Product).Price * purchase.Amount);
                var purchasesString = string.Join(", ", purchasesOfPerson.Select(x => x.ToString()));
                result.Add(new ValueTuple<string, string, string>(person.Name, $"${person.Money - amountOfPurchase}", purchasesString));
            }

            return result;
        }
    }

    [TestFixture]
    public class ShoppingCalculationTest
    {

        [Test]
        public void test1()
        {
            //Arrange 
            var input = new List<string>()
            {
                "Apple is $5.",
                "Banana is $7.",
                "Orange is $2.",
                "Alice has $26.",
                "John has $41.",
                "Alice buys 2 apples.",
                "John buys 1 banana.",
                "Alice buys 5 oranges."
            };

            var expectedResult = new List<(string, string, string)>()
            {
                ("Alice", "$6", "2 apples, 5 oranges"),
                ("John", "$34", "1 banana")
            };

            //Act
            var actualResult = Kata.ShoppingCalculation(input);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void test2()
        {
            //Arrange 
            var input = new List<string>()
            {
                "Chocolate is $15.",
                "George has $100.",
                "Ross has $80.",
                "George buys 5 chocolates.",
                "Ross buys 1 chocolate.",
            };

            var expectedResult = new List<(string, string, string)>()
            {
                ("George", "$25", "5 chocolates"),
                ("Ross", "$65", "1 chocolate")
            };

            //Act
            var actualResult = Kata.ShoppingCalculation(input);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void test3()
        {
            //Arrange 
            var input = new List<string>()
            {
                "Carrot is $1.",
                "Watermelon is $5.",
                "Lemon is $2.",
                "Steve has $10.",
                "Jim has $800.",
                "Steve buys 7 carrots.",
                "Jim buys 2 watermelons.",
                "Jim buys 1 carrot.",
            };

            var expectedResult = new List<(string, string, string)>()
            {
                ("Steve", "$3", "7 carrots"),
                ("Jim", "$789", "2 watermelons, 1 carrot")
            };

            //Act
            var actualResult = Kata.ShoppingCalculation(input);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void test4()
        {
            //Arrange 
            var input = new List<string>()
            {
                "Carrot is $1.",
                "Jim has $10.",
                "Lemon is $2.",
                "Steve has $80.",
                "Steve buys 7 carrots.",
                "Jim buys 2 lemons.",
            };

            var expectedResult = new List<(string, string, string)>()
            {
                ("Jim", "$6", "2 lemons"),
                ("Steve", "$73", "7 carrots"),
            };

            //Act
            var actualResult = Kata.ShoppingCalculation(input);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void test5()
        {
            //Arrange 
            var input = new List<string>()
            {
                "Apple is $5.",
                "Banana is $7.",
                "Orange is $2.",
                "Lisa has $26.",
                "Arthas has $41.",
                "Lisa buys 2 apples.",
                "Arthas buys 1 banana.",
                "Lisa buys 5 oranges.",
            };

            var expectedResult = new List<(string, string, string)>()
            {
                ("Lisa", "$6", "2 apples, 5 oranges"),
                ("Arthas", "$34", "1 banana"),
            };

            //Act
            var actualResult = Kata.ShoppingCalculation(input);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}