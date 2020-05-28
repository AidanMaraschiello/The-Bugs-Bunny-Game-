using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioClip pickupSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().objectsCollected++;
            AudioSource audio = other.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
            audio.clip = pickupSound;
            audio.Play();
            Destroy(gameObject);


        }
    }
}

