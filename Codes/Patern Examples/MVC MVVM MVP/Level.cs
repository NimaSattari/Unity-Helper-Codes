using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{

    [SerializeField] int pointsPerLevel = 200;
    [SerializeField] UnityEvent onLevelUp;
    int experiencePoints = 0;

    public event Action onLevelUpAction;
    public event Action onExperienceChange;

    public void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoints += points;
        if (onExperienceChange != null)
        {
            onExperienceChange();
        }
        if (GetLevel() > level)
        {
            onLevelUp.Invoke();
            if (onLevelUpAction != null)
            {
                onLevelUpAction();
            }
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