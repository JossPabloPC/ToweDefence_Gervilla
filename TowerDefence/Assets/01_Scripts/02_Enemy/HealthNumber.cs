using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;

    [SerializeField] private Damagable_Body _master;

    private void Start()
    {
        _healthText = GetComponent<TMP_Text>();
    }
    public void UpdateText()
    {
        _healthText.text = _master.CurrentHealthNormalized.ToString();
    }
}
