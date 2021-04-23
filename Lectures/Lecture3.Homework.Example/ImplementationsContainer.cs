using System;
using System.Collections.Generic;

namespace Lecture3.Homework.Example.Models
{
    public class ImplementationsContainer
    {
        private IDictionary<Type, object> _implementations = new Dictionary<Type, object>();

        public TImplementation Get<TImplementation>()
        {
            return (TImplementation)this[typeof(TImplementation)];
        }

        public void Set<TImplementation>(TImplementation instance)
        {
            this[typeof(TImplementation)] = instance;
        }

        public object this[Type key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                return _implementations != null && _implementations.TryGetValue(key, out var result) ? result : default;
            }
            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                if (value == null)
                {
                    if (_implementations != null)
                    {
                        _implementations.Remove(key);
                    }
                    return;
                }

                _implementations[key] = value;
            }
        }
    }
}