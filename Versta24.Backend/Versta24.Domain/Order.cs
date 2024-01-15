namespace Versta24.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public int OrderNum { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddres { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddres { get; set; }
        public decimal CargoWeight { get; set; }
        public DateTime CollectionDate { get; set; }
    }
}
