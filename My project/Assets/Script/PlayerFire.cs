using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject BulletFactory;
    public GameObject FirePosition;
    
    public GameObject[] bulletArray;
    // Start is called before the first frame update
    void Start()
    {
        bulletArray = new GameObject[10];

        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(BulletFactory);
            bulletArray[i] = temp;
            temp.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // GameObject go = Instantiate(BulletFactory);
            // go.transform.position = FirePosition.transform.position;
            for (int i = 0; i < 10; i++)
            {
                if (bulletArray[i].activeSelf == false)
                {
                    bulletArray[i].transform.position = FirePosition.transform.position;
                    bulletArray[i].SetActive(true);
                    break;
                }
            }
        }
    }
}
