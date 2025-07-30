using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float playTime = 120f;
    public float CurrentTime { get; private set; } // 남은 시간

    // 이벤트: 시간 변경 시 (남은 시간, 전체 시간)
    public delegate void OnTimeChanged(float current, float total);
    public static event OnTimeChanged TimeChanged;

    // 이벤트: 시간 종료 시
    public delegate void OnTimeUp();
    public static event OnTimeUp TimeUp;

    private void Awake()
    {
        CurrentTime = playTime;
    }

    private void Start()
    {
        TimeChanged?.Invoke(CurrentTime, playTime);
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (CurrentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            CurrentTime--;
            TimeChanged?.Invoke(CurrentTime, playTime);
        }

        // 시간이 0이 되면 종료 이벤트 호출
        TimeUp?.Invoke();
    }
}
