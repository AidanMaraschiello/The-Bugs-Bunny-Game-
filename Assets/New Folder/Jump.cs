using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public class PlayerControl : MonoBehaviour
    {
        public float moveSpeed = 10;
        public float gravity = 10;
        public float jumpHeight = 5;


        void Awake()
        {
            GetComponent<Rigidbody>().freezeRotation = true;
            Screen.lockCursor = true;
        }


        void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 playerMove = transform.right * h + transform.forward * v;
            GetComponent<Rigidbody>().velocity = playerMove * moveSpeed;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
