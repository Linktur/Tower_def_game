using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int starMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;
    private void Awake()
    {
        Money = starMoney;
        Lives = startLives;

        Rounds = 0;
    }
    
}
