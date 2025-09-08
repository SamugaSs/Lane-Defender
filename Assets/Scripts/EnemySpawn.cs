/*****************************************************************************
// File Name : EnemySpawn.cs
// Author : Gabriel Flores-Martinez
// Creation Date : September 7, 2025
//
// Brief Description : This script spawns in enemies
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();
    List<GameObject> SPList = new List<GameObject>();
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    [SerializeField] private GameObject spawnPoint3;
    [SerializeField] private GameObject spawnPoint4;
    [SerializeField] private GameObject spawnPoint5;

    [SerializeField] private GameObject Slime;
    [SerializeField] private GameObject Snail;
    [SerializeField] private GameObject Snake;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prefabList.Add(Slime);
        prefabList.Add(Snail);
        prefabList.Add(Snake);


        SPList.Add(spawnPoint1);
        SPList.Add(spawnPoint2);
        SPList.Add(spawnPoint3);
        SPList.Add(spawnPoint4);
        SPList.Add(spawnPoint5);

        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < 1000; i++)
        {
            int prefabIndex = UnityEngine.Random.Range(0, 3);
            int SPIndex = UnityEngine.Random.Range(0, 4);
            GameObject Enemy = Instantiate(prefabList[prefabIndex], SPList[SPIndex].transform.position, Quaternion.identity);

            yield return new WaitForSecondsRealtime(5f);
        }
    }

    public void StopSpawn()
    {
        StopCoroutine(SpawnEnemies());
    }
}
