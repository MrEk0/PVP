using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Abilities
{
    public abstract class Ability
    {
        public abstract void Apply(Character owner);
    }
}
