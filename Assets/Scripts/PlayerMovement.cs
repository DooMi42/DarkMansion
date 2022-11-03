using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Store store;

    [SerializeField] float moveSpeed = 5f;

    [SerializeField] Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;

    void Awake()
    {

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (store.inShopMenu) return;

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = (mousePos - rb.position).normalized;
        transform.up = lookDir;
    }
}
