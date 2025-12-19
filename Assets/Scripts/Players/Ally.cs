using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Originn.Game.Combat;
using Harris.GPC;
using Originn.Game.UI;
using Originn.Game;
using UnityEditor.Build.Content;
using System;

namespace Originn.Game.Player
{
    public class Ally : Attacker
    {

        private ATB _atb;
        public ATB Atb { get => _atb; }

        public override void Awake()
        {
            base.Awake();
            _atb = GetComponent<ATB>();

            if(ID == 0)
                UIEventBus.Subscribe(UIEventTypes.ALLY1BUTTONCLICK, new AllyButtonClickedHandler(UIEventTypes.ALLY1BUTTONCLICK));
            else if(ID == 1)
                UIEventBus.Subscribe(UIEventTypes.ALLY2BUTTONCLICK, new AllyButtonClickedHandler(UIEventTypes.ALLY2BUTTONCLICK));
            else
                UIEventBus.Subscribe(UIEventTypes.ALLY3BUTTONCLICK, new AllyButtonClickedHandler(UIEventTypes.ALLY3BUTTONCLICK));

            UIEventBus.Subscribe(UIEventTypes.ATTACKBUTTONCLICK, new AttackButtonClickedHandler(UIEventTypes.ATTACKBUTTONCLICK));
            
        }

    }

    public class AllyButtonClickedHandler: IEventListener
    {
        private UIEventTypes _type;
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
            if(_type == UIEventTypes.ALLY1BUTTONCLICK)
            {
                Attacker.CurrentAttacker = GameManager.Instance.Allies[0].GetComponent<Attacker>();
            }
            else if(_type == UIEventTypes.ALLY2BUTTONCLICK)
            {
                Attacker.CurrentAttacker = GameManager.Instance.Allies[1].GetComponent<Attacker>();
            }
            else if(_type == UIEventTypes.ALLY3BUTTONCLICK)
            {
                Attacker.CurrentAttacker = GameManager.Instance.Allies[2].GetComponent<Attacker>();
            }
        }
    }

    public class AttackButtonClickedHandler: IEventListener
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
            Attacker.CurrentAttacker.AttackingEnabled  = true;
            Debug.Log("attacking enabled = true");
        }
    }
}
