using UnityEngine;
using Originn.Game.Player;

namespace Originn.Game.NPC.Companion
{

    public class Companion: MonoBehaviour
    {
        private CompanionFollow _companionMovement;

        private void Awake()
        {
            _companionMovement = GetComponent<CompanionFollow>();
        }

        public void OnMouseDown()
        {
            _companionMovement.FollowCmd = true;
            PartyManagement.AddToParty(transform);
        }
    }
}