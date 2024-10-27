using System.Linq;
using Windows;
using Abilities;
using Common;
using Configs;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettingsData _gameSettingsData;
    [SerializeField] private GameWindow _gameWindow;

    private PlayerCharacter _playerCharacter;
    private EnemyCharacter _enemyCharacter;

    private bool _isPlayerStep = true;

    private void Start()
    {
        var serviceLocator = new ServiceLocator();

        var abilitiesData = _gameSettingsData.AvailableAbilities.Select(ability =>
            new CharacterAbilities.AbilityData<Ability>
            {
                Ability = ability.Ability,
                Sprite = ability.Sprite,
                CurrentReloadSteps = 0,
                MaxReloadSteps = ability.ReloadStepsCount,
                Type = ability.Type
            }).ToList();

        _playerCharacter = new PlayerCharacter(serviceLocator);
        _playerCharacter.CharacterAbilities.AddRange(abilitiesData);
        _playerCharacter.StepCompleteEvent += OnStepCompletedEvent;

        _enemyCharacter = new EnemyCharacter(serviceLocator);
        _enemyCharacter.CharacterAbilities.AddRange(abilitiesData);
        _enemyCharacter.StepCompleteEvent += OnStepCompletedEvent;

        _gameWindow.RestartEvent += OnGameRestarted;

        MakeFirstStep();
    }

    private void OnDestroy()
    {
        _playerCharacter.StepCompleteEvent -= OnStepCompletedEvent;
        _enemyCharacter.StepCompleteEvent -= OnStepCompletedEvent;
        _gameWindow.RestartEvent -= OnGameRestarted;
    }

    private void MakeFirstStep()
    {
        _playerCharacter.Step();
        _isPlayerStep = false;
    }

    private void OnGameRestarted()
    {
        _playerCharacter.CharacterAbilities.Restart();
        _enemyCharacter.CharacterAbilities.Restart();
        
        MakeFirstStep();
    }

    private void OnStepCompletedEvent()
    {
        if (_isPlayerStep)
            _playerCharacter.Step();
        else
            _enemyCharacter.Step();

        _isPlayerStep = !_isPlayerStep;
    }
}
