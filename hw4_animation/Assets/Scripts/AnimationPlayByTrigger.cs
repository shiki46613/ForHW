using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayByTrigger : MonoBehaviour
{
    [SerializeField] private string _triggerTag;
    [SerializeField] private string _animationName;
    [SerializeField] private Animation _animation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _triggerTag)
        {
            _animation = GetComponent<Animation>();
            _animation.Play(_animationName);
        }
    }
}
