using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    [Space(10)]

    public UnityEvent onAttack;
    public UnityEvent onWasAttacked;

    public bool playerJustAttacked;

    [Space(16)]
    public CharacterData target;


    public void Init() {
        onAttack.AddListener(CharacterAttackDefault);
        onWasAttacked.AddListener(CharacterAttackedDefault);

        charState = CharacterState.Idle;
    }

    public void Attack() {
        onAttack.Invoke();

        // temporary attack
        target.Damage(10);
    }

    public void WasAttacked() {

    }

    public void Damage(int damageAmount) {
        if (currentHP <= 0) {
            currentHP = 0;
        }
        currentHP -= damageAmount;
        onWasAttacked.Invoke();
    }

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

    void CharacterAttackDefault() {
        playerJustAttacked = false;
        currentSpeed = 0;
    }

    void CharacterAttackedDefault() {
        Debug.Log(name + " was attacked");
    }

    public IEnumerator CharacterBehaviour()
    {
        yield return new WaitUntil(() => CanAttackTarget);

        // Wait until the character has performed an action
        yield return new WaitUntil(() => playerJustAttacked);

        onAttack.Invoke();
    }

    public IEnumerator CharacterLoop()
    {
        while (charState != CharacterState.Died)
        {
            if (currentSpeed >= maxSpeed)
            {
                currentSpeed = maxSpeed;
                charState = CharacterState.Ready;
            }
            else
            {
                // Increase current speed
                currentSpeed += Time.deltaTime;
            }

            yield return null;
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