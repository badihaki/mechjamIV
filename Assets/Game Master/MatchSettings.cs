using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSettings : MonoBehaviour
{
    [field: SerializeField] public int playerLives { get; private set; }
    public void SetLives(int amount) => playerLives = amount;

}
