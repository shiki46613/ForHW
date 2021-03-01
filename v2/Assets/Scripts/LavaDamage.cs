using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour

{
    [SerializeField] private int _damage;
    void OnCollisionStay(Collision col)
    {
        StartCoroutine(EnemyDamage(col));
    }

    IEnumerator EnemyDamage(Collision col)
{
    Health _hpCount = col.gameObject.GetComponent<Health>();
            _hpCount.TakeHit(_damage);
    yield return new WaitForSeconds(6);
}
}
