using UnityEngine;

public class Impact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Call the DestroyObject method after 0.175 seconds
        Invoke("DestroyObject", 0.1f);
    }

    // Method to destroy the object
    void DestroyObject()
    {
        // Destroy the game object this script is attached to
        Destroy(gameObject);
    }
}
