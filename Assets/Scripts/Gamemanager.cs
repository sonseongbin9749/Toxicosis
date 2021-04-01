using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCroissantPrefab = null;
    void Start()
    {
        StartCoroutine(SpawnCroissant());
    }
    private IEnumerator SpawnCroissant() //대기시간

    {
        float spawnDelay = 0f;
        float randomX = 0f;
        
        while (true)
        {
            
            randomX = Random.Range(-7f, 7f);
            spawnDelay = Random.Range(2f, 5f);
            for (int i = 0; i < 6; i++)
            {
                Instantiate(enemyCroissantPrefab, new Vector2(randomX, 20f), Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
            }
                
                            yield return new WaitForSeconds(spawnDelay);

        }

    }
}