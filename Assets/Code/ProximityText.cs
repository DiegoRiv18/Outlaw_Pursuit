using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProximityText : MonoBehaviour
{
    public Transform player;
    public float interactionDistance = 3f;
    public GameObject Text;
    public GameObject Enc;
    bool already;
   

    private void Start()
    {
        // Ensure the textCanvas is initially disabled
        Text.SetActive(false);
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
                Text.SetActive(true);
                if (!already)
                {
                    StartCoroutine(Dialogue());
                }
               
            }
            else
            {
                // Hide interaction text and disable canvas
                Text.SetActive(false);
            }
        }
    }

    private IEnumerator Dialogue()
    {
        if (Enc != null)
        {
            already = true;
            yield return new WaitForSeconds(1);
            Enc.SetActive(true);
            yield return new WaitForSeconds(5);
            Enc.SetActive(false);
            already = false;
        }
    }
}
