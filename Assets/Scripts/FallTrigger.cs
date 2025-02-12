using UnityEngine;
using UnityEngine.Events;

public class FallTrigger : MonoBehaviour
{
    public UnityEvent OnPinFall = new();
    private bool isPinFallen = false;

    private void OnTriggerEnter(Collider triggeredObject)
    {
        // Ensure the pin only triggers once and only when it hits the ground
        if (triggeredObject.CompareTag("Ground") && !isPinFallen)
        {
            isPinFallen = true;
            Debug.Log($"{gameObject.name} has fallen!"); // Debugging
            OnPinFall?.Invoke(); // Notify GameManager
        }
    }
}
