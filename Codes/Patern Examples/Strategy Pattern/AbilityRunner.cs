using UnityEngine;

public class AbilityRunner : MonoBehaviour
{
    [SerializeField] IAbility currentAbility = new RageAbility();

    public void UseAbility()
    {
        currentAbility.Use(gameObject);
    }
}

public interface IAbility
{
    void Use(GameObject currentGameObject);
}

public class RageAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Rage Used");
    }
}

public class HealAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Heal Used");
    }
}

public class FireBallAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Fireball Used");
    }
}