using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Hand;
    Rigidbody2D rb;
    
    Vector2 direction;
    Vector2 moveDirection;

    [SerializeField] int health = 4; 
    [SerializeField] float speed;
    float offset = -90f;
    float distance;
    float attackTimer;

    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        DamagePlayer();
        DirectionToPlayer();
    }

    void FixedUpdate()
    {
        MoveToPlayer();   
    }

    void DirectionToPlayer()
    {
        if (player)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            //Debug.Log($"distance is to player is {distance}");

            if (distance > 8f) return;

            direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle + offset;
            moveDirection = direction;
        }
    }

    void MoveToPlayer()
    {
        if (player && Vector2.Distance(transform.position, player.transform.position) < 8f) rb.velocity = moveDirection.normalized * speed;
        else rb.velocity = Vector2.zero;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);

        int armDropAmount = Random.Range(1, 3);

        Instantiate(Hand, transform.position, Quaternion.identity);
    }

    void DamagePlayer()
    {
        attackTimer += Time.deltaTime;
        if (Vector2.Distance(transform.position,  player.transform.position) < 1.2f && attackTimer >= 1.5f)
        {
            Health.instance.playerTookDamage();

            attackTimer = 0;
        }
    }
}
