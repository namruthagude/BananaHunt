using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float Speed;
    public int Distance = 0;
    public int Bananas =  0;
    public bool isGameOver = false;


    [SerializeField]
    TMP_Text bananas;
    [SerializeField]
    TMP_Text distance;
    [SerializeField]
    GameObject GameOverPanel;
    private float totalDistance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       

        if (PlayerPrefs.HasKey("Bananas"))
        {
            Bananas = PlayerPrefs.GetInt("Bananas");
            bananas.text = Bananas.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            totalDistance   += Speed * Time.deltaTime;
            Distance = (int)totalDistance;
            distance.text = Distance.ToString();

        }

    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);

    }
    public void IncreaseLives()
    {
        LivesManager.instance.IncreaseLives();
        
    }

    public void DecreaseLives() {
        LivesManager.instance.DecreaseLives();
        
    }

    public void IncreaseBanana()
    {
        Bananas = Bananas + 1;
        bananas.text = Bananas.ToString();
    }

    void OnApplicationQuit()
    {
        
        PlayerPrefs.SetInt("Bananas", Bananas); 
    }
}
