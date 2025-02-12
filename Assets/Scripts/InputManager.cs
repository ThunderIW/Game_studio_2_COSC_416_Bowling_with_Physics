using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnSpacePressed = new UnityEvent();
    public UnityEvent OnResetPressed = new UnityEvent();

    private void Update()
    {
        // Detect space key press for launching the ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }

        // Detect movement keys (A and D)
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }
        OnMove?.Invoke(input);

        // Detect reset key (R) press
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnResetPressed?.Invoke();
        }
    }
}
