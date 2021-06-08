using UnityEngine;

namespace Something
{
    public class CameraController
    {
        public CameraController()
        {
            Starter.cam.transform.position = Starter.player.transform.position + Starter.offset;
        }
        
    }
}