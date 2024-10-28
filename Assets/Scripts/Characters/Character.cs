using Common;
using Configs;

namespace Characters
{
    public abstract class Character
    {
        public CharacterHp Hp { get; }
        public CharacterAbilities CharacterAbilities { get; }
        protected ServiceLocator ServiceLocator { get; }

        protected Character(ServiceLocator serviceLocator)
        {
            ServiceLocator = serviceLocator;

            var data = serviceLocator.GetService<GameSettingsData>();

            Hp = new CharacterHp(data.MaxHp);
            CharacterAbilities = new CharacterAbilities();
        }

        public abstract void Step();
    }
}
