using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int maxHealth { get; private set; }
    [field: SerializeField] public int health { get; private set; }
    [field: SerializeField] public int lives { get; private set; }

    public void SetHealth(int hp = 1) => health = hp;
    public void SetLives(int stock = 3) => lives = stock;

    internal void TakeALife() => lives -= 1;
}
