﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;

public class MultiplayerController
{
    private static MultiplayerController _instance = null;

    private MultiplayerController()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    public static MultiplayerController Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MultiplayerController();

            return _instance;
        }
    }

    public void SignInAndStartMPGame()
    {
        if(!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.localUser.Authenticate((bool success) =>
            {
                if(success)
                {
                    Debug.Log("Signed in! Welcome " + PlayGamesPlatform.Instance.localUser.userName);
                }
                else
                {
                    Debug.Log("Error with Signed In");
                }
            });
        }
        else
        {
            Debug.Log("Signed In Before");
        }
    }
    
}