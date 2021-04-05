using System;
using UnityEngine;

namespace Something
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] internal GameObject player;
        [SerializeField] internal float movementSpeed;
        [SerializeField] internal int count;
        [SerializeField] internal Camera cam;
        internal Vector3 offset;
        private void Start()
        {
            offset = cam.transform.position - player.transform.position;
        }

        private void FixedUpdate()
        {
            new CharacterMovement();
            new DeBuff();
            new EndGame();
            new CameraController();
        }

    }
}