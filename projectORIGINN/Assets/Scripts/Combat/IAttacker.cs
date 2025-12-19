using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Originn.Game.Combat
{
    public interface IAttacker : IAttackable
    {
        bool IsAttacking { get; set; }

        void Attack(IAttackable other, string attackName);
    }
}
