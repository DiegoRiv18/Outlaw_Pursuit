using UnityEngine;

public class Horse : MonoBehaviour
{
    public Transform hubTransform;
    public Transform level1Transform;
    public Gunner player;

    public int selector = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.ResetHP();

            switch (selector)
            {
                case 0:
                    collision.collider.transform.position = hubTransform.position;
                    break;
                case 1:
                    collision.collider.transform.position = level1Transform.position;
                    break;
            }
        }
    }

    public void SelectLevel(int location)
    {
        selector = location;
    }
}