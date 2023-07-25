using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichPeople : MonoBehaviour
{
    [field: SerializeField] public List<Mech> _MechsToSpawn { get; private set; }
    [field: SerializeField] public List<WeaponScriptableObject> _WeaponsToSpawn { get; private set; }

    [SerializeField] private Transform[] spawnPoints;
    
    [Header("Spawn timer variables")]
    [SerializeField]private float spawnTimer;
    [SerializeField] private float minSpawnAddTime = 10.0f;
    [SerializeField]private float maxSpawnAddTime = 25.0f;
    bool firstSpawnIsComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        firstSpawnIsComplete = false;
        spawnTimer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            if (!firstSpawnIsComplete)
            {
                firstSpawnIsComplete = true;
                SpawnMech();
            }
            else SpawnItem();
        }
    }

        private void SpawnItem()
    {
        float addTime = UnityEngine.Random.Range(minSpawnAddTime, maxSpawnAddTime);
        spawnTimer = addTime;

        int chooseWhatSpawns = UnityEngine.Random.Range(1, 100);
        print("what spawns is at " + chooseWhatSpawns);
        
        if (chooseWhatSpawns >= 85) SpawnMech();
        else SpawnWeapon();
    }

    private void SpawnWeapon()
    {
        GameObject newWeaponPickup = Instantiate(_WeaponsToSpawn[UnityEngine.Random.Range(0, _WeaponsToSpawn.Count - 1)].weaponPickup, spawnLocation().position, Quaternion.identity);
    }

    private void SpawnMech()
    {
        Mech newMech = Instantiate(_MechsToSpawn[UnityEngine.Random.Range(0, _MechsToSpawn.Count - 1)], spawnLocation().position, Quaternion.identity);
        print("spawning a mech");
    }

    private Transform spawnLocation()
    {
        int locationIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        Transform spawnLocation = spawnPoints[locationIndex];
        return spawnLocation;
    }
}
