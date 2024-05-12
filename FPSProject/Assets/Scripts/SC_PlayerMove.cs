using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SC_PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;

    CharacterController cc;

    private float gravity = -20;
    private float yVelocity = 0;

    public float jumpPower = 5;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dirH = this.transform.right * h;
        Vector3 dirV = this.transform.forward * v;
        Vector3 dir = dirH + dirV;

        // this.transform.position = transform.position + dir * (speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
        }
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        
        cc.Move(dir * (speed * Time.deltaTime));
    }

    // hp

    public float currHP = 100;
    
    public Slider hpSilder;
    public Text hpText;
    
    public void OnDamaged()
    {
        currHP -= 10;

        hpText.text = "HP : " + currHP;
        float ratio = currHP / 100;
        hpSilder.value = ratio;
    }
    
}
