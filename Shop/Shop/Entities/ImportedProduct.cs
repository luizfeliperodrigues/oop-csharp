using System.Globalization;

namespace Shop.Entities
{
    class ImportedProduct : Product
    {
        public double CustomsFee { get; set; }

        public ImportedProduct()
        {
        }

        public ImportedProduct(string name, double price, double customFee) : base(name, price)
        {
            CustomsFee = customFee;
        }

        public override string PriceTag()
        {
            return base.PriceTag() + $" (Customs fee: $ {CustomsFee.ToString("F2", CultureInfo.InvariantCulture)})";
        }
    }
}
