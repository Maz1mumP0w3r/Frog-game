using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Assign your bullet prefab in Inspector
    public Transform firePoint;      // The position where the bullet should spawn
    public float bulletSpeed = 10f;

    SpriteRenderer mySprite;
    Vector3 bulletOffset;

    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        //firePoint = Instantiate(GameObject obj)
    
    }
    void Update()
    {

        if(mySprite.flipX == false) {bulletOffset = Vector3.right;}
        else { bulletOffset = -Vector3.right;}
        firePoint.position = transform.position + bulletOffset;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate bullet at firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get Rigidbody component and set velocity
        Rigidbody rb = bullet.GetComponent<Rigidbody>();  // Use Rigidbody2D if 2D
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;  // firePoint.forward is forward direction
        }
    }
}
