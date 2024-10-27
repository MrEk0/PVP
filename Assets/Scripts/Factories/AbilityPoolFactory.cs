using System;
using Windows;
using Enums;
using UnityEngine;
using UnityEngine.Pool;

namespace Factories
{
    public class AbilityPoolFactory : ObjectPoolFactory
    {
        public event Action<AbilityTypes> AbilitySelectEvent = delegate { };
        
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
            spawnerItem.AbilitySelectEvent += OnAbilitySelected;
            
            return spawnerItem;
        }

        private void OnDestroyPooledObject(AbilityWindowItem pooledObject)
        {
            pooledObject.AbilitySelectEvent -= OnAbilitySelected;
            
            Destroy(pooledObject.gameObject);
        }

        private void OnAbilitySelected(AbilityTypes type)
        {
            AbilitySelectEvent(type);
        }
    }
}