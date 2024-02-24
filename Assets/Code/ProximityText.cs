using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProximityText : MonoBehaviour
{
    public Transform player;
    public float interactionDistance = 3f;
    public GameObject textCanvas;

    private void Start()
    {
        // Ensure the textCanvas is initially disabled
        textCanvas.SetActive(false);
    }

    private void Update()
    {
        if (player != null)
        {
            // Check the distance between the player and this object
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Show/hide the textCanvas based on the interactionDistance
            if (distanceToPlayer <= interactionDistance)
            {
                // Display interaction text and enable canvas
                textCanvas.SetActive(true);
            }
            else
            {
                // Hide interaction text and disable canvas
                textCanvas.SetActive(false);
            }
        }
    }
}
