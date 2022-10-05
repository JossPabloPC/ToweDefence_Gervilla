using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLoader : MonoBehaviour
{
    [SerializeField] private Image  _image;
    [SerializeField] private float  _time;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void LoadBarOnClick()
    {
        StartCoroutine(LoadBar());
    }
    public IEnumerator LoadBar()
    {

        float currtime = 0;
        while (currtime <= _time)
        {
            currtime += Time.deltaTime;
            _image.fillAmount = currtime/_time;
            yield return new WaitForEndOfFrame();
        }

    }
}
