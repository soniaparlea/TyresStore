using System.Collections.Generic;
using System.Data.Entity;
using TyresStore.Repository.Models;

namespace TyresStore.Repository
{
    public class TyresStoreInitializer : DropCreateDatabaseIfModelChanges<TyresStoreContext>
    {
    }
}
