using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyBoard : MonoBehaviour
{
    public GameObject bountyCanvas;
    public Gunner player;
    public GameObject andyPoster;
    public GameObject harryPoster;
    public GameObject harryPosterX;
    public GameObject baronPoster;
    public GameObject baronPosterX;


    // Start is called before the first frame update
    void Start()
    {
        bountyCanvas.SetActive(false);
        harryPoster.SetActive(false);
        harryPosterX.SetActive(false);
        baronPoster.SetActive(false);
        baronPosterX.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 5)
        {
            if(Input.GetKeyDown("b"))
            {
                bountyCanvas.SetActive(!bountyCanvas.activeSelf);
                if (Shop.Singleton.andydeath == true)
                {
                    harryPoster.SetActive(true);
                }
                if (Shop.Singleton.harrydeath == true)
                {
                    harryPosterX.SetActive(true);
                    baronPoster.SetActive(true);
                }
            }
        }
    }
}
