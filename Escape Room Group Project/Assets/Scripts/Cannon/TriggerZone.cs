using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    // Reference to the cannon GameObject
    public GameObject cannon;
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (cannon != null)
            {
                PlayerBehaviour playerBehaviour = cannon.GetComponent<PlayerBehaviour>();
                if (playerBehaviour != null)
                {
                    
                    playerBehaviour.TriggerEntered();
                }
            }
        }
    }
}
