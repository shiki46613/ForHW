using UnityEngine;
using UnityEngine.Events;

namespace Something
{
    public class DeBuff
    {
        public UnityEvent someEvent;

        internal void DeBuffOnCollision()
        {
            void OnCollisionEnter(Collision other)
            {
                if (!other.gameObject.CompareTag(Starter.player.tag)) return;
                switch (tag)
                {
                    case "lowSpeed":
                        
                        break;
                    case "fastSpeed":
                        Starter.movementSpeed *= 2;
                        break;
                    case "death":
                        Starter.player.SetActive(false);
                        //someEvent.AddListener(Camera.main.backgroundColor. );
                        break;
                    case "pointToWin":
                        Starter.count++;
                        break;
                }

                Destroy(gameObject);
            }
        }
    }
}