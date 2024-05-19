using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScAttackObject : MonoBehaviour
{
    public float speed = 3.0f;
    
    private float _power = 0.0f;
    private Vector3 _direction;
    private float _lifeTime = 10.0f;
    
    private void Update()
    {
        if (_lifeTime < 0)
            Destroy(this.gameObject);
        this._lifeTime -= Time.deltaTime;
        this.transform.position += this._direction * (speed * Time.deltaTime);
    }

    public void SetAttackInfo(Vector3 dir, float power)
    {
        this._direction = dir;
        this._power = power;
    }

    public void HitEnemy(Collider2D other)
    {
        var enemyTemp = other.GetComponentInParent<EnemyController>();
        if (enemyTemp.IsUnityNull())
            return;
        if (enemyTemp.HitEnemy(this._power))
            print(this.name + ": kill enemy");
        Destroy(this.gameObject);        
    }
}
