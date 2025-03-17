using UnityEngine;

public class HackingHandler : MonoBehaviour
{
    [SerializeField]
    public static bool doorHack;
    [SerializeField]
    public static bool cameraHack;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("DoorHack: " + doorHack);
    }
}
