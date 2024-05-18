using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScStage : MonoBehaviour
{
    public ScPortal[] portals;
    public string nextStage;
    private bool _clear;
    
    private void Start()
    {
        _clear = false;
    }

    public void ClearStage()
    {
        if (portals.IsUnityNull())
            return;
        if (_clear)
            return;
        foreach (var portal in portals)
        {
            if (portals.IsUnityNull())
                return ;
            if (!portal.AllInCheck())
                return ;
        }
        _clear = true;
        print("Clear Stage");
        StartCoroutine(NextStage());
    }

    private IEnumerator NextStage()
    {
        if (!_clear || nextStage.IsUnityNull())
            yield break;
        for (var i = 5; i > 0; i--)
        {
            print("NextStage " + i);
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(nextStage);
    }
}
