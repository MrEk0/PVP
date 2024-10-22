using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/AbilitySettingsData")]
    public class AbilitySettingsData : ScriptableObject
    {
        [Serializable]
        public class Ability
        {
            [SerializeField] private AbilityTypes _type;
        }

        [SerializeField] private int maxHp;
        [SerializeField] private AbilityTypes[] availableAbilities = Array.Empty<AbilityTypes>();

        public int MaxHp => maxHp;

        public IReadOnlyList<AbilityTypes> AvailableAbilities => availableAbilities;
    }
}