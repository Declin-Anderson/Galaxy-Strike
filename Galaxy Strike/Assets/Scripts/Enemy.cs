using UnityEngine;

/// <summary>
/// Handles the logic of the enemy units in the game
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>
    /// When the enemy collides with particle it destroys itself
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        Destroy(this.gameObject);
    }
}
