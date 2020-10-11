using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    world,
    menu,
    battle
}

public class GameManager : MonoBehaviour
{
    public LogicBridge logicBridge;

    public void PlayerDirectionInputHandler(KeyCode keyCode) 
    {
        
    }

    internal void Init()
    {
        // logic init
    }
}
