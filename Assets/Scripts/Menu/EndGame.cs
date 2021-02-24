using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(GameObject.FindGameObjectWithTag("MainCamera"));
            SceneManager.LoadScene(0);
        }
    }
}
