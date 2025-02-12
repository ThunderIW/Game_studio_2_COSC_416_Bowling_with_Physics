using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;
    [SerializeField] private InputManager inputManager; // Assigned in Inspector

    private bool isBallLaunched;
    private Rigidbody ballRB;

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();

        // Ensure inputManager is assigned
        if (inputManager == null)
        {
            Debug.LogError("BallController: InputManager is not assigned in the Inspector!");
            return;
        }

        inputManager.OnSpacePressed.AddListener(LaunchBall);
        ResetBall();
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;

        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.linearVelocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;

        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);

        launchIndicator.gameObject.SetActive(false);
    }

    public void ResetBall()
    {
        isBallLaunched = false;
        ballRB.isKinematic = true;

        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;

        launchIndicator.gameObject.SetActive(true);
    }
}
