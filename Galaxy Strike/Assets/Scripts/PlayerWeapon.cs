using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

/// <summary>
/// Handles the weapon of the player both activation and logic
/// </summary>
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance;
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    /// <summary>
    /// Moves the target point around the world to where the crosshair is
    /// </summary>
    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    /// <summary>
    /// Handles the logic of when the button is pressed to access the emission
    /// </summary>
    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    /// <summary>
    /// When the player presses the fire button (left mouse button, or spacebar)
    /// </summary>
    /// <param name="inputValue"> The input of the button</param>
    private void OnFire(InputValue inputValue)
    {
        isFiring = inputValue.isPressed;
    }

    /// <summary>
    /// Moves the crosshair to where the mouse is on the screen
    /// </summary>
    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    /// <summary>
    /// Aims the laser shooting from the ship towards the target point of the crosshair
    /// </summary>
    private void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
