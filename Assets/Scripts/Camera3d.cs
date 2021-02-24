using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3d : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private Vector3 offset;  

    void Start () 
    {        
        offset = transform.position - _target.transform.position;
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire2"))
        {
            Vector3 _oldMousePos = Input.mousePosition;
            ScrollView(_oldMousePos);
        }
    }
    void LateUpdate() 
    {        
        transform.position = _target.transform.position + offset;
    }

    private void ScrollView(Vector3 _oldMousePos)
    {
        transform.position = _oldMousePos;
        Debug.Log(_oldMousePos);
    }
}