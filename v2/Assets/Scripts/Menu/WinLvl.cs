using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLvl : MonoBehaviour
{
    [SerializeField] private int _loadSceneID;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(_loadSceneID > 3)
            {
                DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
                DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MainCamera"));
            }

            SceneManager.LoadScene(_loadSceneID);

            // var sceneAsync = SceneManager.LoadSceneAsync(1);
            // sceneAsync.completed += operation =>
            // {
            //     if (operation.isDone)
            //     operation.allowSceneActivation = true;
            // };
        }
    }
}
