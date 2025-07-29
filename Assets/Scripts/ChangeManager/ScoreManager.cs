using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;      //�̱���

        string character;   // ĳ���� Ŭ���� �޾ƿ� �Ӽ� �̸� �����α� �տ� string�� ���߿� �ٲ��� ��
        public float changeSpeed;          // ���� �� �� ����
        public int changeHealthPoint;
        public int changeScore;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;  // ���� ������Ʈ ��ü�� �̱������� ���
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            //character = GetComponent<Character>(); �̰ɷ� �Ӽ� �޼���� ��������
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("�ӵ�����"))
            {
                changeSpeed += 0.5f;
                //�ӵ� ���� ����
            }
            if (collision.CompareTag("��ֹ�"))
            {
                changeSpeed -= 0.5f;
                //�ӵ� ���� ����
            }
            if (collision.CompareTag("ü��ȸ��"))
            {
                changeHealthPoint += 10;
                //ü�� ȸ�� ����
            }
            if (collision.CompareTag("����ȹ��"))
            {
                changeScore += 10;
                //���� �߰� ����
            }
            
        }
        //ĳ���Ϳ� ������ ���� �޼��� Ȥ�� �Ӽ��� ������ �ͼ� ���� ��ü�� ���� ü�� Ȥ�� ���� ����
    }
}
