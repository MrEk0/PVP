using Common;
using Configs;
using Interfaces;

public class Character : IDamagable
{
    private CharacterHp _hp;
    private CharacterAbilities _abilities;
    
    public Character(GameSettingsData data)
    {
        _hp = new CharacterHp(data.MaxHp);
        _abilities = new CharacterAbilities();
    }

    public void TakeDamage(float damageValue)
    {
        _hp.TakeDamage(damageValue);
    }

    public void Heal(float extraHp)
    {
        _hp.Heal(extraHp);
    }
}
