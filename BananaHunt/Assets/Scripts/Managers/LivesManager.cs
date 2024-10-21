using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance;
    public float timeInMin;
    [SerializeField]
    TMP_Text lives;
    [SerializeField]
    TMP_Text timer;
    private int Lives;
    private float remainingTime;
    [SerializeField]
    TMP_Text mainMenuLives;
    [SerializeField]
    TMP_Text mainMenuTimer;
    
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("Lives"))
        {
            Lives = PlayerPrefs.GetInt("Lives");
            lives.text = Lives.ToString();
            mainMenuLives.text = Lives.ToString();
        }
        if (PlayerPrefs.HasKey("RemainingTime"))
        {
            remainingTime = PlayerPrefs.GetFloat("RemainingTime");
        }
        else
        {
            remainingTime = timeInMin * 60;
        }
        CheckLives();
        
    }

    void Update()
    {
        if(Lives < 5)
        {
            if (!timer.gameObject.activeSelf)
            {
                timer.gameObject.SetActive(true);
            }
            if (!mainMenuTimer.gameObject.activeSelf)
            {
                mainMenuTimer.gameObject.SetActive(true);
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60f); // Get the total minutes
            int seconds = Mathf.FloorToInt(remainingTime % 60f); // Get the remaining seconds

            // Format the time as "MM:SS"
            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

            timer.text = formattedTime;
            mainMenuTimer.text = formattedTime;
            remainingTime = remainingTime - Time.deltaTime;
            if(remainingTime <= 0)
            {
                IncreaseLives();
                remainingTime = timeInMin * 60;
            }
        }

        
        if(Lives >= 5)
        {
            Lives = 5;
            lives.text = Lives.ToString();
            mainMenuLives.text = Lives.ToString();
            if (timer.gameObject.activeSelf)
            {
                timer.gameObject.SetActive(false);
                remainingTime = timeInMin * 60;
            }
            if (mainMenuTimer.gameObject.activeSelf)
            {
                mainMenuTimer.gameObject.SetActive(false);
                remainingTime = timeInMin * 60;
            }
        }
    }
    public void IncreaseLives()
    {
        Lives = Lives + 1;
        lives.text = Lives.ToString();
        mainMenuLives.text = Lives.ToString();
    }

    void CheckLives()
    {
        if (PlayerPrefs.HasKey("LastQuitTime"))
        {
            DateTime lastQuitTime = DateTime.Parse(PlayerPrefs.GetString("LastQuitTime"));
            TimeSpan timeDifference = DateTime.Now - lastQuitTime;
            int seconds = (int)timeDifference.TotalSeconds;
            if (seconds < remainingTime)
            {
                remainingTime = remainingTime - seconds;
            }
            else
            {
                int totalMinutes = Mathf.FloorToInt(seconds / 300f); // Get the total minutes
                Lives = Lives + totalMinutes;
                lives.text = Lives.ToString();
                mainMenuLives.text = Lives.ToString();
                int totalSeconds = Mathf.FloorToInt(seconds % 300f); // Get the remaining seconds
                remainingTime = totalSeconds;

            }
        }
    }
    public void DecreaseLives()
    {
        Lives -= 1;
        lives.text = Lives.ToString();
        mainMenuLives.text = Lives.ToString();
    }

    public int GetLives()
    {
        return Lives;
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Lives", Lives);
        PlayerPrefs.SetFloat("RemainingTime", remainingTime);
        PlayerPrefs.SetString("LastQuitTime", DateTime.Now.ToString());
       
    }
}
