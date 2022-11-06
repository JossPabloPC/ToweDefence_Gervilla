using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_gameOverPanel;
    [SerializeField] private CanvasGroup m_gameWonPanel;
    [SerializeField] private CanvasGroup m_gameHUD;


    private void Start()
    {
        Scr_GameManager.Instance.OnGameOver += ShowGameOver;
        Scr_GameManager.Instance.OnGameWin  += ShowGameWin;
        HideCanvas(m_gameOverPanel);    
        HideCanvas(m_gameWonPanel);
    }

    private void ShowGameOver()
    {
        HideCanvas(m_gameHUD);
        ShowCanvas(m_gameOverPanel);
    }

    private void ShowGameWin()
    {
        HideCanvas(m_gameHUD);
        ShowCanvas(m_gameWonPanel);
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
