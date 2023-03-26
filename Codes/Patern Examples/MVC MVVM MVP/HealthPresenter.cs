using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Image healthBar;

    private void Start()
    {
        health.onHealthChange += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthBar.fillAmount = health.GetHealth() / health.GetFullHealth();
    }
}