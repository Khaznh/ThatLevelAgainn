using UnityEngine;
using UnityEngine.Events;

public class TriggerPoint : MonoBehaviour
{
    public UnityEvent<Collider2D, TriggerPoint> OnTriggerEventEnter;
    public UnityEvent<Collider2D, TriggerPoint> OnTriggerEventExit;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEventEnter.Invoke(collision, this);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        OnTriggerEventExit.Invoke(collision, this);
    }
}
