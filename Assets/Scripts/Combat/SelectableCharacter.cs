using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
//using Originn.UI;

namespace Originn.Game.Combat
{
    public class SelectableCharacter : MonoBehaviour
    {
        public static GameObject SelectedCharacter;

        public GameObject Menu;
        public enum charType
        {
            Ally,
            NPC,
            Enemy
        }
        public charType CharacterType;

        public string Name { get; set; }

        private bool _canShowActionMenu = false;

        /*[SerializeField]
        private ATBBar _atbBar;

        public ATBBar AtbBar { get => _atbBar; }*/

        private bool _isAttacking = false;

        public bool WasAttacked { get; set; } = false;

        //public event Action _onStartedAttacking;

        private Attacker _attacker;

        public Attacker ThisAttacker => _attacker;

        /// <summary>
        /// event that gets triggered whenever a new ally is selected
        /// currently only the game manager subscribes to this event
        /// </summary>
        public static event Action<SelectableCharacter> _onAllySelected;


        //If we hover over this game object we automatically select it
        void OnMouseOver()
        {
            SelectedCharacter = this.gameObject;
            Debug.Log("Selected Character = " + SelectedCharacter);
            _canShowActionMenu = true;
        }

        private void OnMouseExit()
        {
            _canShowActionMenu = false;
        }

        private void Awake()
        {
            _attacker = GetComponent<Attacker>();
        }

        // Start is called before the first frame update
        void Start()
        {
            //if(CharacterType == charType.Ally)
                //Menu.GetComponent<AttackMenusButtons>()._onStartedAttacking += HandleStartedAttacking;
            //deactivate the menu on start
            Menu.SetActive(false);
        }

    
        // Update is called once per frame
        void Update()
        {
            /*if(SelectedCharacter == gameObject && CharacterType == charType.Ally)//Input.GetButtonDown("Enter")
            {
                var menu = Menu.GetComponent<AttackMenusButtons>();

                //highlight character
                if (Input.GetMouseButtonDown(0) && AttackMenusButtons.isSelectingTarget == false && _canShowActionMenu)
                {
                    if(CharacterType == charType.Ally)
                        _onAllySelected?.Invoke(this);

                    //Menu.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 400, 0);
                    menu.Activate(true);
                    Time.timeScale = 0;
                }
                else if(Menu.activeSelf && Input.GetButtonDown("Cancel") && AttackMenusButtons.isSelectingTarget == false)
                {

                    menu.Activate(false);
                    Time.timeScale = 1;
                }
            }

            else if(GameManager.SelectedAlly != null && SelectedCharacter == gameObject && AttackMenusButtons.isSelectingTarget == false)
            {
                var allyMenu = GameManager.SelectedAlly.Menu.GetComponent<AttackMenusButtons>();
                if (allyMenu.IsActivated() && Input.GetMouseButtonDown(0))
                {
                    allyMenu.Activate(false);
                    Time.timeScale = 1;
                }
            }
            */
    
        }
    }
}