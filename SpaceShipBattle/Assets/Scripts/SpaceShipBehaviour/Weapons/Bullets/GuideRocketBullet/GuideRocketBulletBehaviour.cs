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
        public float forwardDistance = 5f;  // Distancia a recorrer inicialmente en línea recta
        public float forwardSpeed = 5f;     // Velocidad del movimiento hacia adelante
        public float turnRadius = 3f;       // Radio de la vuelta
        public float turnSpeed = 100f;      // Velocidad de giro para la vuelta
        public float finalSpeed = 7f;       // Velocidad final hacia el jugador

        private bool isTurning = false;     // Indicador de si está en fase de giro
        private bool headingToPlayer = false; // Indicador de si está yendo hacia el jugador
        private float turnAngle = 0f;

        private void Update()
        {
            if (!isTurning && !headingToPlayer)
            {
                // 1. Fase de avance inicial
                MoveForward();
            }
            else if (isTurning && !headingToPlayer)
            {
                // 2. Fase de giro
                DoTurn();
            }
            else if (headingToPlayer)
            {
                // 3. Fase final: dirigirse al jugador
                MoveTowardsPlayer();
                DistanceBullet();
            }
        }

        void MoveForward()
        {
            // Mover el cohete hacia adelante en la dirección actual
            float step = forwardSpeed * Time.deltaTime;
            transform.position += transform.forward * step;
            currentDistance += step;

            // Si se ha alcanzado la distancia hacia adelante, pasar a la fase de giro
            if (currentDistance >= forwardDistance)
            {
                isTurning = true;
                currentDistance = 0f;
                InitialPosition = transform.position;
            }
        }

        void DoTurn()
        {
            // Realizar la vuelta en círculo
            turnAngle += turnSpeed * Time.deltaTime;
            float xOffset = Mathf.Cos(turnAngle) * turnRadius;
            float zOffset = Mathf.Sin(turnAngle) * turnRadius;

            // Actualizar la posición en función del ángulo
            transform.position = InitialPosition + new Vector3(xOffset, 0, zOffset);

            // Al completar una vuelta, pasar a la fase final
            if (turnAngle >= 2 * Mathf.PI)  // Una vuelta completa en radianes
            {
                isTurning = false;
                headingToPlayer = true;
                InitialPosition = transform.position;
            }
        }

        void MoveTowardsPlayer()
        {
            // Mover el cohete hacia el jugador
            Transform playerTransform = PlayerManager.Instance.GetPlayer().transform;
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * finalSpeed * Time.deltaTime;
            transform.LookAt(playerTransform);  // Apuntar al jugador mientras se mueve
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
