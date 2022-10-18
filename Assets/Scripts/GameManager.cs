using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] int time = 60;
    bool paused;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple GMs in the Scene!!! Delete them.");
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(TimerTick),  3, 1);
    }
    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    void Pause()
    {
        Time.timeScale = 0;
        paused = true;
        Debug.Log("Game Paused");
    }
    void Resume()
    {
        Time.timeScale = 1;
        paused = false;
        Debug.Log("Game Resumed");
    }
    void TimerTick()
    {
        time--;
        if( time <= 0 )
        {
            time = 0;
            GameOver();
        }

        Debug.Log("Time: " + time);
    }
    void GameOver()
    {
        CancelInvoke(nameof(TimerTick));
        Debug.Log("Game Over!");
    }
}
