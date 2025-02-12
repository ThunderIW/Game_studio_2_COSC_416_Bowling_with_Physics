using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;

    // A reference to our BallController
    [SerializeField] private BallController ball;

    // A reference for our PinCollection prefab we made in Section 2.2
    [SerializeField] private GameObject pinCollection;

    // A reference for an empty GameObject which we'll
    // use to spawn our pin collection prefab
    [SerializeField] private Transform pinAnchor;

    // A reference for our InputManager
    [SerializeField] private InputManager inputManager;

    [SerializeField] private TextMeshProUGUI scoreText;


    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        // Adding the HandleReset function as a listener to our
        // newly added OnResetPressed Event
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }

    private void HandleReset()
    {
        score = 0;
        scoreText.text = $"Score: {score}";
        ball.ResetBall();
        SetPins();
    }

    private void SetPins()
    {
        // We first make sure that all the previous pins have been destroyed
        // this is so that we don't create a new collection of
        // standing pins on top of already fallen pins
        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        // We then instantiate a new set of pins to our pin anchor transform
        pinObjects = Instantiate(pinCollection, pinAnchor.position, Quaternion.identity, transform);

        // We add the Increment Score function as a listener to
        // the OnPinFall event of each new pin
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
