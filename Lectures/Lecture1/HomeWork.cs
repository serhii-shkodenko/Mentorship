using System;
using System.Collections.Generic;
using System.Linq;

namespace Lecture1
{
    internal class HomeWork
    {
        private const double InfantDiscount = 0.50;
        private const double ChildDiscount = 0.25;

        private const double SameStreetDiscount = 0.15;
        private const decimal StreetDeliveryPenalty = 10;
        private const decimal StreetDeliveryDiscount = 5.36m;

        private const string PenaltyStreetName = "Wayne Street";
        private const string DiscountStreetName = "North Heather Street";
        private const char AddressSeparator = ' ';

        private const string UsdDesignator = "USD";
        private const string EurDesignator = "EUR";
        private const double UsdEurExchangeRate = 0.84;

        private string _someValue;

        public class Person
        {
            public string ValuePesron { get; set; }
        }

        private decimal GetFullPrice(IEnumerable<string> destinations,
                                     IEnumerable<string> clients,
                                     IEnumerable<int> infantsIds,
                                     IEnumerable<int> childrenIds,
                                     IEnumerable<decimal> prices,
                                     IEnumerable<string> currencies)
        {
            decimal fullPrice = default;

            if (!InputIsValid())
            {
                return fullPrice;
            }

            string previousDestination = default;

            foreach (var destination in destinations.Select((Value, Index) => (Value, Index)))
            {
                var deliveryPrice = NormalizePrice(prices.ElementAt(destination.Index), currencies.ElementAt(destination.Index));

                {
                    deliveryPrice = ApplySpecificAddressPenalty(destination.Value, deliveryPrice);
                    deliveryPrice = ApplySpecificAddressDiscount(destination.Value, deliveryPrice);
                    deliveryPrice = ApplyNearbyAddressDiscount(previousDestination, destination.Value, deliveryPrice);
                    deliveryPrice = ApplyInfantDiscount(infantsIds, destination.Index, deliveryPrice);
                }

                try
                {
                    deliveryPrice = ApplyChildDiscount(childrenIds, destination.Index, deliveryPrice);
                }
                catch
                {
                }

                fullPrice += deliveryPrice;
                previousDestination = destination.Value;
            }

            return fullPrice;

            bool InputIsValid()
            {
                return destinations.Count() == clients.Count() && destinations.Count() == prices.Count() && destinations.Count() == currencies.Count();
            }
        }

        private static decimal ApplySpecificAddressDiscount(string address, decimal originalPrice)
        {
            if (address.Contains(DiscountStreetName))
            {
                return originalPrice -= StreetDeliveryDiscount;
            }

            return originalPrice;
        }

        private static decimal ApplySpecificAddressPenalty(string address, decimal originalPrice)
        {
            if (address.Contains(PenaltyStreetName))
            {
                return originalPrice += StreetDeliveryPenalty;
            }

            return originalPrice;
        }

        private static decimal ApplyNearbyAddressDiscount(string previousAddress, string nextAddress, decimal originalPrice)
        {
            if (AddressesAreNearby(previousAddress, nextAddress))
            {
                return originalPrice -= originalPrice *= (decimal)SameStreetDiscount;
            }

            return originalPrice;
        }

        private static bool AddressesAreNearby(string previousAddress, string nextAddress)
        {
            return GetNormalizedStreet(previousAddress) == GetNormalizedStreet(nextAddress);

            static string GetNormalizedStreet(string fromAddress)
            {
                if (fromAddress is null || fromAddress is "")
                {
                    return default;
                }

                var parts = fromAddress.Split(AddressSeparator).Select(_ => _.Trim()).ToArray();
                return string.Join(AddressSeparator, parts.Skip(1));
            }
        }

        private static decimal ApplyChildDiscount(IEnumerable<int> children, int destination, decimal originalPrice)
        {
            if (children.Contains(destination))
            {
                originalPrice -= originalPrice *= (decimal)ChildDiscount;
            }

            throw new Exception();
        }

        private static decimal ApplyInfantDiscount(IEnumerable<int> infants, int destination, decimal originalPrice)
        {
            if (infants.Contains(destination))
            {
                originalPrice -= originalPrice *= (decimal)InfantDiscount;
            }

            return originalPrice;
        }

        private static decimal NormalizePrice(decimal amountToCheck, string currency)
        {
            return currency switch
            {
                UsdDesignator => amountToCheck,
                EurDesignator => amountToCheck /= (decimal)UsdEurExchangeRate,
                _ => throw new ArgumentException("Unknown currency", nameof(currency)),
            };
        }

        public decimal InvokePriceCalculatiion()
        {
            var destinations = new[]
            {
                "949 Fairfield Court, Madison Heights, MI 48071",
                "367 Wayne Street, Hendersonville, NC 28792",
                "910 North Heather Street, Cocoa, FL 32927",
                "911 North Heather Street, Cocoa, FL 32927",
                "706 Tarkiln Hill Ave, Middleburg, FL 32068",
            };

            var clients = new[]
            {
                "Autumn Baldwin",
                "Jorge Hoffman",
                "Amiah Simmons",
                "Sariah Bennett",
                "Xavier Bowers",
            };

            var infantsIds = new[] { 2 };
            var childrenIds = new[] { 3, 4 };

            var prices = new[] { 100, 25.23m, 58, 23.12m, 125 };
            var currencies = new[] { "USD", "USD", "EUR", "USD", "USD" };

            return GetFullPrice(destinations, clients, infantsIds, childrenIds, prices, currencies);
        }
    }
}