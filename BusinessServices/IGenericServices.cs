using System.Collections.Generic;

namespace BusinessServices {
    public interface IGenericServices<T> {
        T GetItemById(int itemId);
        IEnumerable<T> GetAllItems();
        int CreateItem(T item);
        bool UpdateItem(int itemId, T newItem);
        bool DeleteItem(int itemId);
    }
}