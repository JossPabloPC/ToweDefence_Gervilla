using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneControlllers :MonoBehaviour
{
    [SerializeField] private Image _image;

    // Start is called before the first frame update
    public void LoadScene()
    {
        StartCoroutine(LoadBar());
    }
    public IEnumerator LoadBar()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(AppConstants.LEVEL_01);
        while (!operation.isDone)
        {
            _image.fillAmount = operation.progress;
            yield return new WaitForEndOfFrame();
        }

    }
}
