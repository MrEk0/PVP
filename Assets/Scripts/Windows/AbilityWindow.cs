using Windows;
using Common;
using Configs;
using Factories;
using UnityEngine;

public class AbilityWindow : AWindow
{
    [SerializeField] private RectTransform _abilityPanel;
    [SerializeField] private AbilityPoolFactory _abilityPoolFactory;

    private ServiceLocator _serviceLocator;
    private PlayerCharacter _player;

    public override void Init(ServiceLocator serviceLocator)
    {
        _serviceLocator = serviceLocator;
        _player = serviceLocator.GetService<PlayerCharacter>();

        _player.StepStartEvent += OnPlayerStepStarted;
    }

    private void OnPlayerStepStarted()
    {
        _abilityPanel.gameObject.SetActive(true);

        var data = _serviceLocator.GetService<GameSettingsData>();
        foreach (var availableAbility in data.AvailableAbilities)
        {
            var abilityWindowItem = _abilityPoolFactory.ObjectPool.Get();

            var windowItemData = new AbilityWindowItemData
            {

            };
            abilityWindowItem.Init(windowItemData);
        }
    }
}
