using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterSpecialBullet : MonoBehaviour
{
    // bullet references
    private Rigidbody2D specialRb;
    private Vector2 bulletMovDir;

    public float bulletSpeed = 8f;

    private void Start()
    {
        specialRb = GetComponent<Rigidbody2D>();

        bulletMovDir = (Vector2)Hunter.instance.transform.up;

        transform.up = bulletMovDir;
    }

    private void FixedUpdate()
    {
        SpecialBulletMovement();
    }

    private void SpecialBulletMovement()
    {
        specialRb.MovePosition((Vector2)this.transform.position + bulletMovDir * bulletSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.gameObject.GetComponent<health>().damage();
            Destroy(gameObject);
        }
        if (collision.tag == "wall")
        {
            Destroy(gameObject);
        }

    }

}
