using Configs;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettingsData gameSettingsData;
    
    private void Start()
    {
        var player = new Character(gameSettingsData);
        var enemy = new Character(gameSettingsData);
    }
}
