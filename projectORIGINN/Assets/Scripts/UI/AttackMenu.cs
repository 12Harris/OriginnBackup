using System;
using System.Collections;
using System.Collections.Generic;
using Originn.Game.Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Originn.Game.Combat;

namespace Originn.Game.UI
{
    public class AttackMenu : MonoBehaviour
    {
        public static bool isSelectingTarget = false;

        [SerializeField]
        //private SelectableCharacter _ownerCharacter;

        public static event Action _onAttackMenuDeactivated;

        private GameObject _attackBtn;

        [SerializeField]
        private GameObject _owner;//The character associated with this attack menu

        /// <summary>
        /// The attack name associated with the specific attack of this character
        /// Must be the same name as button on the menu
        /// </summary>
        [SerializeField]
        private string _attack;

        private void Awake()
        {   
            _attackBtn = transform.Find(_attack).gameObject;
            _attackBtn.GetComponent<Button>().onClick.AddListener(AttackBtnClicked);
        }

        public void HandleGameStarted()
        {
            _owner.GetComponent<ATB>()._onReadyToAttack += EnableAttackButton;
            Debug.Log("attack menu => game started");
            EnableButton(_attack, false);
        }

        private void EnableAttackButton(Attacker attacker)
        {
            if (_owner.GetComponent<Ally>() == attacker)
            {
                EnableButton(_attack,true);
            }
        }

        private void AttackBtnClicked()
        {   
            //_attackBtn.GetComponent<Button>().enabled = false;
            EnableButton(_attack,false);
            UIEventBus.Execute(UIEventTypes.ATTACKBUTTONCLICK);
        }

        // Update is called once per frame
        void Update()
        {
            //if(Input.GetButtonDown("Cancel"))
            //{
            //    gameObject.SetActive(false);
            //    Time.timeScale = 1f;
            //}

        }

        public void Enable(bool enable)
        {
            this.enabled = enable;
        }



        private void EnableButton(string name, bool enable)
        {
            var button = transform.Find(name);

            if (button != null)
            {
                if(enable)
                    button.gameObject.GetComponent<Image>().color = Color.white;
                else
                    button.gameObject.GetComponent<Image>().color = Color.gray;

                button.gameObject.GetComponent<Button>().enabled = enable;
            }
            else
            {
                Debug.Log("BUTTON IS NULL!");
            }
        }

        public void AttackButton()
        {

            //StartCoroutine(Attack());
            StartCoroutine(TryAttackEnemy());
        }

        /*public void Activate(bool activate)
        {
            if (activate && gameObject.activeSelf == false)
                gameObject.SetActive(true);

            else if (!activate && gameObject.activeSelf == true)
            {
                _onAttackMenuDeactivated?.Invoke();
                gameObject.SetActive(false);
            }
        }*/

        public bool IsActivated()
        {
            return gameObject.activeSelf;
        }

        public IEnumerator TryAttackEnemy()
        {

            /*isSelectingTarget = true;
            Debug.Log("Select Enemy to Attack");
            //transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -500, 0);
            yield return new WaitUntil(() => Input.GetButton("Cancel") || (SelectableCharacter.SelectedCharacter.GetComponent<SelectableCharacter>().CharacterType == SelectableCharacter.charType.Enemy && (Input.GetButton("Submit") || Input.GetMouseButton(0))));


            //Attack
            if (SelectableCharacter.SelectedCharacter.GetComponent<SelectableCharacter>().CharacterType == SelectableCharacter.charType.Enemy)
            {
                //Debug.Log("You have attacked: " + SelectableCharacter.SelectedCharacter);
                //_onStartedAttacking?.Invoke();//This gets called only in the attack method

                Debug.Log("Adding incoming attack");
                AttackInfo attackInfo = new AttackInfo(GameManager.SelectedAlly.ThisAttacker, "Attack", Time.time);
                SelectableCharacter.SelectedCharacter.GetComponent<SelectableCharacter>().ThisAttacker.AddIncomingAttack(attackInfo);
                Debug.Log("Selected Ally = " + GameManager.SelectedAlly);
                //yield return new WaitForSecondsRealtime(1f);//Attacks take one second to complete
            }

            //We pressed the cancel button
            else
            {
                Debug.Log("cancelled attack");

            }
            Time.timeScale = 1f;
            isSelectingTarget = false;
            Debug.Log("Ready to select other things");
            Activate(false);*/
            yield return null;
        }

        /*public IEnumerator Attack()
        {
            //Time.timeScale = 0f;
            isSelectingTarget = true;
            Debug.Log("Select Enemy to Attack");
            transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -500, 0);
            yield return new WaitUntil(() => Input.GetButton("Cancel") || (SelectableCharacter.SelectedCharacter.GetComponent<SelectableCharacter>().CharacterType == SelectableCharacter.charType.Enemy && (Input.GetButton("Submit") || Input.GetMouseButton(0))));
            


            //Attack
            if (SelectableCharacter.SelectedCharacter.GetComponent<SelectableCharacter>().CharacterType == SelectableCharacter.charType.Enemy)
            {
                Debug.Log("You have attacked: " + SelectableCharacter.SelectedCharacter);

                _onStartedAttacking?.Invoke();
                yield return new WaitForSecondsRealtime(1f);//Attacks take one second to complete
            }
            else
            {
                Debug.Log("cancelled attack");
            }
            Time.timeScale = 1f;
            isSelectingTarget = false;
            Debug.Log("Ready to select other things");
            gameObject.SetActive(false);
        }*/

        public void Magic()
        {
            Debug.Log("Openning Magic Menu");
            //transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -500, 0);
            gameObject.SetActive(false);
        }

        public void Guard()
        {
            Debug.Log("You have Guarded");
            //transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -500, 0);
            gameObject.SetActive(false);
        }
    }
}