using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ArmadilloChild : MonoBehaviour
{
    /*
    private bool hit = false;
    int dmg = 20;
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Gunner>() != null && !hit)
        {
            hit = true;
            collision.gameObject.GetComponent<Gunner>().decHP(dmg);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Gunner>() != null && hit)
        {
            hit = false;
        }
    }
    */
}
