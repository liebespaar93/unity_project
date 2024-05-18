
using Unity.VisualScripting;
using UnityEngine;

public class ScButton : MonoBehaviour
{
    public ScDoor[] doors;
    
    public void OnPressed()
    {
        if (doors.IsUnityNull())
            return;
        foreach (var door in doors)
        {
            door.DoorOpen();
        }
    }
    public void OffPressed()
    {
        if (doors.IsUnityNull())
            return;
        foreach (var door in doors)
        {
            door.DoorClose();
        }
    }
}
