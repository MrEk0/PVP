

namespace Abilities
{
    public class DamageAbility : Ability
    {
        public override void Apply(Character owner)
        {
            owner.TakeDamage(8f);
        }
    }
}
