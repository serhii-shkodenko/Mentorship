using System;
using System.Collections;
using System.Collections.Generic;

namespace Lecture11
{
    public class ApplicationFeatures : IEnumerable
    {
        private HashSet<string> _featuresStore;
        private IDictionary<int, string> _hashFeatureMap;

        /// <summary>
        ///
        /// </summary>
        /// <param name=hash">Hash of the item.</param>
        /// <returns></returns>
        public string this[int hash]
        {
            get => TryGetItem(hash);
            set => _hashFeatureMap[hash] = value;
        }

        private string TryGetItem(int hash)
        {
            if (_hashFeatureMap.TryGetValue(hash, out var result))
            {
                return result;
            }

            throw new ArgumentException("No element with give hash persists in the collection.", nameof(hash));
        }

        public ApplicationFeatures()
        {
            _featuresStore = new HashSet<string>();
            _hashFeatureMap = new Dictionary<int, string>();
        }

        public ApplicationFeatures(IEnumerable<string> collectionToInitialize) : this()
        {
            foreach (var item in collectionToInitialize)
            {
                if (_featuresStore.Contains(item))
                {
                    throw new ArgumentException("Collection contains identical items.", nameof(collectionToInitialize));
                }

                _featuresStore.Add(item);
                _hashFeatureMap.Add(item.GetHashCode(), item);
            }
        }

        public IEnumerator GetEnumerator()
        {
            //return _featuresStore.GetEnumerator();

            foreach (var feature in _featuresStore)
            {
                yield return feature;
            }
        }

        public void Add(string feature)
        {
            if (!_featuresStore.Contains(feature))
            {
                _featuresStore.Add(feature);
            }
        }
    }
}