using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBoom : MonoBehaviour
{
    //[SerializeField] private string _detectTag;
    [SerializeField] private float _expload;
    [SerializeField] private float _area;
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        //if(!other.CompareTag(_detectTag)) return;
        var otherBody = other.gameObject.GetComponent<Rigidbody>();

        if(otherBody)
        {
            otherBody.AddExplosionForce(_expload, transform.position, _area);
            Health _hpCount = other.gameObject.GetComponent<Health>();
            _hpCount.TakeHit(_damage);
        }
        
        Destroy(gameObject);
    }
}
