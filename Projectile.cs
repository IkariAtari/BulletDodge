using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BulletDodge
{
    public class Projectile : MonoBehaviour
    {
        public float projectileSpeed;

        private void Update()
        {
            transform.Translate(new UnityEngine.Vector2(0, projectileSpeed));

            if (transform.position.x < -11 || transform.position.x > 0 || transform.position.y > 6 ||
                transform.position.y < -6)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}

