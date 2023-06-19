using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyai : MonoBehaviour
{
    public float checkradius, attackradius, speed, knockback;
    public LayerMask player, p_w;
    private GameObject pos;
    private Rigidbody2D rb,rb2;
    private bool checkrd, attackrd;
    private Vector2 move, dir;
    private Animator anim;
    private float hs;
    private float h = 100f;
    private bool ray_wall = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pos = GameObject.FindGameObjectWithTag("Player");
        rb2 = pos.GetComponent<Rigidbody2D>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
        checkrd = Physics2D.OverlapCircle(transform.position, checkradius, player);
        attackrd = Physics2D.OverlapCircle(transform.position, attackradius, player);
        dir = pos.transform.position - transform.position;
        dir.Normalize();
        move = dir;
        if (checkrd)
        {
            
            RaycastHit2D hit  = Physics2D.Raycast(transform.position, move, checkradius,p_w);
            
              
            if (hit.collider.tag == "Player")
            {
                
                ray_wall = true;
            }
            else if(hit.collider.tag != "Player")
            {
                ray_wall=false;
            }
        }
        else
        {
            ray_wall = false;
        }
        anim.SetBool("Start", ray_wall);
        anim.SetBool("Attack", attackrd);

        anim.SetFloat("X", dir.x);
        anim.SetFloat("Y", dir.y);
        
        
        if (h <=0f)
        {
            

            Destroy(gameObject);

        }

    }
    private void FixedUpdate()
    {
        if (ray_wall && !attackrd)
        {
            rb.MovePosition((Vector2)transform.position + (move * speed * Time.fixedDeltaTime));


        }
        if(attackrd)
        {
            rb.velocity = Vector2.zero;
        }
    }
    public void forcer()
    {
        rb2.AddForce(move * knockback, ForceMode2D.Impulse);


            pos.GetComponent<Hunter>().health -= 10;
        

    }
    public void damager()
    {
        h -= 30f;
        
    }
 
}
