using System;
using System.Collections.Generic;
using Abilities;
using Enums;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/GameSettingsData")]
    public class GameSettingsData : ScriptableObject
    {
        [Serializable]
        public class AbilitySettings<T> where T : Ability
        {
            [SerializeField] private AbilityTypes _type;
            [SerializeField] private Sprite _sprite;
            [SerializeField] private int _reloadStepsCount;
            
            public AbilityTypes Type => _type;
            public Sprite Sprite => _sprite;
            public int ReloadStepsCount => _reloadStepsCount;
            public T Ability { get; set; }
        }
        
        [SerializeField] private int _maxHp;
        [SerializeField] private AbilitySettings<Ability>[] _availableAbilities = Array.Empty<AbilitySettings<Ability>>();

        public int MaxHp => _maxHp;

        public IReadOnlyList<AbilitySettings<Ability>> AvailableAbilities => _availableAbilities;

        private void OnValidate()
        {
            foreach (var availableAbility in _availableAbilities)
            {
                availableAbility.Ability = availableAbility.Type switch
                {
                    AbilityTypes.BarrierAbility => new BarrierAbility(),
                    AbilityTypes.DamageAbility => new DamageAbility(),
                    AbilityTypes.FireBallAbility => new FireBallAbility(),
                    AbilityTypes.PurificationAbility => new PurificationAbility(),
                    AbilityTypes.RegenerationAbility => new RegenerationAbility(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }
    }
}