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
        private bool isKnockback = false;

        private bool isInvincible = false;
        [SerializeField] private float invincibleDuration = 1f;

        private bool isJumping = false;
        private bool isSliding = false;
        private bool isDamage = false;

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
            if (!isKnockback)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // ���� Ƚ�� �ʱ�ȭ
            if (collision.gameObject.CompareTag("Ground"))
            {
                currentJumpCount = jumpCount;

                isJumping = false;
                anim.SetBool("isJumping", false);

                if (isKnockback)
                {
                    isKnockback = false;
                    anim.SetBool("isDamage", false); // �ִϵ� ����
                }
            }
        }

        // ���� ����
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

        // �����̵� ����
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

        public void Damage()
        {
            if (isInvincible) return;
            StartCoroutine(HandleDamage());
        }

        private IEnumerator HandleDamage()
        {
            isInvincible = true;
            isKnockback = true;

            float knockbackForce = 10f;
            Vector2 knockbackDir = new Vector2(-1f, 1f).normalized;
            rb.velocity = Vector2.zero;
            rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);

            anim.SetBool("isDamage", true);

            // ������ ����
            yield return new WaitForSeconds(invincibleDuration);
            isInvincible = false;

            // isKnockback�� ���� �Ŀ� Ǯ��
        }


        //public IEnumerator IncreasingSpeed()
        //{
        //    float beforeSpeed = speed;
        //    speed = 25;
        //    //���� ������� ����� ����ٸ� �߰����ֱ� �ִϸ����Ϳ��� �Ķ���� ����� �߰� �� �ָ� �� �� ����
        //    yield return new WaitForSeconds(3f);
        //    speed = beforeSpeed; //�ν��� �ߺ� ȹ�� �Ұ��� �ϰ� ���� �� ��� if���� ���� ó�� �����غ��� 
        //}

        //public void IncreaseSpeed()
        //{
        //    StartCoroutine(IncreasingSpeed());
        //}
    }
}
