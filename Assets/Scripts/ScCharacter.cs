using Unity.VisualScripting;
using UnityEngine;

public class ScCharacter : MonoBehaviour
{
    // Character Control
    private PlayerCamera _mainCamera;
    public float speed = 2.0f;
    public float jumpPower = 2.0f;

    private bool _focus;
    private Vector3 _originPosition;

    // jump
    private int _checkJump;
    private RaycastHit _hitInfo;

    // Box physic
    private Rigidbody _rb;

    // Unity Function
    private void Start()
    {
        // Character Setting
        _originPosition = this.transform.position;
        _focus = false;

        // Box Setting
        _rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_focus)
        {
            PlayerControl();
        }

        ResetControl();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground")
            || other.CompareTag("Player"))
            _checkJump++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground")
            || other.CompareTag("Player"))
            _checkJump--;
    }


    // User Control Function

    public void SetCamera(PlayerCamera mainCamera)
    {
        this._mainCamera = mainCamera;
    }

    public void CharacterGameOver()
    {
        if (this._mainCamera.IsUnityNull())
            return;
        this._mainCamera.GameOver(this.transform.position);
    }

    void PlayerControl()
    {
        MoveControl();
        JumpControl();
    }

    void MoveControl()
    {
        float horiz = Input.GetAxis("Horizontal");
        if (horiz != 0.0f)
            _rb.velocity = new Vector3((horiz * speed * Time.deltaTime * 1000), _rb.velocity.y, _rb.velocity.z);
    }

    void JumpControl()
    {
        if (Input.GetButtonDown("Jump") && _checkJump > 0)
            _rb.AddForce(Vector3.up * (jumpPower + 4), ForceMode.Impulse);
    }

    // reset function
    void ResetControl()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
        {
            this.transform.position = this._originPosition;
            this.transform.rotation = new Quaternion(0, 0, 0, 1);
        }
    }

    // User Focus Function
    public void FocusOn()
    {
        _focus = true;
    }

    public void FocusOff()
    {
        _focus = false;
    }
}