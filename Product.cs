﻿namespace classes
{
    public class Product
    {
        internal int Id { get; }
        internal double Price { get; }
        internal int Quantity { get; }
        internal string Label { get; }

        public Product(int id, string label, double price, int quantity )
        {
            Id = id;
            Price = price;
            Quantity = quantity;
            Label = label;
        }
    }
}
