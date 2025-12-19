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
    /*public class AttackMenusButtons : MonoBehaviour
    {
        public static bool isSelectingTarget = false;

        [SerializeField]
        //private SelectableCharacter _ownerCharacter;

        public static event Action _onAttackMenuDeactivated;

        /// <summary>
        /// The attack name associated with the specific attack of this character
        /// Must be the same name as button on the menu
        /// </summary>
        [SerializeField]
        private string _attack;

        private void Awake()
        {
            if (_ownerCharacter.CharacterType == SelectableCharacter.charType.Ally)
                _ownerCharacter.ThisAttacker._onStartedAttacking += DisableAttackButton;

            _ownerCharacter.AtbBar._onFilledCompletely += EnableAttackButton;

            DisableAttackButton();

            Debug.Log("attack menu awaked!");

            gameObject.SetActive(false)

        }

        // Start is called before the first frame update
        void Start()
        {
            if (_ownerCharacter.CharacterType == SelectableCharacter.charType.Ally)
                _ownerCharacter.ThisAttacker._onStartedAttacking += DisableAttackButton;

            ((Ally)(_ownerCharacter.ThisAttacker)).Atb._onReadyToAttack += EnableAttackButton;


            DisableAttackButton();

            Debug.Log("attack menu awaked!");

            gameObject.SetActive(false);
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



        private void DisableAttackButton()
        {
            var attackButton = transform.Find(_attack);

            if (attackButton != null)
            {
                attackButton.gameObject.GetComponent<Image>().color = Color.gray;
                attackButton.gameObject.GetComponent<Button>().enabled = false;
            }
        }

        private void EnableAttackButton()
        {
            var attackButton = transform.Find(_attack);

            if (attackButton != null)
            {
                attackButton.gameObject.GetComponent<Image>().color = Color.white;
                attackButton.gameObject.GetComponent<Button>().enabled = true;
            }
        }

        public void AttackButton()
        {

            //StartCoroutine(Attack());
            StartCoroutine(TryAttackEnemy());
        }

        public void Activate(bool activate)
        {
            if (activate && gameObject.activeSelf == false)
                gameObject.SetActive(true);

            else if (!activate && gameObject.activeSelf == true)
            {
                _onAttackMenuDeactivated?.Invoke();
                gameObject.SetActive(false);
            }
        }

        public bool IsActivated()
        {
            return gameObject.activeSelf;
        }

        public IEnumerator TryAttackEnemy()
        {
            //Time.timeScale = 0f;
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
            Activate(false);
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
        }

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
        

        /// <summary>
        /// The attack name associated with the specific attack of this character
        /// Must be the same name as button on the menu
        /// </summary>
        [SerializeField]
        private string _attack;

        [SerializeField]
        private SelectableAttacker _ownerCharacter;
        private void Awake()
        {
            if (_ownerCharacter.CharacterType == SelectableCharacter.charType.Ally)
                _ownerCharacter.ThisAttacker._onStartedAttacking += DisableAttackButton;

            _ownerCharacter.AtbBar._onFilledCompletely += EnableAttackButton;

           EnableAttackButton(false);

            Debug.Log("attack menu awaked!");

            gameObject.SetActive(false)

        }


        private void EnableAttackButton(bool enable)
        {
            var attackButton = transform.Find(_attack);

            if (attackButton != null)
            {
                attackButton.gameObject.GetComponent<Image>().color = enable ? Color.white : Color.gray;
                attackButton.gameObject.GetComponent<Button>().enabled = enable;
            }
        }

    }*/
    
}