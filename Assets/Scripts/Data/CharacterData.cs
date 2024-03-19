using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string name = "Pikachu";

    [Space(10)]

    public int maxHP = 100;
    public int currentHP = 100;

    [Space(10)]

    public int maxMP = 100;
    public int currentMP = 100;

    [Space(10)]

    public float maxLB = 100;
    public float currentLB = 100;

    [Space(10)]

    public float maxSpeed = 10;
    public float currentSpeed = 10;

    [Space(10)]

    public CharacterState charState;
    public CharacterTeam charTeam;

    [Space(16)]
    public CharacterData target;

    public bool CanAttackTarget
    {
        get
        {
            return target.charState == CharacterState.Idle || target.charState == CharacterState.Idle;
        }
    }



    public bool IsReadyForAction
    {
        get
        {
            return currentSpeed >= maxSpeed;
        }
    }
}

public enum CharacterTeam
{
    Friendly,
    Enemy
}

public enum CharacterState
{
    Loading,
    Idle,
    Ready,
    Attacking,
    Defending,
    Died
}