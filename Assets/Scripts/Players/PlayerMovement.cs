using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Originn.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        public float _normalSpeed = 5f;        
        public float _runSpeed = 10f;        

        private Vector2 _moveInput;
        private Vector2 _velocity = Vector2.zero; 

        private Rigidbody2D _rb;
        private float _speed;
        private bool _isSprinting = false;

        [SerializeField]
        private Animator _animator;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>(); 
            _speed = _normalSpeed;
            // No affect from Gravity
            _rb.gravityScale = 0;
            _rb.freezeRotation = true;
        }

        void Update()
        {

            // Get input from WASD keys
            _moveInput.x = Input.GetAxis("Horizontal");
            _moveInput.y = Input.GetAxis("Vertical");

            // Shift is working 
            if(_moveInput == Vector2.zero)
            {
                _speed = _normalSpeed;
                _isSprinting = false;
            }

            if(Input.GetButton("SprintKey"))
            {
                _isSprinting = true;
                _speed = _runSpeed;
            }
            else
            {
                _isSprinting = false;
                _speed = _normalSpeed;
            }

            //checker to make sure diagnoals arent faster
            _moveInput = Vector2.ClampMagnitude(_moveInput, 1);

            //apply movement
            Move(_moveInput * _speed);
            
        }

        //if player hits wall
        private void SprintBump()
        {
            if(_isSprinting)
                _isSprinting = false;
            _speed = _normalSpeed;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            SprintBump();
        }

        void Move(Vector2 targetVelocity) //Move
        {
            _velocity = targetVelocity;
            _rb.velocity = _velocity;

            _animator.SetFloat("Horizontal", _moveInput.x);
            _animator.SetFloat("Vertical", _moveInput.y);
            _animator.SetFloat("Speed", _moveInput.sqrMagnitude);
        }

    }
}
