using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBind : MonoBehaviour
{
    public int speed = 5;

    public GameObject BulletFactory;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // key bind Horizontal
        float horiz = Input.GetAxis("Horizontal");
        
        // key bind Horizontal
        float vert = Input.GetAxis("Vertical");

        // direction setting
        Vector3 dir = new Vector3(horiz, vert, 0);
        dir.Normalize();
        
        transform.position = transform.position + dir * (speed * Time.deltaTime);
    }
}
