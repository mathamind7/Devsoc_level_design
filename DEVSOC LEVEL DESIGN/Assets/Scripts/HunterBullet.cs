using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterBullet : MonoBehaviour
{
    // Hunter bullet references
    private Rigidbody2D bulletRb;

    // hunter parameter references
    [SerializeField]
    private float bulletSpeed;

    private Vector2 bulletMovementDir;


    private void Awake()
    {

    }

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();

        bulletMovementDir = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)this.gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        BulletMovement();

    }

    private void BulletMovement()
    {
        bulletRb.MovePosition((Vector2)this.transform.position + bulletMovementDir.normalized * bulletSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.gameObject.GetComponent<health>().damage();
            Destroy(gameObject);
        }
        if(collision.tag == "enemy1")
        {
            collision.gameObject.GetComponent<enemyai>().damager();
            Destroy(gameObject);
        }

        if(collision.tag == "wall")
        {
            Destroy(gameObject);

    }

    }
}

