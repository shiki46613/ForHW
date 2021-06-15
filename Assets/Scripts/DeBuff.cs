using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Something
{
    public class DeBuff : MonoBehaviour, IDeBuff
    {
        public UnityEvent myEvent;

        public void DeBuffOnCollision()
        {
            
            
        }

        static void TestDeBuff()
        {
            Debug.Log("TEST " + AllVariables.MovementSpeed + " _ " + AllVariables.BonusCount);
    }
        private void OnEnable()
        {
            if (myEvent == null)
                myEvent = new UnityEvent();

            myEvent.AddListener(TestDeBuff);
        }

        private void OnDisable()
        {
            myEvent ??= new UnityEvent();

            myEvent.RemoveListener(TestDeBuff);
        }

        private void OnCollisionEnter(Collision other)
        {
            switch (other.gameObject.tag)
            {
                case "lowSpeed":
                    AllVariables.MovementSpeed /= 2;
                    myEvent?.Invoke();
                    Destroy(other.gameObject);
                    break;
                case "fastSpeed":
                    AllVariables.MovementSpeed *= 2;
                    myEvent?.Invoke();
                    Destroy(other.gameObject);
                    break;
                case "death":
                    Starter.player.SetActive(false);
                    myEvent?.Invoke();
                    Destroy(other.gameObject);
                    break;
                case "pointToWin":
                    AllVariables.BonusCount++;
                    myEvent?.Invoke();
                    Destroy(other.gameObject);
                    break;
                default:
                    Debug.Log("None");
                    break;
            }
            
        }
    }
}