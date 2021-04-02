using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

namespace Something
{
    public class DeBuff : MonoBehaviour
    {
        private string playerTag = "Player";
        private int count;
        public UnityEvent someEvent;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(playerTag))
            {
                switch (tag)
                {
                    case "lowSpeed":
                        //count = Starter movementSpeed / 2;
                        new CharacterMovement(count);
                        //someEvent.AddListener();
                        break;
                    case "fastSpeed":
                        //count = Starter movementSpeed * 2;
                        new CharacterMovement(count);
                        //someEvent.AddListener();
                        break;
                    case "death":
                        other.gameObject.SetActive(false);
                        //someEvent.AddListener(Camera.main.backgroundColor. );
                        break;
                    case "pointToWin":
                        //count++;
                        break;
                }

                Destroy(gameObject);
                
            }
        }

    }
}
