using Unity.VisualScripting;
using UnityEngine;

public class ScButtonPress : MonoBehaviour
{
    public ScButton button;
    
    public GameObject key;
    
    private int _count;
    private void OnTriggerEnter(Collider other)
    {
        if (button.IsUnityNull())
            return;
        if (key.IsUnityNull() || key.gameObject.transform.name == other.gameObject.transform.name)
        {
            this.button.OnPressed();
            _count++;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (button.IsUnityNull())
            return;
        if (key.IsUnityNull() ||key.gameObject.transform.name == other.gameObject.transform.name)
        {
            _count--;
            if (_count == 0)
                this.button.OffPressed();
        }
    }
}
