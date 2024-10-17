using System.Collections.Generic;
using Abilities;

public class CharacterAbilities
{
    public IReadOnlyList<Ability> Abilities => _abilities;

    private readonly List<Ability> _abilities = new();

    public void Add(Ability ability)
    {
        _abilities.Add(ability);
    }

    public void Remove(Ability ability)
    {
        _abilities.Remove(ability);
    }
}
