using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Originn.Game.Combat
{
    public interface IAttackable
    {
        bool IsBeingAttacked { get; set; }

        bool IsTargetted { get; set; }

        public void DrainHealth(int amount);
    }
}