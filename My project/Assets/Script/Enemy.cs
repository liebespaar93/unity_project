using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5.0f;
    
    private Vector3 dir;

    // effect
    public GameObject explosionFactory;
    void Start()
    {
        int randomNum = Random.Range(0, 10);

        if (randomNum > 3)
        {
            dir = Vector3.down;
        }
        else
        {
            GameObject player = GameObject.Find("Player");
            dir = player.transform.position - this.transform.position;
            dir.Normalize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += this.dir * (this.speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject explosion = Instantiate(explosionFactory);
        explosionFactory.transform.position = this.transform.position;
        
        if (other.gameObject.name.Contains("Bullet"))
        {
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        Destroy(this.gameObject);
        // throw new NotImplementedException();
    }
}
