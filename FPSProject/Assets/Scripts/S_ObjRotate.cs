using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ObjRotate : MonoBehaviour
{
    
    // variable of axis
    public float rotX = 0.0f;
    public float rotY = 0.0f;

    public float rotSpeed = 200.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse movemnet
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        
        // accumulation mouse movement
        rotX += mx * Time.deltaTime * rotSpeed;
        rotY += my * Time.deltaTime * rotSpeed;

        transform.localEulerAngles = new Vector3(-rotY, rotX, 0);
    }
}
