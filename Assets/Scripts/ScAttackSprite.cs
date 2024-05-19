using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScAttackSprite : MonoBehaviour
{
    public ScAttackObject attackObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (attackObject.IsUnityNull())
            return;
        attackObject.HitEnemy(other);
    }
}
