using Windows;
using UnityEngine;
using UnityEngine.Pool;

namespace Factories
{
    public class AbilityPoolFactory : ObjectPoolFactory
    {
        [SerializeField] private AbilityWindowItem _poolItem;
        [SerializeField] private RectTransform _parent;

        public IObjectPool<AbilityWindowItem> ObjectPool { get; private set; }
        
        private void Start()
        {
            ObjectPool = new ObjectPool<AbilityWindowItem>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject);
        }

        private AbilityWindowItem CreateProjectile()
        {
            var spawnerItem = Instantiate(_poolItem, _parent);
            return spawnerItem;
        }

        private void OnDestroyPooledObject(AbilityWindowItem pooledObject)
        {
            Destroy(pooledObject.gameObject);
        }
    }
}