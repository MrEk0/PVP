using System;
using System.Collections.Generic;
using Common;
using Configs;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettingsData gameSettingsData;

    private readonly List<Character> _characters = new();
    private int currentIndex = 0;

    private void Start()
    {
        var serviceLocator = new ServiceLocator();
        
        var player = new PlayerCharacter(serviceLocator);
        player.StepCompleteEvent += OnStepCompletedEvent;
        _characters.Add(player);
        
        var enemy = new EnemyCharacter(serviceLocator);
        enemy.StepCompleteEvent += OnStepCompletedEvent;
        _characters.Add(enemy);
        
        _characters[currentIndex].Step();
    }

    private void OnStepCompletedEvent()
    {
        currentIndex++;
        
        for (var i = 0; i < _characters.Count; i++)
        {
            if (i == currentIndex)
                _characters[i].Step();
        }
    }
}
