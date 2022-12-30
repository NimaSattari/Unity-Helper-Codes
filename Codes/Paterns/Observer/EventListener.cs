using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> { }

public class EventListener : MonoBehaviour
{
    //put this in the object you want to listen to the event

    public Event gEvent;

    //any of these down here
    public UnityEvent response;
    public UnityGameObjectEvent response1 = new UnityGameObjectEvent();

    private void OnEnable()
    {
        gEvent.Register(this);
    }

    private void OnDisable()
    {
        gEvent.Unregister(this);
    }

    public void OnEventOccurs(GameObject go)
    {
        response.Invoke();
        response1.Invoke(go);
    }
}
