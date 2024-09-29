using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance;
    [SerializeField]
    TMP_Text lives;
    private int Lives;
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
        }

    }

    void Update()
    {
        if(Lives < 5 && Lives > 0)
        {
            Debug.Log("Start Timer");
        }

        
        if(Lives >= 5)
        {
            Lives = 5;
            lives.text = Lives.ToString();
        }
    }
    public void IncreaseLives()
    {
        Lives = Lives + 1;
        lives.text = Lives.ToString();
    }

    public void DecreaseLives()
    {
        Lives -= 1;
        lives.text = Lives.ToString();
    }

    public int GetLives()
    {
        return Lives;
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Lives", Lives);
       
    }
}
