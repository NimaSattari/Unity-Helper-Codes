using UnityEngine;

public class AbilityRunner : MonoBehaviour
{
    [SerializeField] IAbility currentAbility = new SequenceComposite(new IAbility[] { new HealAbility(), new RageAbility(), new DelayedDecorator(new FireBallAbility()));

    public void UseAbility()
    {
        currentAbility.Use(gameObject);
    }
}

public interface IAbility
{
    void Use(GameObject currentGameObject);
}

public class SequenceComposite : IAbility
{
    private IAbility[] children;

    public SequenceComposite(IAbility[] children)
    {
        this.children = children;
    }

    public void Use(GameObject currentGameObject)
    {
        foreach (var child in children)
        {
            child.Use(currentGameObject);
        }
    }
}

public class DelayedDecorator : IAbility
{
    private IAbility wrappedAbility;

    public DelayedDecorator(IAbility wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject currentGameObject)
    {
        // TODO some delaying functionality.
        wrappedAbility.Use(currentGameObject);
    }
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