using UnityEngine;

public class Enemybehaviour : MonoBehaviour

{
    private bool isStunned = false;
    private bool canDamagePlayer = true;

    public void ApplyStun()
    {
        if (!isStunned)
        {
            isStunned = true;
            canDamagePlayer = false;
            // Optionally stop movement, animations, etc.
            StopAllCoroutines(); // Stop behavior if you're using coroutines
            Debug.Log($"{gameObject.name} has been permanently stunned.");
        }
    }

    private void Update()
    {
        if (isStunned)
        {
            // Do nothing if stunned
            return;
        }

        // Normal behavior: movement, attacking, etc.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canDamagePlayer && collision.gameObject.CompareTag("Player"))
        {
            // Deal damage or apply effects to the player
        }
    }
}
