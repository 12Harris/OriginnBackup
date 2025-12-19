using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System;
using System.Collections.Generic;
using Originn.Game.Combat;
using Originn.Game.Player;
using Originn.Game;
using Harris.GPC;

namespace Originn.Game.NPC.Enemy
{
    public class EnemyAI : MonoBehaviour
    {

        private List<GameObject> _enemies;
        private List<GameObject> _allies;

        private Enemy _readyEnemy = null;

        public void Awake()
        {

        }
        // Start is called before the first frame update
        void Start()
        {
            /*List<Attacker> attackerList = new List<Attacker>();
            foreach (var character in GameManager.Instance.SelectableCharacters)
            {
                attackerList.Add(character.ThisAttacker);
            }

            Predicate<Attacker> isEnemy = (x) =>
            {
                return x is Enemy;
            };

            var enemies = attackerList.FindAll(isEnemy);*/

            _enemies = GameManager.Instance.Enemies;
            _allies = GameManager.Instance.Allies;

        }

        // Update is called once per frame
        void Update()
        {
            foreach(var enemy in _enemies)
            { 
                if((enemy.GetComponent<Enemy>()).ReadyForAttack)
                {
                    Debug.Log("Enemy " + enemy + " ready for attack!");
                    var target = ChooseAttackTarget();
                    if (target != null)
                    {
                        target.AddIncomingAttack(new AttackInfo(enemy.GetComponent<Enemy>(), "Attack",Time.time));
                    }
                    (enemy.GetComponent<Enemy>()).ReadyForAttack = false;
                }
            }
        }

        private Ally GetRandomTarget()
        {
            return _allies[UnityEngine.Random.Range(0, _allies.Count)].GetComponent<Ally>();
        }

        private Ally ChooseAttackTarget()
        {
            Ally target = null;
            foreach(var ally in _allies)
            {
                if (ally.GetComponent<Health>().CurrentHealth <= 0)
                    continue;

                if (ally.GetComponent<Ally>().IsAttacking)
                    continue;

                if (ally.GetComponent<Ally>().IsTargetted)
                    continue;

                target = ally.GetComponent<Ally>();
                break;
            }

            if (target == null)
                target = GetRandomTarget();
            return target;
        }
    }
}