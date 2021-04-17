using System;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Something
{
    public partial class Starter : MonoBehaviour
    {
        internal static GameObject player;
        internal static Camera cam;
        [SerializeField] internal float movementSpeed;
        [SerializeField] internal int count;
        internal Vector3 offset;

        
        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            cam = Camera.main;
            offset = cam.transform.position - player.transform.position;
        }
        
        // private void FixedUpdate()
        // {
        //     DeBuff();
        //     CharacterMovement();
        //     CameraController();
        //     EndGame();
        //     
        // }


       
    }
}