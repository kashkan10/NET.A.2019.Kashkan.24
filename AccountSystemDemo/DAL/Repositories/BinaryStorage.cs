using System.Collections.Generic;
using System.IO;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    internal class BinaryStorage : IStorage<AccountDTO>
    {
        /// <summary>
        /// Save list to storage
        /// </summary>
        /// <param name="list"></param>
        public void SaveToStorage(List<AccountDTO> list, string filePath)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate)))
            {
                foreach (AccountDTO s in list)
                {
                    writer.Write(s.AccountId);
                    writer.Write(s.Owner);
                    writer.Write(s.Balance);
                    writer.Write((int)s.Type);
                    writer.Write((int)s.Status);
                    writer.Write(s.Bonus);
                }
            }
        }

        /// <summary>
        /// Load list from storage
        /// </summary>
        /// <param name="list"></param>
        public void LoadFromStorage(List<AccountDTO> list, string filePath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    int id = reader.ReadInt32();
                    string owner = reader.ReadString();
                    decimal balance = reader.ReadDecimal();
                    CardTypeDTO type = (CardTypeDTO)reader.ReadInt32();
                    StatusDTO status = (StatusDTO)reader.ReadInt32();
                    int bonus = reader.ReadInt32();

                    list.Add(new Interface.DTO.AccountDTO(id, owner, balance, type, status, bonus));
                }
            }
        }
    }
}