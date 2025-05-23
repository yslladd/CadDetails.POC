namespace CadDetails.POC.Domain.Entities
{
    public class Product
    {
        public double Price { get; set; }
        public int Quantity { get; set; }

        public bool IsValid()
        {
            return Price >= 0 && Quantity >= 0;
        }
        public double GetTotal()
        {
            return IsValid() ? Price * Quantity : 0;

        }
    }
}