using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyFactory;

    public float createTime = 5;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > createTime)
        {
            GameObject bullet = Instantiate(EnemyFactory);

            bullet.transform.position = this.transform.position;

            createTime = Random.Range(2.0f, 5.0f);
            currentTime = 0;
        }

        currentTime += Time.deltaTime;

    }
}
