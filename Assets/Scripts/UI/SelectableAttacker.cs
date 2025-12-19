using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using Originn.Game.Combat;

namespace Originn.Game.UI
{
    public class SelectableAttacker:MonoBehaviour
    {
        private static SelectableAttacker _selectedAttacker = null;
        private static SelectableAttacker _selectedAlly = null;
        public static SelectableAttacker SelectedAlly => _selectedAlly;
        private static SelectableAttacker _selectedEnemy = null;
        public static SelectableAttacker SelectedEnemy => _selectedEnemy;

        private bool _canShowActionMenu = false;

        [SerializeField]
        private int _allyID;

        public int AllyID => _allyID;

        [SerializeField]
        private int _enemyID;

        public int EnemyID => _enemyID;

        public enum charType
        {
            Ally,
            NPC,
            Enemy
        }

        [SerializeField]
        private charType _characterType;

        public charType CharacterType => _characterType;

        public void Awake()
        {
            //ATBBar.
        }

        void OnMouseOver()
        {
            _selectedAttacker = this;
            if(_selectedAttacker._characterType == charType.Ally)
                _selectedAlly = this;
            else
                _selectedEnemy = this;

            //Debug.Log("Selected Attacker = " + _selectedAttacker);
            _canShowActionMenu = true;
        }

        void OnMouseExit()
        {
            //_selectedAttacker = null;
            if(this._characterType == charType.Enemy)
            {
               _selectedEnemy = null;
            }
            _canShowActionMenu = false;
        }


        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("selected attacker: " + _selectedAttacker);
                if(_selectedAttacker.CharacterType == charType.Ally && _selectedAlly == this &&_canShowActionMenu)
                {
                    Time.timeScale = 0;
                    Debug.Log("Selected Ally = " + _selectedAttacker);
                    //menu.Activate(true);
                    if(_allyID == 0)
                        UIEventBus.Execute(UIEventTypes.ALLY1BUTTONCLICK);
                    else if(_allyID == 1)
                        UIEventBus.Execute(UIEventTypes.ALLY2BUTTONCLICK);
                    else if(_allyID == 2)
                        UIEventBus.Execute(UIEventTypes.ALLY3BUTTONCLICK);
                }

                //If we selected an ally we can attack the selected enemy
                else if(_selectedAlly != null && _selectedAttacker.CharacterType == charType.Enemy && _selectedEnemy == this)
                {
                    if(_enemyID == 0)
                        UIEventBus.Execute(UIEventTypes.ENEMY1ATTACK);
                    else if(_enemyID == 1)
                        UIEventBus.Execute(UIEventTypes.ENEMY2ATTACK);
                    else if(_enemyID == 2)
                        UIEventBus.Execute(UIEventTypes.ENEMY3ATTACK);

                    Time.timeScale = 1;
                }
            }
        }
    }
}