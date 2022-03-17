using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text waveCountdownTimer;
    public float timeBetweenWaves = 55f;
    private float countdown = 2f;

    private int waveSize = 19;

    void Update()
    {
        waveCountdownTimer.text = Mathf.Floor(countdown).ToString();

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            timeBetweenWaves += 2;
        }
        countdown -= Time.deltaTime;

    }

    IEnumerator SpawnWave()
    {
        waveSize++;

        for (int i = 0; i < waveSize; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
