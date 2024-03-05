using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaingun : MonoBehaviour
{
    public Gunner player;
    public GunGoon goon;
    bool flipped;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (goon == null)
        {
            Destroy(gameObject);
        }
        //Get goon position to anchor gun
        Vector2 goonPos = goon.transform.position;
        if (player != null)
        {
            transform.position = new Vector2(goonPos.x - 3f, goonPos.y);
            //If the player is to the left/right side of the goon, swap side of gun
        //    if (player.transform.position.x < goon.transform.position.x)
        //    {
       //         transform.position = new Vector2(goonPos.x + 3f, goonPos.y);
        //        if (!flipped)
        //        {
         //           Flip();
         //       }
         //   }

         //   else
          //  {
          //      transform.position = new Vector2(goonPos.x -3f, goonPos.y);
           //     if (flipped)
           //     {
            //        Flip();
            //    }
           // }

            // Face the gun to the player
            FacePlayer(player.transform.position);
        }
    }


    private void Flip()
    //Function to flip the sprite
    {
    
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
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

                rotation = Quaternion.Euler(new Vector3(0, 0, 180 -angle));

            }
        

        else
        {

               rotation = Quaternion.Euler(new Vector3(180, 0, 180 - angle));

        }
        // Apply the rotation to the sprite
        transform.GetChild(0).rotation = rotation;
        //transform.rotation = rotation;
    }
}
