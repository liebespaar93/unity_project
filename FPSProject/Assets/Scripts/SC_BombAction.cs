using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BombAction : MonoBehaviour
{
    public GameObject exploFactory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        //throw new NotImplementedException();
        
        GameObject explo = Instantiate(exploFactory);

        explo.transform.position = this.transform.position;
        
        Destroy(this.gameObject);
    }
}
