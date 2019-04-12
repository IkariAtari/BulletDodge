using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

namespace Player
{
    public class PlayerControl : MonoBehaviour
    {
        public int normalSpeed;
        public int shiftSpeed;
        public int slowSpeed;

        private int _currentSpeed;

        private Player _player;

        private bool _canShoot;

        public int useTime;
        private int _timerVar;
        
        private void Start()
        {
            _player = GetComponent<Player>();
        }
        
        private void Update()
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            float yInput = Input.GetAxisRaw("Vertical");
            
            Vector2 velocity = new Vector2(xInput, yInput);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _currentSpeed = shiftSpeed;
            }

            else if (Input.GetKey(KeyCode.LeftControl))
            {
                _currentSpeed = slowSpeed;
            }
           
            else 
            {
                _currentSpeed = normalSpeed;
            }

            if (_canShoot)
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    Shoot(_player.projectile);
                    _canShoot = false;
                    _timerVar = useTime;
                }
            }

            if (_canShoot == false)
            {                  
                if(_timerVar > 0)
                {
                    _timerVar--;
                }
                else
                {
                    _canShoot = true;
                }
            }
        
            Move(velocity);                                   
        }

        private void Move(Vector2 velocity)
        {
            transform.Translate(velocity * _currentSpeed * Time.deltaTime);         
        }

        private void Shoot(GameObject projectile)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);               
        }
    }
}
