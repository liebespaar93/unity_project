using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Script
{
}
public class Floor : MonoBehaviour
{
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
        if (other.gameObject.transform.name.Contains("Player"))
        {
            print("Player die");
            print("Game Over");
            Destroy(other.gameObject);
        }
        // throw new NotImplementedException();
    }
}
