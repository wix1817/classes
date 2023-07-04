namespace classes
{
    internal class Inventory
    {
        List<Product> products = new List<Product>();

        public void AddProduct(string label, double price, int quantity)
        {
            products.Add(new Product(products.Count, label, price, quantity));
        }

        public bool DeleteProduct(int id)
        {
            if (id >= 0 && products.Count >= id)
            {
                products.Remove(products.Find(x => x.Id == id));
                return true;
            }
            else { return false; }
        }

        public List<Product> GetProducts() {  return products; }

        public void CleanInventory()
        {
            products.Clear();
        }
    }
}
