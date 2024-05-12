using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material BGmatrial;

    public float speed = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 diraction = Vector2.up;
        BGmatrial.mainTextureOffset += diraction * (speed * Time.deltaTime);
    }
}
