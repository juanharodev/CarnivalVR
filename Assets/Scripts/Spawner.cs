using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform minPos;
    public Transform maxPos;

    public Transform spawnPrefab;

    bool isSpawning = false;    
    public void StartSpawn()
    {
        if(isSpawning) return;  
        isSpawning = true;
        StartCoroutine(Spawn());
    }

    public void StopSpawn()
    {
        isSpawning = false;
    }

    IEnumerator Spawn()
    {
        while (isSpawning)
        {
            
            Vector3 spawnPos = new Vector3(
                Random.Range(minPos.position.x, maxPos.position.x),
                minPos.position.y,
                Random.Range(minPos.position.z, maxPos.position.z)
            );
            Instantiate(spawnPrefab, spawnPos, spawnPrefab.rotation);
            yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
        }
    }
}
