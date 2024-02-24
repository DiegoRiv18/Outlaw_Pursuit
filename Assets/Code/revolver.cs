using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolver : MonoBehaviour
{
    Gunner player;
    bool flipped;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Gunner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector2 playerPos = player.transform.position;

            if (!player.info.facingRight)
            {
                transform.position = new Vector2(playerPos.x - 1.1f, playerPos.y);
                if (!flipped)
                {
                    Flip();
                }
            }

            else
            {
                transform.position = new Vector2(playerPos.x + 1.1f, playerPos.y);
                if (flipped)
                {
                    Flip();
                }
            }
            // Get the mouse position in world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Face the sprite towards the mouse position
            FaceMouse(mousePosition);
        }
    }
   

    private void Flip()
    //Function to flip the sprite
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        flipped = !flipped;

    }

    void FaceMouse(Vector3 targetPosition)
    {
        // Calculate the direction vector from the current position to the mouse position
        Vector3 direction = targetPosition - transform.position;

        // Calculate the rotation angle in radians
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        Quaternion rotation;
        if (player.info.facingRight)
        { 
      
                rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            
        }

        else
        {
            
         
                rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));

        
        }
        // Apply the rotation to the sprite
        transform.rotation = rotation;
    }
}

