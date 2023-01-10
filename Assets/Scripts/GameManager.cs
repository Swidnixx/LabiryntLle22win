using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] int time = 60;
    bool paused;
    bool gameEnded;

    int crystals = 0;
    int redKeys = 0;
    int greenKeys = 0;
    int goldKeys = 0;

    // UI references
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI diamondsText;
    public TextMeshProUGUI redKeysText;
    public TextMeshProUGUI greenKeysText;
    public TextMeshProUGUI goldKeysText;
    public GameObject snowFlake;

    public GameObject pausePanel;
    public GameObject losePanel;
    public GameObject winPanel;

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
        if (gameEnded) return;

        DisplayTime();
        DisplayPickups();

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

    // Game Flow methods
    void Pause()
    {
        Time.timeScale = 0;
        paused = true;
        Debug.Log("Game Paused");
        pausePanel.SetActive(true);
    }
    void Resume()
    {
        Time.timeScale = 1;
        paused = false;
        Debug.Log("Game Resumed");
        pausePanel.SetActive(false);
    }
    void TimerTick()
    {
        time--;
        if( time <= 0 )
        {
            time = 0;
            GameOver();
        }
        snowFlake.SetActive(false);
        //Debug.Log("Time: " + time);
    }
    void GameOver()
    {
        CancelInvoke(nameof(TimerTick));
        Debug.Log("Game Over!");
        losePanel.SetActive(true);
        Time.timeScale = 0;
        gameEnded = true;
    }
    public void Win()
    {
        CancelInvoke(nameof(TimerTick));
        Debug.Log("Game Win!");
        winPanel.SetActive(true);
        Time.timeScale = 0;
        gameEnded = true;
    }

    // Pickups helper methods
    public void AddCrystal()
    {
        crystals++;
    }
    public void AddTime(int time)
    {
        this.time += time;
    }
    public void FreezeTime(uint time)
    {
        CancelInvoke();
        InvokeRepeating(nameof(TimerTick), time, 1);
        snowFlake.SetActive(true);
    }
    public void AddKey(KeyColor keyColor)
    {
        switch(keyColor)
        {
            case KeyColor.Red:
                redKeys++;
                break;

            case KeyColor.Green:
                greenKeys++;
                break;

            case KeyColor.Gold:
                goldKeys++;
                break;
        }
    }
    public bool CheckTheKey(KeyColor keyColor)
    {
        switch(keyColor)
        {
            case KeyColor.Red:
                if(redKeys > 0)
                {
                    redKeys--;
                    return true;
                }
                break;

            case KeyColor.Green:
                if (greenKeys > 0)
                {
                    greenKeys--;
                    return true;
                }
                break;

            case KeyColor.Gold:
                if (goldKeys > 0)
                {
                    goldKeys--;
                    return true;
                }
                break;
        }

        return false;
    }

    // Display Methods
    void DisplayTime()
    {
        timeText.text = time.ToString();
    }
    void DisplayPickups()
    {
        diamondsText.text = crystals.ToString();
        redKeysText.text = redKeys.ToString();
        greenKeysText.text = greenKeys.ToString();
        goldKeysText.text = goldKeys.ToString();
    }
}
