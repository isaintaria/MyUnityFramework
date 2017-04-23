
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIGameScene : UIBase
{
    public int gameTime;
    private int time;
    private int score;
    
    bool gamestart = false;
    Text timeText;
    Text ScoreText;
    GameObject gameoverOverlay;
    private bool gameOver = false;
    private AudioSource audioSource;

    public AudioClip[] clips;
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            SetScoreText(score);
        }
    }

    public int ElapsedGameTime
    {
        get;set;
    }

    private void SetScoreText(int score)
    {
        ScoreText.text = "점수 : " + score;
    }

    private void Start()
    {
        timeText = GetComponentInChildren<Transform>().Find("TimeText").GetComponent<Text>();
        ScoreText = GetComponentInChildren<Transform>().Find("ScoreText").GetComponent<Text>();
        gameoverOverlay = GetComponentInChildren<Transform>().Find("GameOver").gameObject;
        audioSource = GetComponent<AudioSource>();

        IngameManager.Instance.GameStart += Instance_GameStart;
        IngameManager.Instance.GameEnd += Instance_GameEnd;
        IngameManager.Instance.EventEnemyDamagedLeft += Instance_EventEnemyDamagedLeft;
        IngameManager.Instance.EventEnemyDamagedRight += Instance_EventEnemyDamagedLeft;
        IngameManager.Instance.EventPlayerDamaged += Instance_EventPlayerDamaged;    
        time = gameTime;       

    }

 
    private void Instance_EventPlayerDamaged()
    {
        Score -= 10;
        audioSource.clip = clips[4];
        audioSource.Play();
    }

    private void Instance_EventEnemyDamagedLeft()
    {
        Score += 10;
        audioSource.clip = clips[UnityEngine.Random.Range(0, 4)];
        audioSource.Play();
    }

    private void Instance_GameEnd()
    {
        Time.timeScale = 0.0f;
       // throw new NotImplementedException();
    }

    private void Instance_GameStart()
    {
 //       StartCoroutine(TimerRoutine());
    }

    public void Timer_Start()
    {
        StartCoroutine(TimerRoutine());
    }

    private IEnumerator TimerRoutine()
    {
        while (time > 0)
        {
            ElapsedGameTime++;
            time--;
            var span = new TimeSpan(0, 0, time);
            DateTime dt = new DateTime(span.Ticks);
            timeText.text = "남은 시간 : " + dt.ToString("mm:ss");
            yield return new WaitForSeconds(1);
        }

        IngameManager.Instance.FireGameEnd();
        gameOver = true;
        gameoverOverlay.SetActive(true);
    }

    float oneSecondsLimit = 0.0f; // 타이머 함수용        
    public void FixedUpdate()
    {
       
    }

    public void GameTimer()
    {
        oneSecondsLimit += Time.deltaTime;
        if (oneSecondsLimit >= 1.0f)
        {
            oneSecondsLimit = 0.0f;
            Debug.Log(oneSecondsLimit);
            time--;
            var span = new TimeSpan(0, 0, time);
            DateTime dt = new DateTime(span.Ticks);
            timeText.text = "남은 시간 : " + dt.ToString("mm:ss");

            if (time <= 0)
            {
                IngameManager.Instance.FireGameEnd();
                gameoverOverlay.SetActive(true);
                gameOver = true;
            }
        }
    }

    public void Update()
    {        
        if( gameOver )
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.Instance.ChangeScene("Title");
                UnityEngine.Time.timeScale = 1f;
            }          
        }
    //    GameTimer();
    }

    protected override void CloseComplete()
    { 
               
    }       

    protected override void OpenComplete()
    {       
    }
}