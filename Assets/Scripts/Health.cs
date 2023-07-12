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
    public void SetLives(int stock = 3) => _Lives = stock;

    internal void TakeALife() => _Lives--;
}
