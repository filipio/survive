using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Image healthFillBar;
    [SerializeField]
    private TMPro.TextMeshProUGUI healthText;

    private void OnEnable()
    {
        FindObjectOfType<PlayerMovement>().GetComponent<Health>().OnHealthChanged += UIPlayerHealth_OnHealthChanged;
    }

    private void UIPlayerHealth_OnHealthChanged(int currentHealth, int maxHealth)
    {
        healthText.text = string.Format("{0} / {1}", currentHealth, maxHealth);
        float pct = (float)currentHealth / (float)maxHealth;
        healthFillBar.fillAmount = pct;
    }
}
