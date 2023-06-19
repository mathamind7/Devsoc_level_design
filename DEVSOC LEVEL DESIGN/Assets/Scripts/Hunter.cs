using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class Hunter : MonoBehaviour
{
    // Player references
    private Rigidbody2D hunterRb;

    // astronaut movement references
    private Vector2 movement;


    public float hunterSpeed = 5f;

    // Other gameobject references and variables
    private Vector2 mousePos;

    public GameObject gunBulletPrefab;
    public GameObject specialBulletPrefab;

    public ParticleSystem muzzleFlash;
    public Transform shootingPoint;

    public AudioSource shootingSource;
    public AudioSource walkingSource;

    private float walkTime = 0;

    // special move references


    
   
    public GameObject black;

    public static Hunter instance;

    //health
    public float health = 100f;
    public float totalHealth = 400;

    private Animator anim;

    private float myTime = 0;
    private float fadeBlackTime = 5f;

    bool canEnd = false;

    private bool canFade = true;
    float balpha = 1;
    private void Start()
    {
        hunterRb = GetComponent<Rigidbody2D>();
        instance = this;
        anim = GetComponentInChildren<Animator>();

        shootingSource = GetComponent<AudioSource>();

        

    }

    private void Update()
    {
        // for the camera shake;

        if(canFade)
        {
            myTime += Time.deltaTime;

            balpha = Mathf.Lerp(1,0,myTime/fadeBlackTime);
            
            black.GetComponent<CanvasGroup>().alpha = balpha;

            if(balpha == 0)
            {
                canFade = false;
                myTime = 0f;
            }
        }

        if(movement != Vector2.zero)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        // getting the inputs
        GetInput();

        // make the player face the mouse
        MouseFace();

        // Make the hunter move
       
        //die
        if (health <= 0)
        {
            
            StartCoroutine(StartSceneAgain());
        }

        IEnumerator StartSceneAgain()
        {


            // yield return new WaitForSecondsRealtime(5f);
            yield return null;
             if(health<=0)
            {
                myTime += Time.deltaTime;
                if(myTime > fadeBlackTime)
                {
                    canEnd = true;
                    myTime = 0;
                }

                balpha = Mathf.Lerp(0,1,myTime/fadeBlackTime);
                black.GetComponent<CanvasGroup>().alpha = balpha;


                if(canEnd)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }


        //check for door
        


    }

    private void FixedUpdate()
    {
        HunterMovement();
    }

    

    void GetInput()
    {
        // setting the movement vector based on input


            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        

       

        // Click the mouse button to shoot
        if (Input.GetMouseButtonDown(0))
            HunterShooting();


    }

    // Code for  setting the player to face the direction of the mouse.
    private void MouseFace()
    {
            transform.up = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    // Code which updates the movement of the hunter
    private void HunterMovement()
    {
        // hunterRb.MovePosition((Vector2)this.transform.position + hunterSpeed * Time.fixedDeltaTime * movement.normalized);
        hunterRb.AddForce(movement.normalized * hunterSpeed* Time.fixedDeltaTime);

        if(movement.magnitude >0)
        {
            walkTime += Time.fixedDeltaTime;

            if (walkTime > 0.2f)
            {
                walkTime = 0;
                walkingSource.Play();
            }
        }
        
    }

    // Code which makes the hunter shoot normal bullets
    private void HunterShooting()
    {
        muzzleFlash.Play();
        shootingSource.Play();
        GameObject bulletObject = Instantiate(gunBulletPrefab, shootingPoint.position, Quaternion.identity);
    }

    // Code to invoke the special move of the hunter



}
