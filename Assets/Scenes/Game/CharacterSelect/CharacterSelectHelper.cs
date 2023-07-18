using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectHelper : MonoBehaviour
{
    [SerializeField] private GameObject intro;
    [SerializeField] private GameObject startingGame;
    public void StartHelper()
    {
        intro.SetActive(true);
        startingGame.SetActive(false);
    }

    public void StartingGame()
    {
        startingGame.SetActive(true);
    }
}
