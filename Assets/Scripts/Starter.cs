using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Something
{
    public partial class Starter : MonoBehaviour
    {
        internal static GameObject player;
        internal static Camera cam;
        internal static Vector3 cameraOffset;

        
        private void Start()
        {
            AllVariables.MovementSpeed = 10;
            player = GameObject.FindWithTag("Player");
            cam = Camera.main;
            cameraOffset = cam.transform.position - player.transform.position;
        }
        
        private void FixedUpdate()
        {
            //DeBuff();
            // CharacterMovement();
            // CameraController();
            //EndGame();
            
        }
        
    }
    
}