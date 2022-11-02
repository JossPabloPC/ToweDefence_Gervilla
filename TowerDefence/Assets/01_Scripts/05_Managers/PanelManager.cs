using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_gameOverPanel;
    [SerializeField] private CanvasGroup m_gameHUD;


    private void Start()
    {
        Scr_GameManager.Instance.OnGameOver += ShowGameOver;
        HideCanvas(m_gameOverPanel);    
    }

    private void ShowGameOver()
    {
        HideCanvas(m_gameHUD);
        ShowCanvas(m_gameOverPanel);
    }

    public void HideCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }
    public void ShowCanvas(CanvasGroup canvas)
    {
        canvas.alpha = 1;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }
}
