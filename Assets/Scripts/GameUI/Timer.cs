using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float playTime = 120f;
    public float CurrentTime { get; private set; } // ���� �ð�

    // �̺�Ʈ: �ð� ���� �� (���� �ð�, ��ü �ð�)
    public delegate void OnTimeChanged(float current, float total);
    public static event OnTimeChanged TimeChanged;

    // �̺�Ʈ: �ð� ���� ��
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

        // �ð��� 0�� �Ǹ� ���� �̺�Ʈ ȣ��
        TimeUp?.Invoke();
    }
}
