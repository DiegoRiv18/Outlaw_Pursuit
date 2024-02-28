using UnityEngine;

public class Horse : MonoBehaviour
{
    public int selector = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
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
                case 3:
                    ScenesManager.instance.LoadScene(ScenesManager.Scene.Level2);
                    break;
            }
        }
    }

    public void SelectLevel(int location)
    {
        selector = location;
    }
}