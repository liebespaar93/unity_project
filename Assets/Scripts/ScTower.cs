using System.Collections.Generic;
using UnityEngine;

public class ScTower : MonoBehaviour
{
    public ScBullet bullet;
    public GameObject firePoint;

    public float speed = 3.0f;
    public float fireDelayTime = 5.0f;

    private float _currTime;
    private Queue<ScBullet> _bulletWaitQueue;
    private Queue<ScBullet> _bulletLifeQueue;

    private void Start()
    {
        _currTime = 0.0f;
        _bulletWaitQueue = new Queue<ScBullet>();
        _bulletLifeQueue = new Queue<ScBullet>();
        while (_bulletWaitQueue.Count < 10)
            _bulletWaitQueue.Enqueue(GameObject.Instantiate(bullet, this.transform, true));
    }

    private void Update()
    {
        QueueCheck();
        FireBullet();
    }

    private void FireBullet()
    {
        _currTime += Time.deltaTime;
        if (_bulletWaitQueue.Count == 0)
            return;
        if (_currTime < fireDelayTime)
            return;
        _currTime = 0.0f;
        _bulletLifeQueue.Enqueue(
            _bulletWaitQueue.Dequeue().SetLife(
                this.firePoint.transform.position,
                this.firePoint.transform.rotation,
                speed
            )
        );
    }

    private void QueueCheck()
    {
        if (_bulletLifeQueue.Count == 0)
            return;
        if (_bulletLifeQueue.Peek().GetLife())
            return;
        _bulletWaitQueue.Enqueue(_bulletLifeQueue.Dequeue());
    }
}