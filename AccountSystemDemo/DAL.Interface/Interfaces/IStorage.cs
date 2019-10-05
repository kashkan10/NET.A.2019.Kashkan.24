using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    public interface IStorage<T>
    {
        void SaveToStorage(List<T> list, string filePath);

        void LoadFromStorage(List<T> list, string filePath);
    }
}
