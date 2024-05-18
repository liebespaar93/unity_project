using UnityEngine;

public class ScDoor : MonoBehaviour
{
    public Vector3 movePoint = new Vector3(0,10,0);
    
    // Move Logic
    private Vector3 _originPosition;
    private Vector3 _movePosition;
    private float _prevLength;
    private Vector3 _dir;
    
    // stuck logic
    private bool _stuck;
    private BoxCollider _bc;
    private int _stuckCount;

    private bool _doorToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        _doorToggle = false;
        _originPosition += this.transform.position;
        
        // Move Setting
        _movePosition = this.transform.position + movePoint;
        _dir = movePoint;
        _dir.Normalize();
        _prevLength = 0;
        
        // stuck door variable
        _stuck = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoorMove();
    }

    private void DoorMove()
    {
        if (_stuck && !_doorToggle)
            return;
        var dirSide = 1.0f * (_doorToggle? 1 : -1);
        Vector3 targetPoint = (_doorToggle? _movePosition : _originPosition);
        Vector3 tempPosition = this.transform.position + (_dir * (dirSide * Time.deltaTime));
        float length =  (targetPoint - tempPosition).magnitude;
        if (length < _prevLength)
        {
            _prevLength = length;
            this.transform.position += (_dir * (dirSide * Time.deltaTime));
        }
    }

    public void DoorOpen()
    {
        this._doorToggle = true;
        _prevLength = ( _movePosition - this.transform.position).magnitude;
    }

    public void DoorClose()
    {
        this._doorToggle = false;
        _prevLength = (_originPosition - this.transform.position).magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        this._stuck = true;
        _stuckCount += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        _stuckCount -= 1;
        if (_stuckCount == 0)
        {
            this._stuck = false;
        }
    }   
}
