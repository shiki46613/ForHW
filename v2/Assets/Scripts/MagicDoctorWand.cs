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
    private Vector3 _position;
    private Vector3 target;
    private Vector3 targetDirection;
    private AudioSource audioSourse;
    private Animator _Animator;

    private void Start()
    {
        _Animator = GetComponentInParent<Animator>();
        audioSourse = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            tagArr = GameObject.FindGameObjectsWithTag(_checkedTag);
            if (tagArr.Length <= _maxAtTheSameTime)
            {
                _Animator.SetTrigger(_animationName);
                //MagicShot();
            }
        }
    }

    public void MagicShot()
    {
        Debug.Log(" OK ");
        audioSourse.Play();
        _position = gameObject.transform.position;
        target = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        targetDirection = target - _position;
        var newMagic = Instantiate(_magicPrefab, _position, Quaternion.identity, transform);
        var newMagicBody = newMagic.GetComponent<Rigidbody>();
        newMagicBody.AddForce(targetDirection * _initialForce);
    }

}