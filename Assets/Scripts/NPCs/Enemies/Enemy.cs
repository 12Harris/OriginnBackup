using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Harris.GPC;
using Originn.Game.UI;
using Originn.Game;
using Originn.Game.Combat;

namespace Originn.Game.NPC.Enemy
{
    public class Enemy : Attacker
    {

        private ATB _atb;
        public ATB Atb { get => _atb; }

        public bool ReadyForAttack { get; set; } = false;

        private void Awake()
        {
            _atb = GetComponent<ATB>();
            _atb._onReadyToAttack += _ReadyForAttack;

             if(ID == 0)
                UIEventBus.Subscribe(UIEventTypes.ENEMY1ATTACK, new EnemyAttackedHandler(UIEventTypes.ENEMY1ATTACK));
            else if(ID == 1)
                UIEventBus.Subscribe(UIEventTypes.ENEMY2ATTACK, new EnemyAttackedHandler(UIEventTypes.ENEMY2ATTACK));
            else
                UIEventBus.Subscribe(UIEventTypes.ENEMY3ATTACK, new EnemyAttackedHandler(UIEventTypes.ENEMY3ATTACK));
        }

        private void _ReadyForAttack(Attacker attacker)
        {
            ReadyForAttack = true;
        }

    }

    public class EnemyAttackedHandler: IEventListener
    {
        private UIEventTypes _type;
        public EnemyAttackedHandler(UIEventTypes type)
        {   
            _type = type;
        }
        public void Update(ISubject subject)
        {
            HandleEvent(subject as Harris.GPC.Event);
        }
        public void HandleEvent(Harris.GPC.Event ev)
        {
            
            AttackInfo attackInfo = new AttackInfo(Attacker.CurrentAttacker, "Attack", Time.time);

            if(_type == UIEventTypes.ENEMY1ATTACK && Attacker.CurrentAttacker.AttackingEnabled) 
            {
                Debug.Log("Enemy 1 was attacked at Time: " + (ev as UIEvent).OccuredTime);

                GameManager.Instance.Enemies[0].GetComponent<Attacker>().AddIncomingAttack(attackInfo);

                Attacker.CurrentAttacker.AttackingEnabled  = false;
            }
            else if(_type == UIEventTypes.ENEMY2ATTACK && Attacker.CurrentAttacker.AttackingEnabled) 
            {
                Debug.Log("Enemy 2 was attacked at Time: " + (ev as UIEvent).OccuredTime);

                GameManager.Instance.Enemies[1].GetComponent<Attacker>().AddIncomingAttack(attackInfo);

                Attacker.CurrentAttacker.AttackingEnabled  = false;
            }
            else if(_type == UIEventTypes.ENEMY3ATTACK && Attacker.CurrentAttacker.AttackingEnabled) 
            {
                Debug.Log("Enemy 3 was attacked at Time: " + (ev as UIEvent).OccuredTime);

                GameManager.Instance.Enemies[2].GetComponent<Attacker>().AddIncomingAttack(attackInfo);

                Attacker.CurrentAttacker.AttackingEnabled  = false;
            }
        }
    }
}