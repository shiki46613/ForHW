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
    public class DeBuff : Starter
    {
        public UnityEvent someEvent;
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(player.tag))
            {
                switch (tag)
                {
                    case "lowSpeed":
                        movementSpeed /= 2;
                        break;
                    case "fastSpeed":
                        movementSpeed *= 2;
                        break;
                    case "death":
                        player.SetActive(false);
                        //someEvent.AddListener(Camera.main.backgroundColor. );
                        break;
                    case "pointToWin":
                        count++;
                        break;
                }

                Destroy(gameObject);
            }
        }

    }
}
