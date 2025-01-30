using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BasketballShooter : MonoBehaviour
{
    public GameObject basketballPrefab; // Assign your basketball prefab in the inspector
    public Transform shootPoint; // Assign a point where the ball should spawn from
    public float shootForce = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        Debug.Log("ShootBall() called!");

        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calculate direction
        Vector2 shootDirection = (mousePosition - shootPoint.position).normalized;

        // Instantiate the basketball and apply force
        GameObject basketball = Instantiate(basketballPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = basketball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        }
    }
}

