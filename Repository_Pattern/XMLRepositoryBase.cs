using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Repository_Domain;
using Repository_Source;

namespace Repository_Pattern
{
    // XMLRepositoryBase for handling generic XML repository operations.
    public class XMLRepositoryBase<TContext, TEntity, TKey> : IRepository<TEntity, TKey>
        where TContext : XMLSet<TEntity> where TEntity : class, IEntity<TKey>
    {
        private readonly XMLSet<TEntity> m_context;

        public XMLRepositoryBase(string fileName)
        {
            m_context = new XMLSet<TEntity>(fileName);
        }
        public TKey Insert(TEntity model)
        {
            var list = m_context.Data.ToList();

            // Determine the unique ID based on the maximum existing ID
            TKey newId = GetUniqueKey(list);

            // Set the ID for the new model
            model.ProductId = newId;

            list.Add(model);
            m_context.Data = list;
            m_context.Save();

            return newId;
        }

        private TKey GetUniqueKey(List<TEntity> list)
        {
            TKey newId = default(TKey);

            if (list.Count > 0)
            {
                var maxId = list.Max(item => (dynamic)item.ProductId);
                newId = (TKey)((dynamic)maxId + 1);
            }

            return newId;
        }

        public bool Delete(TKey id)
        {
            try
            {
                var items = m_context.Data;
                var itemToRemove = items.FirstOrDefault(f => f.ProductId.Equals(id));

                if (itemToRemove != null)
                {
                    items.Remove(itemToRemove);
                    m_context.Data = items;
                    m_context.Save();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var list = m_context.Data.AsQueryable().Where(predicate).ToList();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TEntity Get(TKey id)
        {
            try
            {
                var items = m_context.Data;
                return items.FirstOrDefault(f => f.ProductId.Equals(id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ICollection<TEntity> GetAll()
        {
            return m_context.Data;
        }
        public bool Remove(TKey id)
        {
            return Delete(id);
        }

        public bool Update(TEntity model)
        {
            try
            {
                IEntity<TKey> imodel = model as IEntity<TKey>;
                var items = m_context.Data.ToList();
                var existingItem = items.FirstOrDefault(f => f.ProductId.Equals(imodel.ProductId));

                if (existingItem != null)
                {
                    items.Remove(existingItem);
                    items.Add(model);
                    m_context.Data = items as ICollection<TEntity>;
                    m_context.Save();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
