using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyBoard : MonoBehaviour
{
    public GameObject bountyCanvas;
    public Gunner player;

    // Start is called before the first frame update
    void Start()
    {
        bountyCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 3)
        {
            if(Input.GetKeyDown("b"))
            {
                bountyCanvas.SetActive(true);
            }
        }
    }
}
