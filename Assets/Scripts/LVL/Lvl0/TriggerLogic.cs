using UnityEngine;
using UnityEngine.Events;

public class TriggerLogic : MonoBehaviour
{
    [Tooltip("Событие, вызываемое при входе в триггер")]
    public UnityEvent onTriggerEnterEvent;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
         if (!hasTriggered && other.CompareTag("Player"))
        {
            onTriggerEnterEvent?.Invoke();
            hasTriggered = true;
        }
    }
}