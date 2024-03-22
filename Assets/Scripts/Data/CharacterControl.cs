using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public CharacterData characterData;
    public CharacterControl targetData;

    private void Start()
    {
        characterData.Init();

        characterData.target = targetData.characterData;
        
        StartCoroutine(characterData.CharacterLoop());
    }

    private void Update()
    {
        if (characterData.IsReadyForAction)
        {
            Debug.Log("ready to attack");
            if (characterData.charTeam == CharacterTeam.Friendly && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("player performed an action");
                characterData.Attack();
            }
        }
    }
}
