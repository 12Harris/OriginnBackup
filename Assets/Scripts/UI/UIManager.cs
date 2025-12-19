using UnityEngine;
using UnityEngine.Events;
using Harris.GPC;
using System.Collections.Generic;
using System;

namespace Originn.Game.UI
{
    public class UIManager : Singleton<UIManager>
    {

        [SerializeField]
        private Transform _uiCanvas;
        public Transform UICanvas => _uiCanvas;

        [SerializeField]
        private List<GameObject> _allyMenus;

        public static GameObject CurrentAllyMenu{get;set;} = null;

        public List<GameObject> AllyMenus => _allyMenus;

        [SerializeField]
        private List<ATBBar> _allyATBs;

        [SerializeField]
        private List<ATBBar> _enemyATBs;

        [SerializeField]
        private List<HealthBar> _allyHealthBars;

        [SerializeField]
        private List<HealthBar> _enemyHealthBars;

        //private SelectableAttacker _selectedAttacker;
        
        [SerializeField]
        private List<SelectableAttacker> _selectableAttackers;


        public static Transform GetUICanvas()
        {
            return Instance.UICanvas;
        }


        private void Awake()
        {
            foreach(var menu in _allyMenus)
                menu.SetActive(false);

            UIEventBus.Subscribe(UIEventTypes.ALLY1BUTTONCLICK, new AllyButtonClickedHandler(UIEventTypes.ALLY1BUTTONCLICK));
            UIEventBus.Subscribe(UIEventTypes.ALLY2BUTTONCLICK, new AllyButtonClickedHandler(UIEventTypes.ALLY2BUTTONCLICK));
            UIEventBus.Subscribe(UIEventTypes.ALLY3BUTTONCLICK, new AllyButtonClickedHandler(UIEventTypes.ALLY3BUTTONCLICK));
            UIEventBus.Subscribe(UIEventTypes.ATTACKBUTTONCLICK, new AttackButtonClickedHandler(UIEventTypes.ATTACKBUTTONCLICK));

        }

        private void Start()
        {
            
        }
    }

    public class AttackButtonClickedHandler : IEventListener
    {
        private UIEventTypes _type;
        public AttackButtonClickedHandler(UIEventTypes type)
        {   
            _type = type;
        }
        public void Update(ISubject subject)
        {
            HandleEvent(subject as Harris.GPC.Event);
        }
        public void HandleEvent(Harris.GPC.Event ev)
        {
        
        }
    }

    public class AllyButtonClickedHandler: IEventListener
    {
        private UIEventTypes _type;
        private bool _allyMenu0Enabled = false;
        private bool _allyMenu1Enabled = false;

        private bool _allyMenu2Enabled = false;

        public AllyButtonClickedHandler(UIEventTypes type)
        {   
            _type = type;
        }
        public void Update(ISubject subject)
        {
            HandleEvent(subject as Harris.GPC.Event);
        }
        public void HandleEvent(Harris.GPC.Event ev)
        {
            Debug.Log("Ally Button clicked at Time: " + (ev as UIEvent).OccuredTime);
            
            if(UIManager.CurrentAllyMenu != null)
                UIManager.CurrentAllyMenu.SetActive(false);

            if(_type == UIEventTypes.ALLY1BUTTONCLICK)
            {
                _allyMenu0Enabled = !_allyMenu0Enabled;
                UIManager.Instance.AllyMenus[0].SetActive(_allyMenu0Enabled);
                UIManager.CurrentAllyMenu = UIManager.Instance.AllyMenus[0];
                if(!_allyMenu0Enabled)
                    Time.timeScale = 1;
                
            }

            else if(_type == UIEventTypes.ALLY2BUTTONCLICK)
            {
                _allyMenu1Enabled = !_allyMenu1Enabled;
                UIManager.Instance.AllyMenus[1].SetActive(_allyMenu1Enabled);
                UIManager.CurrentAllyMenu = UIManager.Instance.AllyMenus[1];
                if(!_allyMenu1Enabled)
                    Time.timeScale = 1;
            }

            else if(_type == UIEventTypes.ALLY3BUTTONCLICK)
            {
                _allyMenu2Enabled = !_allyMenu2Enabled;
                UIManager.Instance.AllyMenus[2].SetActive(_allyMenu2Enabled);
                UIManager.CurrentAllyMenu = UIManager.Instance.AllyMenus[2];
                if(!_allyMenu2Enabled)
                    Time.timeScale = 1;
            }

        }
    }
}