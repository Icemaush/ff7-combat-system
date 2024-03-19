using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterControl : MonoBehaviour
{
    public CharacterData playerData;
    public CharacterData enemyData;

    private void Start()
    {
        playerData.target = enemyData;
        
        
        StartCoroutine(TimeRegen());
    }

    private void Update()
    {
        if (playerData.IsReadyForAction)
        {
            Debug.Log("ready to attack");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("player performed an action");
                playerData.currentSpeed = 0;
            }
        }
    }

    IEnumerator CharacterBehaviour()
    {
        yield return new WaitUntil(() => playerData.CanAttackTarget);

        // Wait untl the character has performed an action
    }

    IEnumerator TimeRegen()
    {
        while (true)
        {
            if (playerData.currentSpeed >= playerData.maxSpeed)
            {
                playerData.currentSpeed = playerData.maxSpeed;
            }
            else
            {
                // Increase current speed
                playerData.currentSpeed += Time.deltaTime;
            }
        }

        yield return null;
    }

}
