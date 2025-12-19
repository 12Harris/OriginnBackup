using UnityEngine;
using System.Collections.Generic;
using Originn.Game.NPC.Companion;

namespace Originn.Game.Player
{

    public class PartyManagement : MonoBehaviour
    {
        private static List<Transform> partyMembers = new List<Transform>();

        [SerializeField]
        private GameObject _mainPlayer;

        private void Awake()
        {
            AddToParty(_mainPlayer.transform);
        }

        public static void AddToParty(Transform member)
        {
            if (!partyMembers.Contains(member))
            {
                partyMembers.Add(member);

                member.gameObject.layer = 7;
                member.gameObject.tag = "Player";

                Debug.Log(member.name + " has joined the party!");
            }
        }
    }
}
