using System;
using Interfaces;

namespace Common
{
    public class CharacterHp : IDamagable
    {
        public event Action DeathEvent = delegate { };
        
        private float _hp;
        private float _maxHp;

        public CharacterHp(float maxHp)
        {
            _hp = maxHp;
            _maxHp = maxHp;
        }

        public void Heal(float hp)
        {
            _hp = MathF.Min(_hp + hp, _maxHp);
        }

        public void TakeDamage(float damageValue)
        {
            _hp -= damageValue;
            if (_hp <= 0f)
                DeathEvent();
        }
    }
}