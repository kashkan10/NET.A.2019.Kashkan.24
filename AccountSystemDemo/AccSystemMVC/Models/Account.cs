namespace AccSystemMVC.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public int Balance { get; set; }
        public int Bonus { get; set; }
        public CardType CardType { get; set; }
    }
}