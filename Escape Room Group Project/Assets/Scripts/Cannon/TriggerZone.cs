using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    // Reference to the cannon GameObject
    public GameObject cannon;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            // Check if the cannon reference is set
            if (cannon != null)
            {
                // Get the PlayerBehaviour script component attached to the cannon
                PlayerBehaviour playerBehaviour = cannon.GetComponent<PlayerBehaviour>();

                // Check if the PlayerBehaviour script component is found
                if (playerBehaviour != null)
                {
                    // Call the method in the PlayerBehaviour script
                    playerBehaviour.TriggerEntered();
                }
            }
        }
    }
}
