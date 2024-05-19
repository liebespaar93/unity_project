using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hp = 1.0f;
    public float speed = 1.0f;
    public float power = 1.0f;

    public ScStage stage;
    
    // Update is called once per frame
    private void Update()
    {
        if (stage.IsUnityNull())
            return;
        if (stage.GetGameOver())
            Destroy(this.gameObject);
        this.transform.position -= this.transform.up * (speed * Time.deltaTime * 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        var castleTemp = other.GetComponentInParent<ScCastle>();
        if (castleTemp.IsUnityNull())
            return;
        castleTemp.Hit(this.power);
        Destroy(this.gameObject);
    }

    public bool HitEnemy(float hit)
    {
        print("hit eney" + this.hp);
        this.hp -= hit;
        if (this.hp > 0)
            return false;
        Destroy(this.gameObject);
        return true;
    }
}
