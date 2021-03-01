using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputForMagic : MonoBehaviour
{
    private Vector3 _inputAxis;
    [SerializeField] private Camera _camera;

    Vector2 mousePos = new Vector2();
    public static Action<Vector3> OnInput;

    void Update()
    {
        _inputAxis = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y,
                                                            (_camera.transform.position.z - transform.position.z)));
        // _inputAxis.Set(Input.mousePosition.normalized.x,
        //                 Input.mousePosition.normalized.y,
        //                 (_camera.transform.position.z - transform.position.z));
        
        _inputAxis.Set(_inputAxis.x,
                        _inputAxis.y,
                        (_camera.transform.position.normalized.z - transform.position.normalized.z));

        OnInput?.Invoke(_inputAxis);
    }
}
