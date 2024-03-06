using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRevolver : MonoBehaviour
{
    public Gunner player;
    public GunGoon goon;
    bool flipped;

    // Update is called once per frame
    void Update()
    {
        if(goon == null)
        {
            Destroy(gameObject);
        }
        //Get goon position to anchor gun
        Vector2 goonPos = goon.transform.position;
        if(player != null )
        {
            //If the player is to the left/right side of the goon, swap side of gun
            if (player.transform.position.x < goon.transform.position.x &&
                Mathf.Abs(transform.position.y - player.transform.position.y) < 5)
            {
                transform.position = new Vector2(goonPos.x - 1.1f, goonPos.y);
                if (!flipped)
                {
                    Flip();
                }
            }

            else
            {
                transform.position = new Vector2(goonPos.x + 1.1f, goonPos.y);
                if (flipped)
                {
                    Flip();
                }
            }

            // Face the gun to the player
            FacePlayer(player.transform.position);
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

    void FacePlayer(Vector3 targetPosition)
    {
        // Calculate the direction vector from the current position to the player position
        Vector3 direction = targetPosition - transform.position;

        // Calculate the rotation angle in radians
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        Quaternion rotation;
        if (goon.flip)
        {
            if (angle < 90 && angle > -90)
            {
                rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            }

            else if (angle > 90)
            {
                rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
            }

            else
            {
                rotation = Quaternion.Euler(new Vector3(0, 0, -90f));
            }
        }

        else
        {
            if (angle > 90 || angle < -90)
            {
                rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));

            }

            else if (angle > 0)
            {
                rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
            }

            else
            {
                rotation = Quaternion.Euler(new Vector3(0, 0, -90f));
            }
        }
        // Apply the rotation to the sprite
        transform.rotation = rotation;
    }
}
