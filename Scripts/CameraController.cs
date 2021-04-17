using UnityEngine;

namespace Something
{
    public class CameraController : Starter
    {
        public CameraController()
        {
            cam.transform.position = player.transform.position + offset;
        }
        
    }
}