using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/GameSettingsData")]
    public class GameSettingsData : ScriptableObject
    {
        [SerializeField] private int _maxHp;

        public int MaxHp => _maxHp;
    }
}