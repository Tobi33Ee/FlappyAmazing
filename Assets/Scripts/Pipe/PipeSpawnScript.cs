using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject topPipe;
    [SerializeField] private GameObject bottomPipe;
    [SerializeField] private GameObject goal;

    private float spawnRateMin; // Minimum Zeit zwischen Spawns
    private float spawnRateMax; // Maximale Zeit zwischen Spawns
    //private float pipeMin = 4.14f;
    //private float pipeMax = 7.77f;
    private float timer = 0f;
    private float nextSpawnTime = 0f; // Speichert das nächste zufällige Intervall
    private int currentDifficulty;

    // Initialisiere spawnTop und spawnBottom mit einem leeren Vector3
    private Vector3 spawnTop = Vector3.zero;
    private Vector3 spawnBottom = Vector3.zero;
    private float biggestGap = 15.42f;
    private float smallestGap = 8.38f;
    private float gapSize;
    private float yPosition;

    void Start()
    {
        // Initialisiere das erste Spawn-Intervall
        SetGapConstraints();
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
        spawnTop = new Vector3(transform.position.x, yPosition, transform.position.z);
        spawnBottom = new Vector3(transform.position.x, yPosition * -1f, transform.position.z);
        currentDifficulty = PlayerPrefs.GetInt("DifficultyLevel");

        Instantiate(topPipe, spawnTop, transform.rotation);
        Instantiate(bottomPipe, spawnBottom, transform.rotation);
        Instantiate(goal, transform.position, transform.rotation);
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(spawnRateMin, spawnRateMax);
        gapSize = Random.Range(smallestGap, biggestGap);
        yPosition = gapSize / 2;
    }

    void SetGapConstraints()
    {
        if(PlayerPrefs.HasKey("DifficultyLevel"))
        {
            if(PlayerPrefs.GetInt("DifficultyLevel") == 1) //Easy
            {
                biggestGap = 15.42f;
                smallestGap = 10f;
                spawnRateMin = 1f;
                spawnRateMax = 2.5f;
            }else if (PlayerPrefs.GetInt("DifficultyLevel") == 2) //Medium
            {
                biggestGap = 15.42f - 2.5f;
                smallestGap = 8.5f;
                spawnRateMin = 1f;
                spawnRateMax = 2f;
            }
            else if (PlayerPrefs.GetInt("DifficultyLevel") == 3) //Hard
            {
                biggestGap = 15.42f - 4f;
                smallestGap = 8.38f;
                spawnRateMin = 0.75f;
                spawnRateMax = 1.5f;
            }

        }
    }
}
