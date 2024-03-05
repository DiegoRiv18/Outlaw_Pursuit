using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int bossNum;

    private void OnDestroy()
    {
        AudioManager.Instance.PlaySFX("ChaChing");
        if (bossNum == 1)
        {
            ScenesManager.instance.andydeath = true;
            Shop.Singleton.balance += 20;
        }

        if (bossNum == 2)
        {
            ScenesManager.instance.harrydeath = true;
            Shop.Singleton.balance += 35;
        }

        if (bossNum == 3)
        {
            ScenesManager.instance.barondeath = true;
            Shop.Singleton.balance += 50;
        }
    }
}
