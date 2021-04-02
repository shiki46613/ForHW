using System;
using UnityEngine;

namespace Something
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private float movementSpeed;
        [SerializeField] private int count;
        private void Start()
        {
        
        }

        private void Update()
        {
            new CharacterMovement(movementSpeed);
            new DeBuff();
            new EndGame();
        }

    }
}