using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image _healthBar;

    [SerializeField]private Color _initialColor;
    [SerializeField]private Color _finalcolor;
    [SerializeField]private Gradient _healthColors;

    [SerializeField]private Damagable_Body _master;

    private void Start()
    {
        _healthBar = GetComponent<Image>();
    }
    public void UpdateHealthBar()
    {
        _healthBar.fillAmount = _master.CurrentHealthNormalized;
        _healthBar.color = _healthColors.Evaluate(_master.CurrentHealthNormalized);
    }
}
