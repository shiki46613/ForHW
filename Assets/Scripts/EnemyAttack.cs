using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private string _targetTag;
    [SerializeField] private string _animationName;
    private Animator _Animator;
    void Start()
    {
        _Animator = GetComponentInParent<Animator>();
    }
    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == _targetTag)
        {
            _Animator.SetTrigger(_animationName);
        }
    }
}
