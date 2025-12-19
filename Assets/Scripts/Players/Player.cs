using UnityEngine;

namespace Originn.Game.Player
{
    public class Player : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }
    }
}