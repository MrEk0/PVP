using System;
using Common;
using Configs;
using Interfaces;

public abstract class Character : IDamagable
{
    protected ServiceLocator _serviceLocator;
    
    private CharacterHp _hp;
    private CharacterAbilities _abilities;

    protected Character(ServiceLocator serviceLocator)
    {
        _serviceLocator = serviceLocator;
        var data = serviceLocator.GetService<GameSettingsData>();
        
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

    public abstract void Step();
}
