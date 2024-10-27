using System;
using Windows;
using Common;
using Configs;
using Enums;
using Factories;
using UnityEngine;

namespace Windows
{
    public class AbilityWindow : AWindow
    {
        public event Action<AbilityTypes> AbilitySelectEvent = delegate { };

        [SerializeField] private RectTransform _abilityPanel;
        [SerializeField] private AbilityPoolFactory _abilityPoolFactory;

        private ServiceLocator _serviceLocator;
        private PlayerCharacter _player;

        public override void Init(ServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
            _player = serviceLocator.GetService<PlayerCharacter>();

            _player.StepStartEvent += OnPlayerStepStarted;
            _abilityPoolFactory.AbilitySelectEvent += OnAbilitySelected;
        }

        private void OnDestroy()
        {
            _player.StepStartEvent -= OnPlayerStepStarted;
            _abilityPoolFactory.AbilitySelectEvent -= OnAbilitySelected;
        }

        private void OnPlayerStepStarted()
        {
            _abilityPanel.gameObject.SetActive(true);
            
            foreach (var availableAbility in _player.CharacterAbilities.AbilitiesData)
            {
                var abilityWindowItem = _abilityPoolFactory.ObjectPool.Get();

                var windowItemData = new AbilityWindowItemData
                {
                    Sprite = availableAbility.Sprite,
                    ReloadSteps = availableAbility.CurrentReloadSteps,
                    Type = availableAbility.Type
                };
                abilityWindowItem.Init(windowItemData);
            }
        }

        private void OnAbilitySelected(AbilityTypes type)
        {
            _abilityPanel.gameObject.SetActive(false);
            
            AbilitySelectEvent(type);
        }
    }
}
