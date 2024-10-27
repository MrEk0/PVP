using System;
using Common;
using Configs;

public class EnemyCharacter : Character
{
    public event Action StepCompleteEvent = delegate { };
    
    public EnemyCharacter(ServiceLocator serviceLocator) : base(serviceLocator)
    {
        
    }

    public override void Step()
    {
        var rndIndex = UnityEngine.Random.Range(0, CharacterAbilities.AbilitiesData.Count);
        var abilityType = CharacterAbilities.AbilitiesData[rndIndex];

        StepCompleteEvent();
    }
}
