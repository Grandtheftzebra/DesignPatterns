using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public Player Player;

    private IVisitor _visitor;

    private void Start()
    {
        _visitor = new PlayerPrefsVisitor();
    }

    public void SaveData()
    {
        Player.Accept(_visitor);
        
        Utilities.PrintPlayerPrefs();
    }
}