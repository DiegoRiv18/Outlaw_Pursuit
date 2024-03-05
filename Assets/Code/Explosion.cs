using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject ExplosionPrefab;

    public void boom()
    {
        AudioManager.Instance.PlaySFX("Explosion");
        GameObject bam = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        StartCoroutine(WaitEx(bam));
    }

    private IEnumerator WaitEx(GameObject bam)
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(bam.gameObject);
        Destroy(this.gameObject);
    }

}
