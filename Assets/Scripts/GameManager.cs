using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;

    // A reference to our BallController
    [SerializeField] private BallController ball;

    // A reference to our PinCollection prefab
    [SerializeField] private GameObject pinCollection;

    // A reference for an empty GameObject which we'll use to spawn our pin collection prefab
    [SerializeField] private Transform pinAnchor;

    // A reference for our InputManager
    [SerializeField] private InputManager inputManager;

    // A reference to the UI text for displaying score
    [SerializeField] private TextMeshProUGUI scoreText;

    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        SetPins(); // Ensure pins appear at the start
        inputManager.OnResetPressed.AddListener(HandleReset);
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {
        // Ensure pinObjects exists before trying to destroy its children
        if (pinObjects != null)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        // Instantiate new pins
        pinObjects = Instantiate(pinCollection, pinAnchor.position, Quaternion.identity, transform);

        if (pinObjects == null)
        {
            Debug.LogError("GameManager: Failed to instantiate pinCollection!");
            return;
        }

        fallTriggers = pinObjects.GetComponentsInChildren<FallTrigger>(); // Get fall triggers from new pins
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
        Debug.Log("Pin detected as fallen. Score updated."); // Debugging log to confirm pin fall detection
    }
}
