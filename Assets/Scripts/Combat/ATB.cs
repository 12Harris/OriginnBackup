using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Originn.Game.UI;

namespace Originn.Game.Combat
{
    public class ATB : MonoBehaviour
    {

        [SerializeField]
        private ATBBar _atbBar;

        [SerializeField]
        [Range(0, 2)]
        private float _progressionSpeed = 5f;

        private bool _filledCompletely = false;

        public event Action<Attacker> _onReadyToAttack;

        private float _currentATB = 0f;

        private float _maxATB = 1f;

        //The character that owns this ATB component
        private Attacker _owner;

        // Start is called before the first frame update
        void Start()
        {
            _owner = GetComponent<Attacker>();
            //_atbBar.FillAmount = 0.7f;
            //if (_ownerCharacter.CharacterType == SelectableCharacter.charType.Ally)
            _owner._onStartedAttacking += HandleStartedAttacking;
            //SelectableCharacter._onAllySelected += (x) => {_paused = true; };
            //AttackMenusButtons._onAttackMenuDeactivated += () => { _paused = false; };
        }

        public void HandleStartedAttacking()
        {
            //as soon as a player started attacking an enemy, the progress bar is reset
            Debug.Log("HANDLE STARTED ATTACKING");
            _atbBar.FillAmount = 0f;
            _currentATB = 0f;
            _filledCompletely = false;
        }

        void Update()
        {

            if (_currentATB < _maxATB)
            {
                _currentATB += Time.deltaTime * _progressionSpeed * 0.1f;
                _atbBar.FillAmount = _currentATB;
            }

            else if (_filledCompletely == false)
            {
                //if(_ownerCharacter.CharacterType == SelectableCharacter.charType.Ally)
                _onReadyToAttack?.Invoke(_owner);
                Debug.Log("atb bar filled completely");
                _filledCompletely = true;
            }
        }
    }
}