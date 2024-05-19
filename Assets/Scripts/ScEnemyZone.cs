using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScEnemyZone : MonoBehaviour
{
    public ScStage stage;
    
    public EnemyController enemyGameObject;
    public float createDelay = 10.0f;
     
    private float _currTime = 0.0f;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (stage.IsUnityNull())
            return;
        if (stage.GetGameOver())
            return;
        if (enemyGameObject.IsUnityNull())
            return;
        _currTime += Time.deltaTime;
        if (_currTime < createDelay)
            return;
        _currTime = 0.0f;
        var enemyObj = GameObject.Instantiate<EnemyController>(enemyGameObject, this.transform.position, this.transform.rotation);
        enemyObj.transform.parent = this.transform.parent;
        enemyObj.stage = this.stage;
    }

}
