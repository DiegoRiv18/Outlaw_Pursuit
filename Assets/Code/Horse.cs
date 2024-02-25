using UnityEngine;

public class Horse : MonoBehaviour
{
    public Transform hubTransform;
    public Transform level1Transform;
    public Gunner player;

    public int selector = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.ResetHP();

            switch (selector)
            {
                case 0:
                    ScenesManager.instance.LoadScene(ScenesManager.Scene.Tutorial);
                    break;
                case 1:
                    ScenesManager.instance.LoadScene(ScenesManager.Scene.Hub);
                    break;
                case 2:
                    ScenesManager.instance.LoadScene(ScenesManager.Scene.Level1);
                    break;
            }
        }
    }

    public void SelectLevel(int location)
    {
        selector = location;
    }
}