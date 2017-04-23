using System;
using System.Collections;
using UnityEditorInternal;
using UnityEngine;

public class NGTest : GameMain
{
    public GameObject LeftPosition;
    public GameObject RightPosition;
    public GameObject PlayerPosition;
    public GameObject Player1stPosition;
    public Player player;  
      
    public float startWait;
    public float spawnWait;
    public float waveWait;

    UIGameScene uiGameScene;

    public int WaveCount;

    SpawnProperty[] spawnTable;
    private bool vibeOn = false;

    public override void OnFocus() 
    {
        uiGameScene.ElapsedGameTime = 0;
        IngameManager.Instance.FIreGameStart();
        uiGameScene.Timer_Start();
        IngameManager.Instance.Moveable = false;
    }

    public void SetUp()
    {
        IngameManager.Instance.isCamera3rd = false;
        if (IngameManager.Instance.isCamera3rd)
        {
            player = AssetManager.Instance.Character.Retrieve("Player") as Player;
        }
        else
        {

            player = AssetManager.Instance.Character.Retrieve("Player1st") as Player;
        }
            if (IngameManager.Instance.isCameraNormalMode)
        {
            player.transform.FindChild("Camera").GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
        }
        else
        {
            player.transform.FindChild("Camera").GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.Both;
        }
        uiGameScene = UIManager.Instance.Open("UIGameScene") as UIGameScene;        
        IngameManager.Instance.Moveable = false;
        spawnTable = TableManager.LoadTable<SpawnTable>("SpawnTable").Datas;

    }

    private void OnEnable()
    {
        vibeOn = false;
    }

    private void Awake()
    {  
        SetUp();
        IngameManager.Instance.EventPlayerDamaged += Instance_EventPlayerDamaged;
        IngameManager.Instance.EventEnemyDamagedLeft += Instance_EventEnemyDamagedLeft;
        IngameManager.Instance.EventEnemyDamagedRight += Instance_EventEnemyDamagedRight;
        IngameManager.Instance.GameStart += Instance_GameStart;

        if (Application.isEditor)
        {
        }

    }

    

    public void Update()
    {      
    }    

    private void Instance_GameStart()
    {
        Debug.Log("겜 시작하고 몬스터가 처음 스폰");
        CreateEnemy(true);
        CreateEnemy(false);
    }
    private void Instance_EventEnemyDamagedLeft()
    {
        CreateEnemy(true);
    }
    private void Instance_EventEnemyDamagedRight()
    {
        CreateEnemy(false);
    }

    private void CreateEnemy(bool isLeft)
    {
        int timeline = uiGameScene.ElapsedGameTime;
        SpawnProperty prop = spawnTable[timeline/20];
        try
        {

        }
        catch (Exception e)
        {

        }
        GameObject spawnPosition = isLeft ? LeftPosition : RightPosition;
        Debug.Log("적이 스폰됨");
        if( spawnPosition != null )
        {
            Enemy enemy = AssetManager.Instance.Character.Retrieve("Zombie") as Enemy;
            EnemyAIController controller = enemy.GetComponent<EnemyAIController>();
            controller.SetSpawnProperty(prop);
            enemy.transform.position = spawnPosition.transform.position;
            controller.Spawn(isLeft);            
        }
    }




    private void Instance_EventPlayerDamaged()
    {
        player.Hitted();
        vibeOn = true;
    }  
    

    void Start()
    {           
    }



    private void OnApplicationQuit()
    {
    }
    private void FixedUpdate()
    {

    }

}