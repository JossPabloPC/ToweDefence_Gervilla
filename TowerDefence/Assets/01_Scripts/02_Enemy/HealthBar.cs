using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image _healthBar;
 
    [SerializeField]private Damagable_Body _master;

    private void Start()
    {
        _healthBar = GetComponent<Image>();
    }
    public void UpdateFillAmount()
    {
        _healthBar.fillAmount = _master.CurrentHealthNormalized;
    }
}
