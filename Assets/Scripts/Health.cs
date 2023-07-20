using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int _MaxHealth { get; private set; }
    [field: SerializeField] public int _Health { get; private set; }
    [field: SerializeField] public int _Lives { get; private set; }

    public void SetHealth(int hp = 1) => _Health = hp;
    public void SetLives() => _Lives = GameMaster.Instance._MatchSettings.playerLives;

    public void TakeALife() => _Lives--;
    public void TakeHealth(int health) => _Health -= health;
}
