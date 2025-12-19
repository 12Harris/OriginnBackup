using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Harris.GPC;
using Originn.Game.UI;

namespace Originn.Game.Combat
{
    public struct AttackInfo
    {
        public Attacker attacker;
        public string attackName;
        public float decisionTime;

        public AttackInfo(Attacker att, string att_name, float dt)
        {
            attacker = att;
            attackName = att_name;
            decisionTime = dt;
        }
    };

    /// <summary>
    /// Handles functionality related to attacking other Attackeables
    /// and processes incoming attacks directed towards this attacker
    /// </summary>
    public class Attacker : MonoBehaviour, IAttacker
    {
        public bool IsAttacking { get; set; } = false;

        public bool IsTargetted{ get; set; } = false;
        public bool IsBeingAttacked { get; set; } = false;

        [SerializeField]
        [Range(0,2)]
        private float _attackDuration;

        [SerializeField]
        [Range(0,1f)]
        private float _attackDelay;

        public float AttackDelay => _attackDelay;


        private Health _health;

        public Health Health => _health;

        public event Action _onStartedAttacking;
        public event Action _onStoppedAttacking;

        public IAttackable Target { get; set; }

        [SerializeField]
        private int _id;

        public int ID => _id;

        /// <summary>
        /// Queue of incoming attacks directed to this Attacker
        /// The queue also stores the Attacker associated with he attacks
        /// and the time at which attacks where added to the queue
        /// </summary>
        //private Queue<(Attacker, string, float)> _incomingAttacks;
        private Queue<AttackInfo> _incomingAttacks;

        public static Attacker CurrentAttacker {get;set;} = null;

        public bool AttackingEnabled{get;set;} 

        private void ProcessIncomingAttacks()
        {

            if (_incomingAttacks.Count > 0)
            {
                AttackInfo incomingAttack = _incomingAttacks.Peek();
                Attacker otherAttacker = incomingAttack.attacker;
                string attackName = incomingAttack.attackName;

                AttackInfo attackerIncomingAttack = default(AttackInfo);

                if (otherAttacker._incomingAttacks.Count > 0)
                    attackerIncomingAttack = otherAttacker._incomingAttacks.Peek();

                if (IsAttacking)
                {
                    return;
                }

                if (!IsTargetted && !otherAttacker.IsTargetted
                && attackerIncomingAttack.Equals(default(AttackInfo)) || ((float)incomingAttack.decisionTime < (float)attackerIncomingAttack.decisionTime))
                {
                    _incomingAttacks.Dequeue();
                    //attacker.StartCoroutine(attacker.Attack(this));
                    otherAttacker.Attack(this, attackName);
                }
            }
        }

        public virtual void Awake()
        {
           
        }

        public void AddIncomingAttack(AttackInfo attackInfo)
        {
            attackInfo.attacker.Target = this;
            _incomingAttacks.Enqueue(attackInfo);
        }

        // Start is called before the first frame update
        public virtual void Start()
        {
            _health = GetComponent<Health>();
            _incomingAttacks = new Queue<AttackInfo>();
        }

        // Update is called once per frame
        void Update()
        {
            ProcessIncomingAttacks();
        }

        public void Attack(IAttackable other, string attackName)
        {
            other.IsTargetted = true;
            StartCoroutine(_Attack(other, attackName));
        }

        public void DrainHealth(int amount)
        {
            _health.DrainHealth(amount);
        }


        private int CalculateDamage(string attack)
        {
            return 10;
        }

        private IEnumerator _Attack(IAttackable other, string attackName)
        {
            //yield return new WaitForSecondsRealtime(_attackDelay);
            yield return new WaitForSeconds(_attackDelay);
            _onStartedAttacking?.Invoke();
            IsAttacking = true;
            other.IsBeingAttacked = true;
            Debug.Log(this + " attacked " + other);
            other.DrainHealth(CalculateDamage(attackName));
            //yield return new WaitForSeconds(_attackDelay);
            yield return new WaitForSeconds(_attackDuration);//Attacks take 2 seconds to complete
            _onStoppedAttacking?.Invoke();
            other.IsBeingAttacked = false;
            IsAttacking = false;
            other.IsTargetted = false;
            Target = null;
        }
    }
}