
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
    public Text timeText;
    public Text ScoreText;
    public GameObject gameoverOverlay;
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
        //timeText = GetComponentInChildren<Transform>().Find("TimeText").GetComponent<Text>();
        //ScoreText = GetComponentInChildren<Transform>().Find("ScoreText").GetComponent<Text>();
        //gameoverOverlay = GetComponentInChildren<Transform>().Find("GameOver").gameObject;
        audioSource = GetComponent<AudioSource>();

        IngameManager.Instance.GameStart += Instance_GameStart;
        IngameManager.Instance.GameEnd += Instance_GameEnd;
     //   IngameManager.Instance.EventEnemyDamagedLeft += Instance_EventEnemyDamagedLeft;
     //   IngameManager.Instance.EventEnemyDamagedRight += Instance_EventEnemyDamagedRight;
        IngameManager.Instance.EventPlayerDamaged += Instance_EventPlayerDamaged;    
        time = gameTime;       
    }

    public void Instance_EventEnemyDamagedRight()
    {
        Score += 10;
        audioSource.clip = clips[UnityEngine.Random.Range(0, 4)];
        audioSource.Play();
        if (EffectManager.Instance.EnabledVulbEffect)
            StartCoroutine(EffectRight());
    }

    public IEnumerator EffectRight()
    {
        EffectManager.Instance.SendVibeRight(true);
        yield return new WaitForSeconds(0.1f);
        EffectManager.Instance.SendVibeRight(false);
    }

    public void Instance_EventPlayerDamaged()
    {
        Score -= 10;
        audioSource.clip = clips[4];
        audioSource.Play();
    }

    public void Instance_EventEnemyDamagedLeft()
    {
        Score += 10;
     //   audioSource.clip = clips[UnityEngine.Random.Range(0, 4)];
        audioSource.Play();
        if( EffectManager.Instance.EnabledVulbEffect )
         StartCoroutine(EffectLeft());
    }

    public IEnumerator EffectLeft()
    {
        EffectManager.Instance.SendVibeLeft(true);
        yield return new WaitForSeconds(0.1f);
        EffectManager.Instance.SendVibeLeft(false);
    }

    public void Instance_GameEnd()
    {
        Time.timeScale = 0.0f;
       // throw new NotImplementedException();
    }

    public void Instance_GameStart()
    {
 //       StartCoroutine(TimerRoutine());
    }

    public void Timer_Start()
    {
        StartCoroutine(TimerRoutine());
    }

    public IEnumerator TimerRoutine()
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
        EffectManager.Instance.SendVibeLeft(false);
        EffectManager.Instance.SendVibeRight(false);
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