using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarLoader : MonoBehaviour
{
    [SerializeField] private RectTransform  transform;
    [SerializeField] private float          time;

    private void Start()
    {
        transform = GetComponent<RectTransform>();
    }

    public IEnumerator LoadBar()
    {

        float currtime = 0;
        Vector3 scale = new Vector3(0, 1, 1);
        while (currtime <= time)
        {
            currtime += Time.deltaTime;
            Debug.Log(currtime);
            yield return new WaitForEndOfFrame();
        }

    }
}
