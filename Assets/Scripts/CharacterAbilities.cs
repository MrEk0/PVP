using System.Collections.Generic;
using System.Linq;
using Abilities;
using Enums;
using UnityEngine;

public class CharacterAbilities
{
    public class AbilityData<T> where T : Ability
    {
        public T Ability;
        public Sprite Sprite;
        public int CurrentReloadSteps;
        public int MaxReloadSteps;
        public AbilityTypes Type;
    }
    
    public IReadOnlyList<Ability> Abilities => _abilities;
    public IReadOnlyList<AbilityData<Ability>> AbilitiesData => _abilitiesData;

    private readonly List<Ability> _abilities = new();
    private readonly List<AbilityData<Ability>> _abilitiesData = new();

    public void AddRange(IEnumerable<AbilityData<Ability>> abilitiesData)
    {
        _abilitiesData.AddRange(abilitiesData);
    }

    public void SelectAbility(AbilityTypes type)
    {
        var abilityData = _abilitiesData.FirstOrDefault(o => o.Type == type);
        if (abilityData == null)
            return;

        abilityData.CurrentReloadSteps = abilityData.MaxReloadSteps;
    }

    public void ChangeSteps()
    {
        foreach (var abilityData in _abilitiesData)
            abilityData.CurrentReloadSteps = abilityData.CurrentReloadSteps > 0 ? abilityData.CurrentReloadSteps - 1 : 0;
    }

    public void Add(Ability ability)
    {
        _abilities.Add(ability);
    }

    public void Remove(Ability ability)
    {
        _abilities.Remove(ability);
    }

    public void Restart()
    {
        _abilities.Clear();

        foreach (var abilityData in _abilitiesData)
            abilityData.CurrentReloadSteps = 0;
    }
}
