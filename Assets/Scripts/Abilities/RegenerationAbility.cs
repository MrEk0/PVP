namespace Abilities
{
    public class RegenerationAbility : Ability
    {
        public override void Apply(Character owner)
        {
            owner.Heal(5f);
        }
    }
}
