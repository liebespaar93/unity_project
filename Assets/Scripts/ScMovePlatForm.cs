using System.Collections.Generic;
using UnityEngine;

public class ScMovePlatForm : MonoBehaviour
{
    // Default
    private Transform _parent;
    public float speed = 1;

    // Move
    private GameObject _originPointGameObject;
    private Transform _originTransform;
    
    public GameObject[] movePoint;
    private List<Transform> _moveTransforms;
    
    private Vector3 _nextMoveDir;
    private int _movePointIndex;

    private float _farNextPoint;
    
    // Remember Other Parent;

    private void Start()
    {
        _parent = this.transform.parent;
        _moveTransforms = new List<Transform>();

        OriginPointSetting();
        foreach (var point in movePoint)
            _moveTransforms.Add(point.transform);
        _moveTransforms.Add(_originTransform);
        _movePointIndex = 0;
        _nextMoveDir = this._moveTransforms[_movePointIndex].position - _originTransform.position;
        _farNextPoint = _nextMoveDir.magnitude;
        _nextMoveDir.Normalize();
    }

    private void OriginPointSetting()
    {
        var parent = this.transform.parent;
        _originPointGameObject = new GameObject
        {
            transform =
            {
                position = parent.position,
                rotation = parent.rotation,
                localScale = parent.localScale,
                parent = parent.parent
            },
            name = "OriginPoint"
        };
        _originTransform = _originPointGameObject.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        MoveNext();
    }

    private void MoveNext()
    {
        _parent.position += (_nextMoveDir * (speed * Time.deltaTime));
        var tempFar = (_moveTransforms[_movePointIndex].position - _parent.position).magnitude;

        if (_farNextPoint > tempFar)
        {
            _farNextPoint = tempFar;
            return;
        }

        _movePointIndex = (_movePointIndex + 1) % _moveTransforms.Count;
        _nextMoveDir = this._moveTransforms[_movePointIndex].position - _parent.position;
        _farNextPoint = _nextMoveDir.magnitude;
        _nextMoveDir.Normalize();
    }

    private void OnCollisionEnter(Collision other)
    {
        other.transform.SetParent(_parent);
    }

    private void OnCollisionExit(Collision other)
    {
        
        other.transform.SetParent(null);
    }
}