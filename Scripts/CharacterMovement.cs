using UnityEngine;

namespace Something
{
    public class CharacterMovement
    {
        [SerializeField] private GameObject player;
        private Quaternion rotation = Quaternion.identity;
        private Vector3 move;

        public CharacterMovement(float movementSpeed)
        {
            move = player.transform.position;

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            move.Set(horizontal, 0f, vertical);
            move.Normalize();

            Vector3 desiredForward = Vector3.RotateTowards(player.transform.forward,
                move, movementSpeed * Time.deltaTime, 0f);
            rotation.Normalize();
            rotation = Quaternion.LookRotation(desiredForward);
            
        }
    }
}