using System;
using Windows;
using Common;
using Enums;

public class PlayerCharacter : Character, IDisposable
{
    public event Action StepCompleteEvent = delegate { };
    public event Action StepStartEvent = delegate { };

    private readonly AbilityWindow _abilityWindow;

    public PlayerCharacter(ServiceLocator serviceLocator) : base(serviceLocator)
    {
        _abilityWindow = serviceLocator.GetService<AbilityWindow>();

        _abilityWindow.AbilitySelectEvent += OnAbilitySelected;
    }

    private void OnAbilitySelected(AbilityTypes type)
    {
        CharacterAbilities.ChangeSteps();
        CharacterAbilities.SelectAbility(type);
        
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
