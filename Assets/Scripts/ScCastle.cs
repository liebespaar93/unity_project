using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScCastle : MonoBehaviour
{
    public ScStage stage;
    private float _hp = 5.0f;
    

    public void Hit(float power)
    {
        if (this._hp <= 0)
            return;
        var prevHp = this._hp;
        this._hp -= power;
        print("Castle hit : hp " + prevHp + " -> " + this._hp);
        CastleGameOver();
    }

    private void CastleGameOver()
    {
        if (this._hp > 0)
            return;
        if (stage.IsUnityNull())
            return;
        stage.GameOver();
        Destroy(this.gameObject);
    }

    public float GetHp()
    {
        return this._hp;
    }
}