using UnityEngine;
using UnityEngine.Events;

public class TriggerPoint : MonoBehaviour
{
    public UnityEvent<Collider2D> OnTriggerEvent;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEvent.Invoke(collision);
    }
}
