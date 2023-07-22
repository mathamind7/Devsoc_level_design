using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemybullet : MonoBehaviour
{
    public float speed = 15f;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        dir = player.position - transform.position;
        dir.Normalize();
        


    }
    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed*Time.fixedDeltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {   

                player.GetComponent<Hunter>().health -= 10;
            Destroy(gameObject);
        }
        
        if(collision.tag=="wall")
	{
		Destroy(gameObject);
	}

    }

}
