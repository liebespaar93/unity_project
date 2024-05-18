using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ScPortal : MonoBehaviour
{
    // Stage Setting
    public ScStage mainStage;
    public GameObject[] gatherCharacters;
    private List<ScCharacter> _characterScripts;
    private List<GameObject> _triggerGameObjects;
    
    private int _countIn;
    
    // unity function
    private void Start()
    {
        this._characterScripts = new List<ScCharacter>();
        SettingCharacters();
        this._triggerGameObjects = new List<GameObject>();
        this._countIn = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (mainStage.IsUnityNull())
            return;
        if (_characterScripts.Count == 0)
            return;

        var characterTemp = other.gameObject.GetComponentInParent<ScCharacter>();
        this._triggerGameObjects.Add(other.gameObject);
        foreach (var (player, i) in _characterScripts.Select(
                     (player, i) => (player, i)))
        {
            if (characterTemp.gameObject != player.gameObject)
                continue;
            if ((_countIn & (1 << i)) > 0)
                return;
            _countIn = _countIn | (1 << i);
            print("in : " + player.gameObject.name);
            break;
        }

        if ((1 << this._characterScripts.Count) - 1 == _countIn)
        {
            mainStage.ClearStage();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_characterScripts.Count == 0)
            return;
        var triggerGameObjectIndex = _triggerGameObjects.FindIndex((x) => x == other.gameObject);
        if (triggerGameObjectIndex == -1)
            return;
        var characterTemp = other.gameObject.GetComponentInParent<ScCharacter>();
        _triggerGameObjects.RemoveAt(triggerGameObjectIndex);
        foreach (var triggerGameObject in _triggerGameObjects)
        {
            if (triggerGameObject.GetComponentInParent<ScCharacter>().gameObject == characterTemp.gameObject)
                return;
        }
        foreach (var (player, i) in _characterScripts.Select(
                     (player, i) => (player, i)))
        {
            if (characterTemp.gameObject != player.gameObject)
                continue;
            _countIn = _countIn ^ (1 << i);
            print("out : " + player.gameObject.name);
            return;
        }
    }

    // user function
    private void SettingCharacters()
    {
        foreach (var player in gatherCharacters)
        {
            var temp = player.GetComponent<ScCharacter>();
            if (temp.IsUnityNull())
                continue;
            _characterScripts.Add(player.GetComponent<ScCharacter>());
        }
    }
    
    public bool AllInCheck()
    {
        return ((1 << this._characterScripts.Count) - 1) == _countIn;
    }
}