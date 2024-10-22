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
        var data = _serviceLocator.GetService<GameSettingsData>();
        var rndIndex = UnityEngine.Random.Range(0, data.AvailableAbilities.Count);
        var abilityType = data.AvailableAbilities[rndIndex];
    }
}
