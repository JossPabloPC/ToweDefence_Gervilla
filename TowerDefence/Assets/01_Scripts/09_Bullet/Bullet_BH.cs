using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_BH : MonoBehaviour
{
    [SerializeReference] private Bullet_Data _bullet_Data;

    void Update()
    {
        transform.Translate(transform.forward * _bullet_Data.speed * Time.deltaTime);
    }
}
