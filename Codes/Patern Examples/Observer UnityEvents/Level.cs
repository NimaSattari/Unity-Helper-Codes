using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int pointsPerLevel = 200;
    public UnityEvent onLevelUp;
    int experiencePoints = 0;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            GainExperience(10);
        }
    }

    public void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoints += points;
        if (GetLevel() > level)
        {
            onLevelUp.Invoke();
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointsPerLevel;
    }
}