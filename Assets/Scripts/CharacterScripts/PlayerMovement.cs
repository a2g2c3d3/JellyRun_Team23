using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        public Transform groundCheck;
        public CapsuleCollider2D normalCollider;
        public CapsuleCollider2D slidingCollider;

        public float speed = 5f;
        public float jumpForce = 7f;
        public int jumpCount = 2;
        private int currentJumpCount;

        private bool isJumping = false;
        private bool isSliding = false;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            currentJumpCount = jumpCount;

            normalCollider.enabled = true;
            slidingCollider.enabled = false;
        }

        void Update()
        {
            Jump();
            Slide();
        }

        private void FixedUpdate()
        {
            // 앞으로 이동
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // 점프 횟수 초기화
            if (collision.gameObject.CompareTag("Ground"))
            {
                currentJumpCount = jumpCount;
            }
        }

        // 점프 구현
        public void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && currentJumpCount > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                isJumping = true;
                currentJumpCount--;
            }
        }

        // 슬라이딩 구현
        public void Slide()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !isSliding)
            {
                isSliding = true;
                normalCollider.enabled = false;
                slidingCollider.enabled = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) && isSliding)
            {
                isSliding = false;
                normalCollider.enabled = true;
                slidingCollider.enabled = false;
            }
        }
    }
}
