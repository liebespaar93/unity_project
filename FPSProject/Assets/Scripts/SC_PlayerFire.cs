using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_PlayerFire : MonoBehaviour
{
    private bool mouseLeftState = false;
    public GameObject bombFactory;

    public GameObject firePos;

    public float firePower = 100;

    public GameObject bulletimpactFactory;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFactory);

            bomb.transform.position = firePos.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * firePower); 
        }
        else
        {
            
        }

        if (Input.GetMouseButton(0) && !mouseLeftState)
        {
            mouseLeftState = true;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitinfo = new RaycastHit();
            
            // hit some one effect shot
            if (Physics.Raycast(ray, out hitinfo))
            {
                Debug.Log("hit Object" + hitinfo.transform.name);
                GameObject bulletEffect = Instantiate(bulletimpactFactory);
                
                bulletEffect.transform.position = hitinfo.point;
                bulletEffect.transform.forward = hitinfo.normal;
                Destroy(bulletEffect, 2);
            }
            
            // hit enemy one damge
            if (hitinfo.transform.gameObject.name.Contains("Enemy"))
            {
                SC_Enemy enemy = hitinfo.transform.GetComponent<SC_Enemy>();

                enemy.onDamaged();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseLeftState = false;
        }
            
    }
    
}