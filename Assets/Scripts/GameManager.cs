using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            float randomSpawnDelay = Random.Range(1.0f, 3.0f);
            yield return new WaitForSeconds(randomSpawnDelay);
            int randomTargetIndex = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[randomTargetIndex]);
        }
    }
}
