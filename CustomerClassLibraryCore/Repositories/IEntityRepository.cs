using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerClassLibraryCore.Repositories
{
    public interface IEntityRepository<TEntity>
    {
         int Create(TEntity entity);

         TEntity Read(int entityId);

         List<TEntity> ReadAll();

         List<TEntity> ReadAll(int entityId);

         int GetAmountOfRows();

         List<TEntity> ReadPartially(int pageNumber, int rowsCount);

         void Update(TEntity entity);

         void Delete(TEntity entity);

         void Delete(int entityId);

    }
}
