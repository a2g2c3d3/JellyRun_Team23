using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Score
{
    public class ScoreChanger : MonoBehaviour
    {

        private void Update()
        {
            int score = ScoreManager.Instance.changeScore; // ���߿� UI�� text ���� �־��ֱ�
        }
        //TODO ���ھ�Ŵ��� ���� ���� �ް� UI���� �����ִ� Ŭ������ ���� �����ֱ�
    }
}
