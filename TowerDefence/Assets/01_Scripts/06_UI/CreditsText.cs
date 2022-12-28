using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsText : MonoBehaviour
{
    private TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        Scr_GameManager.Instance.OnTowerBought  += context => UpdateCredits(context);
        Scr_GameManager.Instance.OnEnemyKilled  += context => UpdateCredits(context);
    }

    public void UpdateCredits(int newBalance)
    {
       text.text = newBalance.ToString();
    }

}
