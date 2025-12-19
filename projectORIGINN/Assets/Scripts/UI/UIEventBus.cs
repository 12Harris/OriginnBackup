using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;
using Harris.GPC;
using System;

namespace Originn.Game.UI
{

    public class UIEvent : Harris.GPC.Event
    {         
        public DateTime OccuredTime { get; private set; }

        public override void Notify()
        {
            OccuredTime = DateTime.Now;
            base.Notify();
        }
    }

    public class UIButtonEvent : UIEvent
    {
        private string _evtName;
        public UIButtonEvent(string evtName)
        {
            _evtName = evtName;
        }
    }

    public class UIAttackEvent : UIEvent
    {

        public int AttackerID{get;}

        public int TargetID{get;}

        private string _evtName;
        public UIAttackEvent(string evtName)
        {
            _evtName = evtName;
        }
    }


    public class UIEventTypes : EventTypes
    {

        public static readonly UIEventTypes ALLY1BUTTONCLICK = new UIEventTypes("ALLY1BUTTONCLICK",  new UIButtonEvent("ALLY1BUTTONCLICK"));
        public static readonly UIEventTypes ALLY2BUTTONCLICK = new UIEventTypes("ALLY2BUTTONCLICK",  new UIButtonEvent("ALLY2BUTTONCLICK"));
        public static readonly UIEventTypes ALLY3BUTTONCLICK = new UIEventTypes("ALLY3BUTTONCLICK",  new UIButtonEvent("ALL31BUTTONCLICK"));
        public static readonly UIEventTypes ENEMY1ATTACK = new UIEventTypes("ENEMY1ATTACK",  new UIButtonEvent("ENEMY1ATTACK"));
        public static readonly UIEventTypes ENEMY2ATTACK = new UIEventTypes("ENEMY2ATTACK",  new UIButtonEvent("ENEMY2ATTACK"));
        public static readonly UIEventTypes ENEMY3ATTACK = new UIEventTypes("ENEMY3ATTACK",  new UIButtonEvent("ENEMY3ATTACK"));
        public static readonly UIEventTypes ATTACKBUTTONCLICK = new UIEventTypes("ATTACKBUTTONCLICK",  new  UIButtonEvent("ATTACKBUTTONCLICK"));

        private int id = -1;

        public UIEventTypes (string value,  UIEvent ev): base(value, ev)
        {

        }
    }

    public class UIEventBus : EventBus<UIEventTypes> 
    {

    }
}