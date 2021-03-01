using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class CharacterMove : MonoBehaviour
{
    private Animator _Animator;
    private Rigidbody _Rigidbody;
    [SerializeField] private float _jumpForce;
    private Vector3 _Movement;
    private Quaternion _Rotation = Quaternion.identity;
    [SerializeField] private float _speed;
    private AudioSource audioSourse;
    private bool _isGrounded;

    void Start()
    {
        _Animator = GetComponent<Animator>();
        _Rigidbody = GetComponent<Rigidbody>();
        audioSourse = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Movement();
        Jump();
        BlendTreeAnim();
    }

    void OnAnimatorMove()
    {
        _Rigidbody.MovePosition(_Rigidbody.position + _Movement * _Animator.deltaPosition.magnitude);
        _Rigidbody.MoveRotation(_Rotation);
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
            {
                _Animator.SetBool("IsWalking", true);
                
            }
            else
            {
                _Animator.SetBool("IsWalking", false);
            }
        _Movement.Set(horizontal, 0f, vertical);
        _Movement.Normalize();

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _Movement, _speed * Time.deltaTime, 0f);
        _Rotation.Normalize();
        _Rotation = Quaternion.LookRotation(desiredForward);

    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _Animator.SetTrigger("IsJump");
                _Rigidbody.AddForce(Vector3.up * _jumpForce);
            }
            else
            {
                //_Animator.SetBool("Idle", true);
                _Rigidbody.AddForce(Vector3.zero);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }

    private void BlendTreeAnim()
    {
        if(Input.GetKeyDown("g"))
        {
            _Animator.SetBool("ghost", true);
        }
        if(Input.GetKeyUp("g"))
        {
            _Animator.SetBool("ghost", false);
        }
    }

    public void FootStep()
    {
        audioSourse.Play();
    }
}