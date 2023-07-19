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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0) SpawnItem();
    }

    private void SpawnItem()
    {
        float addTime = UnityEngine.Random.Range(minSpawnAddTime, maxSpawnAddTime);
        spawnTimer = addTime;

        int chooseWhatSpawns = UnityEngine.Random.Range(1, 100);
        if (chooseWhatSpawns <= 50) SpawnMech();
        else SpawnWeapon();
        // int locationIndex = UnityEngine.Random.Range()
        // Transform spawnLocation = 
    }

    private void SpawnWeapon()
    {
        Mech newMech = _MechsToSpawn[UnityEngine.Random.Range(0, _MechsToSpawn.Count - 1)];

    }

    private void SpawnMech()
    {
        throw new NotImplementedException();
    }

    private Transform spawnLocation()
    {
        int locationIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        Transform spawnLocation = spawnPoints[locationIndex];
        print("which spawn point? = " + spawnLocation.name);
        return spawnLocation;
    }
}
