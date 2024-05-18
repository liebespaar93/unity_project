
using Unity.VisualScripting;
using UnityEngine;

public class ScHole : MonoBehaviour
{
    public PlayerCamera mainCamera;

    private void OnTriggerEnter(Collider other)
    {
        var character = other.GetComponentInChildren<ScCharacter>();
        
        if (character.IsUnityNull())
            return;
        mainCamera.GameOver(other.transform.position);
    }
}
