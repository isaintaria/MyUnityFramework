using UnityEngine;
using System.Collections;
using System;
using Library.Game;

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
            player = AssetManager.Instance.Character.Retrieve("Player_Scene1") as Player;
        }
        else
        {            
            player = AssetManager.Instance.Character.Retrieve("Player_1st_Scene1") as Player;    
       }

        if( IngameManager.Instance.isCameraNormalMode )
        {
            player.transform.FindChild("Camera").GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.None;
        }
        else
        {
            player.transform.FindChild("Camera").GetComponent<Camera>().stereoTargetEye = StereoTargetEyeMask.Both;
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
