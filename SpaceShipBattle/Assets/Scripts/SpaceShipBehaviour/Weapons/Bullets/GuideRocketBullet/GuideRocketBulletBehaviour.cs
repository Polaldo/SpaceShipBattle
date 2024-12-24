using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SpaceShipBehaviour.Weapons.Bullets.GuideRocketBullet
{
    public class GuideRocketBulletBehaviour : BulletBehaviour
    {
        public float forwardDistance;  
        public float forwardSpeed;     
        public float turnRadius;       
        public float turnSpeed;      
        public float finalSpeed;       
        private float angle = 0f; 
        private float maxAngle = 3 * Mathf.PI / 2;
        public float radius;
        private Vector3 center;

        private bool isTurning = false;     
        private bool headingToPlayer = false; 
        private Transform playerTransform;

        private void Awake()
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }

        private void Start()
        {
            playerTransform = PlayerManager.Instance.GetPlayer().transform;
            
        }

        private void Update()
        {
            if (!isTurning && !headingToPlayer)
            {
                MoveForward();
            }
            else if (isTurning && !headingToPlayer)
            {
                DoCircularMovement();
            }
            else if (headingToPlayer)
            {
                DistanceBullet();
                MoveTowardsPlayer(); 
            }
        }

        void MoveForward()
        {
            float step = forwardSpeed * Time.deltaTime;
            transform.position += Vector3.down * step;
            currentDistance += step;

            if (currentDistance >= forwardDistance)
            {
                isTurning = true;
                currentDistance = 0f;
                InitialPosition = transform.position;
                center = new Vector3(transform.position.x - radius, 0, 0);
            }
        }

        void DoCircularMovement()
        {
            float deltaAngle = turnSpeed * Time.deltaTime;
            angle += deltaAngle;

            if (Mathf.Abs(angle) >= maxAngle)
            {
                angle = Mathf.Sign(angle) * maxAngle; 
                isTurning = false;
                headingToPlayer = true;
                InitialPosition = transform.position;
            }

            float x = center.x + Mathf.Cos(angle) * radius;
            float y = center.y + Mathf.Sin(angle) * radius;

            transform.position = new Vector3(x, y, transform.position.z);
        }

        void MoveTowardsPlayer()
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float smoothAngle = Mathf.LerpAngle(transform.eulerAngles.z, angle + 90f, 25 * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, smoothAngle);

            transform.position += direction * finalSpeed * Time.deltaTime;
        }

        public override void DistanceBullet()
        {
            currentDistance = Vector3.Distance(InitialPosition, transform.position);
            if (currentDistance >= BulletDistance)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
