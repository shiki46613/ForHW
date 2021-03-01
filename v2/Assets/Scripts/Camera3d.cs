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
        // if (Input.GetButton("Fire2"))
        // {
            
        //     Vector3 _oldMousePos = Input.mousePosition;
        //     if(Input.GetButtonUp("Fire2"))
        //     {
        //         ScrollView(_oldMousePos, _newMousePos);
        //     }
            
        // }
        if (!Input.GetButton("Fire2"))
        {
            transform.position = _target.transform.position + offset;
        }
    }

    // private void ScrollView(Vector3 _oldPos, Vector3 _newPos)
    // {
    //     _newMousePos = Input.mousePosition;
    //     transform.position = _target.transform.position + offset + (_oldPos - _newMousePos);
    //     Debug.Log(_oldPos + "__" + _newMousePos);
    // }
}