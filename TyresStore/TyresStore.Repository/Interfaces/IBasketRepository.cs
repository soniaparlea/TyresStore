using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyresStore.Repository.Interfaces
{
    public interface IBasketRepository
    {
        void StoreTyre(int tyreId, string description);

       /* List<Basket> GetItems();

        bool TyreAlreadyAdded(int tyreId);

        void RemoveItem(int itemId);*/
    }
}
