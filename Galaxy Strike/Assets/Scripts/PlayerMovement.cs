using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles the movement of the player in the game
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xClampRange = 5f;
    [SerializeField] private float yClampRange = 5f;
    [SerializeField] private float controlRollFactor = 45f;
    [SerializeField] private float controlPitchFactor = 45f;
    [SerializeField] private float rotationSpeed = 10f;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    /// <summary>
    /// Moves the player model based on the input of the player
    /// </summary>
    private void ProcessTranslation()
    {
        // Setting up the range that the player can go on x
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        // Setting up the range that the player can go on y
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    /// <summary>
    /// Rotates the ship when the player moves in different directions
    /// </summary>
    private void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    /// <summary>
    /// When the player presses on the WASD it will read the left to right and up and down
    /// </summary>
    /// <param name="value"> The value being pressed on the input system</param>
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
