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
            int score = ScoreManager.Instance.changeScore; // 나중에 UI에 text 값에 넣어주기
        }
        //TODO 스코어매니저 에서 값을 받고 UI점수 보여주는 클래스에 값을 보내주기
    }
}
