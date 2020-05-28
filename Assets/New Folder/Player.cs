using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int objectsCollected;
    public AudioClip pickupSound;
    private AudioSource audio; 
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pickup") 
        {
            objectsCollected++;
            Destroy(collision.gameObject);
            audio.clip = pickupSound;
            audio.Play();
                
        }

    }
}
