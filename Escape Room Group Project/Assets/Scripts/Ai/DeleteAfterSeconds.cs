using UnityEngine;
using System.Collections;

public class DeleteAfterSeconds : MonoBehaviour
{
    public float secondsUntilDelete = 5f; // Number of seconds until the GameObject is deleted

    private void Start()
    {
        StartCoroutine(DeleteAfterDelay());
    }

    private IEnumerator DeleteAfterDelay()
    {
        // Wait for the specified number of seconds
        yield return new WaitForSeconds(secondsUntilDelete);

        // Delete the GameObject
        Destroy(gameObject);
    }
}
