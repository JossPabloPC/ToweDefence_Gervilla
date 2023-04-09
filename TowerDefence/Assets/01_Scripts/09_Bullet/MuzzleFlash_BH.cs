using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash_BH : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 0.1f;
    private void OnEnable()
    {
        StartCoroutine(Kill());
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(_lifeTime);
        BulletPooler.Instance.ReturnBulletToPool(gameObject);
    }
}

