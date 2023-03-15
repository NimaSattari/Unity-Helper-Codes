using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;
    float currentHealth = 0;

    private void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    private void Start()
    {
        GetComponent<Level>().onLevelUp.AddListener(ResetHealth);
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public int ResetHealth()
    {
        currentHealth = fullHealth;
    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            yield return new WaitForSeconds(1);
        }
    }
}