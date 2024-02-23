using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void yes()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
