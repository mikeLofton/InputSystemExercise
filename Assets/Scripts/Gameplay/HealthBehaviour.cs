using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _health;
    [SerializeField]
    private bool _destroyOnDeath;
    private bool _isAlive = true;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
            _health = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _isAlive = _health > 0;

        if (_destroyOnDeath && !_isAlive)
            Destroy(gameObject);
    }
}
