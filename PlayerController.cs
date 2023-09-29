using System;
using System.Collections;
using UnityEditor.Profiling;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 MovementSpeed = new Vector2(5.0f, 5.0f);
    private Vector2 inputVector = new Vector2(0.0f, 0.0f);
    public Vector2 mousePos;

    public Camera cam;
    public int playerHealth = 10;
    public Rigidbody2D rb;
    public CircleCollider2D cc;
    public Weapon weapon;
    
    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
    }

    void FixedUpdate()
    { 
        rb.MovePosition(rb.position + (inputVector * MovementSpeed * Time.fixedDeltaTime));
        Vector2 lookdir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f; 
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController other = collision.gameObject.GetComponent<EnemyController>();
        if (other)
        {
            Destroy(gameObject); 
        }
    }
}