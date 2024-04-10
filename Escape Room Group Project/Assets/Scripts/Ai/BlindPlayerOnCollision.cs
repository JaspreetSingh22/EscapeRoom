using UnityEngine;

public class BlindPlayerOnCollision : MonoBehaviour
{
    public GameObject playerCanvas; // Reference to the player's canvas
    public GameObject blindEffectPrefab; // Prefab for the blind effect
    public float blindDuration = 5f; // Duration of blindness

    private bool isBlinded = false; // Flag to track if the player is blinded
    private GameObject blindEffect; // Reference to the instantiated blind effect

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Blinding the player
            BlindPlayer();

            // Delete AI object
            Destroy(gameObject);
        }
    }

    private void BlindPlayer()
    {
        if (!isBlinded)
        {
            // Create the blind effect
            blindEffect = Instantiate(blindEffectPrefab, playerCanvas.transform);

            isBlinded = true;

            // After a duration, remove the blind effect
            Invoke(nameof(RemoveBlindness), blindDuration);
        }
    }

    private void RemoveBlindness()
    {
        if (blindEffect != null)
        {
            Destroy(blindEffect);
        }

        isBlinded = false;
    }
}
