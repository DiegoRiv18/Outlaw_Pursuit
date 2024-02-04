using UnityEngine;

public class CameraTracking : MonoBehaviour
{

    public Transform player;
    private Quaternion my_rotation;

    void Start()
    {
        my_rotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = my_rotation;
        if (player != null)
        {
            transform.position = player.transform.position + new Vector3(0, 1, -5);
        }
    }
}