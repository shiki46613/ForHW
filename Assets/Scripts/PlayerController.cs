using UnityEngine;

namespace Something
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        private Quaternion rotation = Quaternion.identity;
        private Vector3 move;

        public void CharacterMovement()
        {
            move = Starter.player.transform.position;

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            MovementManager(3, 8);
            move.Set(horizontal, 0f, vertical);
            move.Normalize();

            Vector3 desiredForward = Vector3.RotateTowards(Starter.player.transform.forward,
                move, AllVariables.MovementSpeed * Time.deltaTime, 0f);
            rotation.Normalize();
            rotation = Quaternion.LookRotation(desiredForward);
        }

        public void MovementManager(float horizontal, float vertical)
        {
            
        }
    }
}