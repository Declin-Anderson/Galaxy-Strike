using UnityEngine;

/// <summary>
/// Handles the collision logic of the player ship
/// </summary>
public class CollisionHandler : MonoBehaviour
{
    /// <summary>
    /// Checks what is colliding with the player ship
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.name);
    }
}
