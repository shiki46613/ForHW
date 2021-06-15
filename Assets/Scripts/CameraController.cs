using UnityEngine;

namespace Something
{
    public class CameraController : MonoBehaviour
    {
        public CameraController()
        {
            Starter.cam.transform.position = Starter.player.transform.position + Starter.cameraOffset;
        }
        
    }
}