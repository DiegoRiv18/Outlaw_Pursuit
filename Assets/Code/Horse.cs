using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    // Assign the destination point in the Unity Editor
    public Transform teleportDestination;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Teleport the player to the destination point
            collision.collider.transform.position = teleportDestination.position;
        }
    }
}
