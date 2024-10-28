using System;
using Windows;
using Common;
using Configs;
using Enums;

namespace Characters
{
    public class PlayerCharacter : Character, IDisposable
    {
        public event Action StepCompleteEvent = delegate { };
        public event Action StepStartEvent = delegate { };

        private readonly AbilityWindow _abilityWindow;
        private readonly EnemyCharacter _enemyCharacter;

        public PlayerCharacter(ServiceLocator serviceLocator) : base(serviceLocator)
        {
            _abilityWindow = serviceLocator.GetService<AbilityWindow>();
            _enemyCharacter = serviceLocator.GetService<EnemyCharacter>();

            _abilityWindow.AbilitySelectEvent += OnAbilitySelected;
        }

        private void OnAbilitySelected(AbilityTypes type)
        {
            var data = ServiceLocator.GetService<GameSettingsData>();

            CharacterAbilities.ChangeSteps();
            CharacterAbilities.SelectAbility(type);

            if (data.IsAbilityEnemyApplied(type))
                CharacterAbilities.Add(_enemyCharacter, type);
            else
                CharacterAbilities.Add(this, type);

            StepCompleteEvent();
        }

        public override void Step()
        {
            StepStartEvent();
        }

        public void Dispose()
        {
            _abilityWindow.AbilitySelectEvent -= OnAbilitySelected;
        }
    }
}
