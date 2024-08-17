using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 5f;

    public void UpdateTimer()
    {
        timer -= Time.deltaTime;
    }

    public bool HasTimerExpired()
    {
        return timer <= 0;
    }

    public void ResetTimer()
    {
        timer = 5f;
    }

    public float GetRemainingTime()
    {
        return timer;
    }
}
