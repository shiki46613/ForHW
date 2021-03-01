using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _addHealth;
    [SerializeField] private string _collisionTag;
    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == _collisionTag)
        {
            Health _hpCount = col.gameObject.GetComponent<Health>();
            _hpCount.SetHealth(_addHealth);
            Destroy(gameObject);
        }
    }
}
