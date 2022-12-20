using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public GameObject powerupPrefabs;
    private float spawnRange = 9;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    public int enemyCount;
    public int waveNumber = 1;

    // Update is called once per frame
    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefabs, GenerteSpwanPosition(), powerupPrefabs.transform.rotation);//not call
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs, GenerteSpwanPosition(), enemyPrefabs.transform.rotation);
        }
    }

    private Vector3 GenerteSpwanPosition()
    {
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosz = Random.Range(-spawnRange, spawnPosx);
        Vector3 randomPos = new Vector3(spawnPosx, 0, spawnPosz);
        return randomPos;
    }
}
