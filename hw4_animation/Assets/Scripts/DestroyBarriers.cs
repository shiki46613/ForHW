using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBarriers : MonoBehaviour
{
    [SerializeField] private string _collisionTag;
    [SerializeField] private string _destroyTag;
    private UnityEngine.GameObject[] tagArr;
    
    void OnTriggerEnter(Collider other)
    {
        tagArr = GameObject.FindGameObjectsWithTag(_destroyTag);

        if (other.gameObject.tag == _collisionTag)
        {
            for (int i = 0; i < tagArr.Length; i++)
                Destroy(tagArr[i]);
        }
    }
}
