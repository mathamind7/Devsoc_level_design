using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class health : MonoBehaviour
{
    public float healths = 100f, damageamt=10f;
    // Start is called before the first frame update

    public GameObject bloodParticles;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healths <= 0)
        {

            GameObject gb = Instantiate(bloodParticles, transform.position, Quaternion.identity);
            gb.GetComponent<ParticleSystem>().Play();

            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 0.1f);

            Destroy(gameObject);
        }
    }

    public void damage()
    {
        healths -= damageamt;
    }
}
