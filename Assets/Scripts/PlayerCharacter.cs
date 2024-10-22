using System;
using Common;

public class PlayerCharacter : Character
{
    public event Action StepCompleteEvent = delegate { };
    public event Action StepStartEvent = delegate { };
    
    public PlayerCharacter(ServiceLocator serviceLocator) : base(serviceLocator)
    {
        
    }

    public override void Step()
    {
        StepStartEvent();
    }
}
