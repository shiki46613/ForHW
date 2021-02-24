using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDoctorWand : MonoBehaviour
{
    [Header("Magic settings")]
    [SerializeField] private GameObject _magicPrefab;
    [SerializeField] private float _initialForce;
    [SerializeField] private string _checkedTag;
    [SerializeField] private int _maxAtTheSameTime;
    [SerializeField] private Camera _camera;

    [Header("Animation")]
    [SerializeField] private string _animationName;
    private UnityEngine.GameObject[] tagArr;
    Vector3 _position;
    Vector3 target;
    Vector3 targetDirection;
    private AudioSource audioSourse;

    private Animator _Animator;
    private void Start()
    {
        _Animator = GetComponentInParent<Animator>();
        audioSourse = GetComponent<AudioSource>();
        //PlayerInputForMagic.OnInput += MagicShot;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            audioSourse.Play();
            _Animator.SetTrigger(_animationName);
            _position = gameObject.transform.position;

            // target = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            // targetDirection = target - _position;

            MagicShot(_position);
            // var newMagic = Instantiate(_magicPrefab, _position, Quaternion.identity, transform);
            // var newMagicBody = newMagic.GetComponent<Rigidbody>();

            // newMagicBody.AddForce(targetDirection * _initialForce);
        }
    }
    private void MagicShot(Vector3 _position)
    {
        target = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        targetDirection = target - _position;
        tagArr = GameObject.FindGameObjectsWithTag(_checkedTag);
        if (tagArr.Length <= _maxAtTheSameTime)
        {
            var newMagic = Instantiate(_magicPrefab, _position, Quaternion.identity, transform);
            var newMagicBody = newMagic.GetComponent<Rigidbody>();

            newMagicBody.AddForce(targetDirection * _initialForce);
            //         if (Input.GetMouseButtonDown(0))
            //         {
            //             Debug.Log("==== OK ====");
            //             var newMagic = Instantiate(_magicPrefab, transform.position, Quaternion.identity, transform);
            //             var newMagicBody = newMagic.GetComponent<Rigidbody>();

            //             _Animator.SetTrigger(_animationName);
            //             newMagicBody.AddForce((inputMoveDirection - transform.position) * _initialForce);
            //             Destroy(newMagic, _destroyTime);
            //         }
        }
    }


}