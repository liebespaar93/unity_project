using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float power = 1.0f;
    public float fireDelay = 1.0f;
    public float detectionRange = 1.0f;
    public ScAttackObject attackObject;
    private float _currTime = 0.0f;
    private CircleCollider2D _collider;

    private void Start()
    {
        _collider = this.gameObject.GetComponent<CircleCollider2D>();
        _collider.radius = detectionRange;
    }

    private void Update()
    {
        _currTime += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(_currTime< fireDelay)
            return;
        _currTime = 0.0f;
        var enemyTemp = other.GetComponentInParent<EnemyController>();
        if (enemyTemp.IsUnityNull())
            return;
        var attackTemp =
            GameObject.Instantiate<ScAttackObject>(attackObject, this.transform.position, this.transform.rotation);
        attackTemp.SetAttackInfo((other.transform.position - this.transform.position).normalized, this.power);
        
    }
}
