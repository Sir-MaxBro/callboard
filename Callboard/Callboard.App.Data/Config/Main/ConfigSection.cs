using System;
using System.Collections.Generic;
using System.Configuration;

namespace Callboard.App.Data.Config.Main
{
    public abstract class ConfigCollection<T> : ConfigurationElementCollection
        where T : ConfigurationElement, new()
    {
        public IReadOnlyCollection<T> Where(Predicate<T> predicate)
        {
            var tables = new List<T>();
            for (int i = 0; i < base.Count; i++)
            {
                if (predicate(this[i]))
                {
                    tables.Add(this[i]);
                }
            }
            return tables;
        }

        public T FirstOrDefault(Predicate<T> predicate)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (predicate(this[i]))
                {
                    return this[i];
                }
            }
            return null;
        }

        public T this[int index]
        {
            get { return (T)BaseGet(index); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }
    }
}
