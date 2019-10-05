using System.ComponentModel.DataAnnotations;

namespace DAL.Interface.DTO
{
    public class AccountDTO
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AccountDTO()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="balance"></param>
        /// <param name="bonus"></param>
        /// <param name="cardType"></param>
        public AccountDTO(int id, string owner, decimal balance, int bonus, CardTypeDTO cardType)
        {
            AccountId = id;
            Owner = owner;
            Balance = balance;
            Type = cardType;
            Bonus = bonus;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="owner"></param>
        /// <param name="balance"></param>
        /// <param name="cardType"></param>
        /// <param name="status"></param>
        /// <param name="bonus"
        public AccountDTO(int id, string owner, decimal balance, CardTypeDTO cardType, StatusDTO status, int bonus)
        {
            AccountId = id;
            Owner = owner;
            Balance = balance;
            Type = cardType;
            Status = status;
            Bonus = bonus;
        }

        /// <summary>
        /// AccountNumber property
        /// </summary>
        [Key]
        public int AccountId { get; set; }

        /// <summary>
        /// Owner property
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Balance property
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Bonus property
        /// </summary>
        public int Bonus { get; set; }

        /// <summary>
        /// Status property
        /// </summary>
        public StatusDTO Status { get; set; }

        /// <summary>
        /// Type property
        /// </summary>
        public CardTypeDTO Type { get; set; }

        /// <summary>
        /// Override of ToString() method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>String representation</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            AccountDTO acc = obj as AccountDTO;

            if (acc == null)
            {
                return false;
            }

            return this.AccountId == acc.AccountId;
        }

        /// <summary>
        /// Override of GetHashCode() method
        /// </summary>
        /// <returns>integer number</returns>
        public override int GetHashCode()
        {
            return (AccountId + Owner).ToString().GetHashCode();
        }
    }
}