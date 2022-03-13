using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckoutKata
{
    public class Checkout
    {
        private Dictionary<char, double> _prices;
        private Dictionary<char, Offer> _offers;
        private Dictionary<char, int> _itemCounters;

        // Total sum holder. Can only be set internally
        public double Total { get; private set; }

        public Checkout()
        {
            // Set initial counts of Items to 0
            _itemCounters = new Dictionary<char, int> { { 'A', 0 }, { 'B', 0 }, { 'C', 0 }, { 'D', 0 } };

            // Set pairs of Items and their Prices
            _prices = new Dictionary<char, double> { { 'A', 10.0 }, { 'B', 15.0 }, { 'C', 40.0 }, { 'D', 55.0 } };

            // Set Offers for specific items
            _offers = new Dictionary<char, Offer>
            {
                {'B', new Offer { Discount = 5, NumberOfItems = 3}}, // 3 Items for 40
                {'D', new Offer { Discount = 27.5, NumberOfItems = 2}}, // 25% discount on 2 Items
            };
        }

        // Add Item to Cart and calculate the new Total
        public void AddItem(char item)
        {
            // Increase Item count
            _itemCounters[item]++;

            // Calculate new Total
            Total += _prices[item];

            // Apply discount if the Item has an offer and if the required number of Items is reached
            if (HasOffer(item) && RequiredNumber(item))
            {
                Total -= _offers[item].Discount;
            }
        }

        // Check whether the passed Item has an offer associated
        private bool HasOffer(char item)
        {
            return _offers.ContainsKey(item);
        }

        // Check whether the required number of Items for discount(Offer) to apply has been added to Cart
        private bool RequiredNumber(char item)
        {
            return _itemCounters[item] == _offers[item].NumberOfItems;
        }
    }
}