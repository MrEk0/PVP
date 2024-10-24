using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/GameSettingsData")]
    public class GameSettingsData : ScriptableObject
    {
        [SerializeField] private int maxHp;
        [SerializeField] private AbilityTypes[] availableAbilities = Array.Empty<AbilityTypes>();

        public int MaxHp => maxHp;

        public IReadOnlyList<AbilityTypes> AvailableAbilities => availableAbilities;
    }
}