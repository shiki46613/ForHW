using UnityEngine;

public class MagicDestroy : MonoBehaviour
{
    [SerializeField] float _destroyTime;
    void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
