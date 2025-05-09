using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject topPipe;
    [SerializeField] private GameObject bottomPipe;

    [SerializeField] private float spawnRateMin = 3f; // Minimum Zeit zwischen Spawns
    [SerializeField] private float spawnRateMax = 10f; // Maximale Zeit zwischen Spawns
    private float timer = 0f;
    private float nextSpawnTime = 0f; // Speichert das nächste zufällige Intervall
    private float pipeMax = 9.41f;
    private float pipeMin = 4.3f;

    void Start()
    {
        // Initialisiere das erste Spawn-Intervall
        SetNextSpawnTime();
        spawnPipe();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            spawnPipe();
            timer = 0f;
            SetNextSpawnTime(); // Berechne das nächste zufällige Intervall
        }
    }

    void spawnPipe()
    {
        Vector3 spawnTop = new Vector3(transform.position.x, Random.Range(pipeMin, pipeMax), transform.position.z);
        Vector3 spawnBottom = new Vector3(transform.position.x, Random.Range(pipeMin, pipeMax) * -1f, transform.position.z);

        Instantiate(topPipe, spawnTop, transform.rotation);
        Instantiate(bottomPipe, spawnBottom, transform.rotation);
    }

    void SetNextSpawnTime()
    {
        // Berechne ein zufälliges Intervall zwischen Min und Max
        nextSpawnTime = Random.Range(spawnRateMin, spawnRateMax);
    }
}
