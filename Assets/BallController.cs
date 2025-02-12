using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;

    private Rigidbody ballRB;

    void Start()
    {
        // Grabbing a reference to Rigidbody
        ballRB = GetComponent<Rigidbody>();

        // Ensure Rigidbody is assigned
        

        // Add listener for the Space key event
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    private void LaunchBall()
    {
        if (ballRB != null)
        {
            ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}
