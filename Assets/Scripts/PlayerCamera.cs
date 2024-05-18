using Unity.VisualScripting;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // player list
    public ScCharacter[] players;

    // camera control
    public uint zoom = 10;
    private Vector3 _originPosition;
    private int _focusPlayer;
    private Vector3 _playerPosition;
    
    // Game Over
    private bool _gameOver;
    
    // unity function
    private void Start()
    {
        _originPosition = this.transform.position;
        _focusPlayer = -1;
        _playerPosition = new Vector3(0, 0, 0);
        _gameOver = false;
        foreach (var player in players)
        {
            player.SetCamera(this);
        }
    }
    private void Update()
    {
        ResetControl();
        if (_gameOver)
            return;
        if (_focusPlayer != -1)
        {
            if (players[_focusPlayer])
                _playerPosition = players[_focusPlayer].transform.position;
            this.transform.position = new Vector3(_playerPosition.x, _playerPosition.y + 1.0f, -zoom);
        }
        CharacterChange();
    }
    
    // camera focus function
    void CharacterChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            FocusChange(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            FocusChange(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            FocusChange(2);
    }

    private void FocusChange(int playerNum)
    {
        if (_focusPlayer != -1)
            players[_focusPlayer].FocusOff();
        
        if (!players.IsUnityNull() && players.Length > playerNum && !players[playerNum].IsUnityNull())
        {
            _focusPlayer = playerNum;
            players[_focusPlayer].FocusOn();
        }
    }

    public void GameOver(Vector3 point)
    {
        print("Game Over");
        _gameOver = true;
        if (_focusPlayer != -1)
            this.players[_focusPlayer].FocusOff();
        this._focusPlayer = -1;
        this.transform.position = new Vector3(point.x, point.y + 1.0f, -zoom);
    }

    // reset function
    private void ResetControl()
    {
        if (!Input.GetKeyDown(KeyCode.R) && !Input.GetKeyDown(KeyCode.Backspace))
            return;
        this.transform.position = _originPosition;
        if (_focusPlayer != -1)
            players[_focusPlayer].FocusOff();
        _focusPlayer = -1;
        _gameOver = false;
    }
}
