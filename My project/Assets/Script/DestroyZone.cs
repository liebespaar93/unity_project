using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            Destroy(other.gameObject);
        }
        // throw new NotImplementedException();
    }
    
}
