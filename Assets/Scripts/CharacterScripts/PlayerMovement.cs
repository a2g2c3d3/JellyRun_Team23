using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        public Transform groundCheck;

        public float speed = 5f;
        public float jumpForce = 7f;

        bool isGrounded;

        public float groundCheckRadius = 0.2f;
        public LayerMask groundLayer;

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

        private void FixedUpdate()
        {
            // ������ �̵�
            rb.velocity = new Vector2(speed, rb.velocity.y);

            // �ٴ� üũ
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
    }
}
