using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;

        public float speed = 5f;
        public float jumpForce = 7f;

        bool isGrounded;
        
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

}
