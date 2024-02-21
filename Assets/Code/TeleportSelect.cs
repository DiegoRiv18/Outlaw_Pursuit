using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportSelect : MonoBehaviour
{
    public Horse horseScript;

    // The teleport location to be changed in inspector (hub by default)
    public int teleportLocation = 0;

    private void OnDestroy()
    {
        // Check if the Horse script reference is not null
        if (horseScript != null)
        {
            // Call the SelectLevel method in the Horse script with the specified teleport location
            horseScript.SelectLevel(teleportLocation);
        }
    }
}
