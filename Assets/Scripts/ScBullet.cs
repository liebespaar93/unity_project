
using Unity.VisualScripting;
using UnityEngine;

public class ScBullet : MonoBehaviour
{
    public float lifeTime = 20.0f;
    private float _alive;

    private bool _life;
    private float _speed = 2.0f;

    private void Start()
    {
        _alive = 0.0f;
        _life = false;
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        _alive += Time.deltaTime;
        if (_alive > lifeTime)
            SetDie();
        if (this._life)
            this.transform.position += this.transform.forward * (_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var characterTemp = other.gameObject.GetComponentInParent<ScCharacter>();
        
        if (!characterTemp.IsUnityNull())
        {
            characterTemp.CharacterGameOver();
        }  
        SetDie();
    }

    public ScBullet SetLife(Vector3 position, Quaternion rotation, float speed)
    {
        this.transform.position = position;
        this.transform.rotation = rotation;
        this._speed = speed;
        this._life = true;
        this.gameObject.SetActive(true);
        return this;
    }

    private void SetDie()
    {
        _alive = 0.0f;
        this._life = false;
        this.gameObject.SetActive(false);
    }

    public bool GetLife()
    {
        return _life;
    }
}