using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }

        print($"Collided with {collision}");
        if (collision.CompareTag("Player") || collision.CompareTag("Arm"))
        {
            return;
        }
        print("didnt collide with arm nor player");
        if (!collision.CompareTag("Player") || !collision.CompareTag("Arm")) Destroy(gameObject);
    }
}
