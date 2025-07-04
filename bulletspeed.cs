using UnityEngine;

public class bulletspeed : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Move the bullet to the right (local forward)
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}

