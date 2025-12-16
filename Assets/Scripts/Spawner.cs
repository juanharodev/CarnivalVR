
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> SpawnPoints;
   public List<Rigidbody> SpawnedObjects;
    int index = 0;
    public Transform spawnPrefab;

    bool isSpawning = false;

    private void Awake()
    {
        StartSpawn();
    }
    public void StartSpawn()
    {
        if(isSpawning) return;  
        isSpawning = true;
        SpawnedObjects = new List<Rigidbody>();
        foreach (Transform item in SpawnPoints)
        {

            Rigidbody rod = Instantiate(spawnPrefab, item.position, spawnPrefab.rotation).GetComponent<Rigidbody>();
            SpawnedObjects.Add(rod);
            rod.useGravity = false;
        }
        StartCoroutine(Spawn());
    }

    public void StopSpawn()
    {
        isSpawning = false;
        index = 0;
    }

    IEnumerator Spawn()
    {


        //IListExtensions.Shuffle(SpawnedObjects);


        while (isSpawning)
        {
            

            yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
            index =  Random.Range(0, SpawnedObjects.Count);  
            SpawnedObjects[index].useGravity = true;
            SpawnedObjects.RemoveAt(index);
            if (SpawnedObjects.Count == 0)
            {
                StopSpawn();
            }
        }
    }

}
public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
