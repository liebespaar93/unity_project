using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DestroyExplo : MonoBehaviour
{
    private float currenTime = 0;

    public float destroyTime = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currenTime += Time.deltaTime;
        if (currenTime > destroyTime)
        {
            Destroy(this.gameObject);
        }
    }
}
