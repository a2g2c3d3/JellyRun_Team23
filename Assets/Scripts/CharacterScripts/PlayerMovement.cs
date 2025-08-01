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
        public CapsuleCollider2D normalCollider;
        private Animator anim;

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

            anim = GetComponent<Animator>();
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

                isJumping = false;
                anim.SetBool("isJumping", false);
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
                
                if (currentJumpCount == 2)
                {
                    anim.SetBool("isJumping", true);
                }
                else if (currentJumpCount == 1)
                {
                    anim.SetTrigger("isDoubleJumping");
                }

                currentJumpCount--;
            }
        }

        // 슬라이딩 구현
        public void Slide()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !isSliding)
            {
                isSliding = true;
                
                normalCollider.offset = new Vector2(0f, -0f);
                normalCollider.size = new Vector2(1f, 0.5f);
                normalCollider.direction = CapsuleDirection2D.Horizontal;
                
                
                anim.SetBool("isSliding", true);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) && isSliding)
            {
                isSliding = false;
                normalCollider.enabled = true;
                normalCollider.offset = new Vector2(0f, 0f);
                normalCollider.size = new Vector2(1f, 1.428571f);
                normalCollider.direction = CapsuleDirection2D.Vertical;
                
                anim.SetBool("isSliding", false);
            }
        }

        //public IEnumerator IncreasingSpeed()
        //{
        //    float beforeSpeed = speed;
        //    speed = 25;
        //    //만약 사라지는 모션이 생긴다면 추가해주기 애니메이터에서 파라미터 만들어 추가 해 주면 될 것 같음
        //    yield return new WaitForSeconds(3f);
        //    speed = beforeSpeed; //부스터 중복 획득 불가능 하게 설정 할 경우 if문을 통해 처리 가능해보임 
        //}

        //public void IncreaseSpeed()
        //{
        //    StartCoroutine(IncreasingSpeed());
        //}
    }
}
