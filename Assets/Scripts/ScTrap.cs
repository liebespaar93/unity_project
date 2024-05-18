using Unity.VisualScripting;
using UnityEngine;

public class ScTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("in : trap" + other);
        var characterTemp = other.gameObject.GetComponentInParent<ScCharacter>();

        if (!characterTemp.IsUnityNull())
        {
            characterTemp.CharacterGameOver();
        }
        
    }
}
