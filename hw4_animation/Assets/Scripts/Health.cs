using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _hpCount;
    [SerializeField] private int _maxHPCount;
    
    public void TakeHit(int damage)
    {
        _hpCount -= damage;
        if(_hpCount <= 0) 
        {
            Destroy(gameObject);
        }
    }

    public void SetHealth(int addHealth)
    {
        _hpCount += addHealth;
        if(_hpCount > _maxHPCount) _hpCount = _maxHPCount;
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(Screen.width - 70, 0, 60, 20), " HP: " + (_hpCount / 2).ToString());
    }
}
