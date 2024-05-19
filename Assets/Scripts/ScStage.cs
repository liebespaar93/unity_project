using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScStage : MonoBehaviour
{
    private bool _gameOver = false;
    
    public void GameOver()
    {
        if (_gameOver)
            return;
        this._gameOver = true;
        print("Game Over");
    }

    public bool GetGameOver()
    {
        return this._gameOver;
    }
}
