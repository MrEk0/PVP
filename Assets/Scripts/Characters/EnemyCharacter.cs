using System;
using Common;
using Configs;

namespace Characters
{
    public class EnemyCharacter : Character
    {
        public event Action StepCompleteEvent = delegate { };

        private readonly PlayerCharacter _playerCharacter;

        public EnemyCharacter(ServiceLocator serviceLocator) : base(serviceLocator)
        {
            _playerCharacter = serviceLocator.GetService<PlayerCharacter>();
        }

        public override void Step()
        {
            var data = ServiceLocator.GetService<GameSettingsData>();

            var rndIndex = UnityEngine.Random.Range(0, CharacterAbilities.AbilitiesData.Count);
            var abilityData = CharacterAbilities.AbilitiesData[rndIndex];

            if (data.IsAbilityEnemyApplied(abilityData.Type))
                CharacterAbilities.Add(this, abilityData.Type);
            else
                CharacterAbilities.Add(_playerCharacter, abilityData.Type);

            StepCompleteEvent();
        }
    }
}
