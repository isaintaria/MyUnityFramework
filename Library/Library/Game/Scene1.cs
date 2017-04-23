using UnityEngine;
using System.Collections;
using System;

public class Scene1 : GameMain
{
    public override void OnFocus()
    {
        //throw new NotImplementedException();
        IngameManager.Instance.Moveable = true;
    }

    public bool isCamera3rd = true;


    public void SetUp()
    {
        isCamera3rd = IngameManager.Instance.isCamera3rd;
        if (isCamera3rd)
        {
            GameObject.Find("3rd Camera").SetActive(true);
            GameObject.Find("1st Camera").SetActive(false);            
        }
        else
        {
            GameObject.Find("3rd Camera").SetActive(false);
            GameObject.Find("1st Camera").SetActive(true);
        }
        if (isCamera3rd)
        {
            player = AssetManager.Instance.Character.Retrieve("Player_Scene1") as Player;
        }
        else
        {            
            player = AssetManager.Instance.Character.Retrieve("Player_1st_Scene1") as Player;
            GameObject.Find("1st Camera").transform.parent = player.transform;
            GameObject.Find("1st Camera").transform.position = player.transform.position;
            
       }
    }

    private Player player;
    public GameObject PlayerPosition;
    public GameObject Player1stPosition;     

    private void Awake()
    {

        SetUp();
       
        TrackingCamera.SetTarget(player.transform);
    }
}
