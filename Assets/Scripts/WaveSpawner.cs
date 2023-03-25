using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform enemyPrefab;
    public float timeBetweenWaves = 5f;
    public TMP_Text CountdownText;
    private float countdown = 2f;
    public Transform spawnPoint;
    private int WaveNumber = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        CountdownText.text = Mathf.Floor(countdown).ToString();
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (var i = 0; i <= WaveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        WaveNumber++;
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
