using UnityEngine;

namespace Something
{
    public class CharacterMovement
    {
        private Quaternion rotation = Quaternion.identity;
        private Vector3 move;
        
        internal void CharMovement()
        {
            move = Starter.player.transform.position;

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            move.Set(horizontal, 0f, vertical);
            move.Normalize();

            Vector3 desiredForward = Vector3.RotateTowards(Starter.player.transform.forward,
                move, Starter.movementSpeed * Time.deltaTime, 0f);
            rotation.Normalize();
            rotation = Quaternion.LookRotation(desiredForward);
        }
    }
}