using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Armadillo>() != null || collision.GetComponent<GunGoon>() != null)
        {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }
    }
