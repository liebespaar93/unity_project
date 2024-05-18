
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScWarp : MonoBehaviour
{
    public GameObject warpGb;

    private List<float> _currTimes;
    private List<GameObject> _triggerObject;
    private float _warpTime;

    private void Start()
    {
        _currTimes = new List<float>();
        _triggerObject = new List<GameObject>();
        _warpTime = 8.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (warpGb.IsUnityNull())
        {
            print("no target for warp!");
            return;
        }
        var characterTemp = other.gameObject.GetComponentInParent<ScCharacter>();
        if (characterTemp.IsUnityNull())
            return;
        this._triggerObject.Add(characterTemp.gameObject);
        this._currTimes.Add(0.0f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (_currTimes.IsUnityNull())
            return;

        for (var i = 0; i < _currTimes.Count; i++)
        {
            if (_triggerObject[i] != other.gameObject)
                continue;
            _currTimes[i] += Time.deltaTime;
            if (_currTimes[i] < _warpTime)
                continue;
            _triggerObject[i].transform.position = warpGb.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var characterTemp = other.gameObject.GetComponentInParent<ScCharacter>();
        if (characterTemp.IsUnityNull())
            return;
        var triggerIndex = this._triggerObject.FindIndex((x => x == characterTemp.gameObject));
        this._currTimes.RemoveAt(triggerIndex);
        this._triggerObject.RemoveAt(triggerIndex);
    }
}