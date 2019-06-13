using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private float lastSpawnPosition;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject platform2;
    [SerializeField] private GameObject rubble;
    [SerializeField] private GameObject egg;
    [SerializeField] private GameObject shieldPower;
    [SerializeField] private GameObject life;

    [SerializeField] private float spawnConstraint = 2.5f;
    [SerializeField] private float spawnHeightPlatform = 5.5f;
    [SerializeField] private float spawnHeightPickUp = 6f;

    private float difficulty = 0;
    [SerializeField] private float difficultyLimit = 3;
    [SerializeField] private float difficultyRate = 300;

    [SerializeField] private float spawnRate = 1.5f;

    // Start is called before the first frame update
    private void Start()
    {

        lastSpawnPosition = transform.parent.position.y;
    }

    private void Awake()
    {
        StartCoroutine("RubbleSpawn");
    }

    IEnumerator RubbleSpawn()
    {
        while (true)
        {
            difficulty = (transform.parent.position.y) / difficultyRate;
            if (difficulty > difficultyLimit) difficulty = difficultyLimit;
            for (int i = 0; i < (int)Random.Range(1, 3 + difficulty); i++)
            {
                Instantiate(rubble, new Vector3(transform.parent.position.x + Random.Range(-spawnConstraint, spawnConstraint), transform.parent.position.y + spawnHeightPlatform, -1f), Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(1f, 4f - difficulty));
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (System.Math.Abs(lastSpawnPosition - transform.parent.position.y) >= spawnRate) {
            Spawn();
        }
    }

    private void Spawn()
    {
        if((int)Random.Range(0,2) > 0)
        {
            Instantiate(platform, new Vector3(transform.parent.position.x + Random.Range(-spawnConstraint, spawnConstraint), transform.parent.position.y + spawnHeightPlatform, 0), Quaternion.identity);
        } else
        {
            float position = transform.parent.position.x + Random.Range(-spawnConstraint, spawnConstraint);
            if ((int)Random.Range(0, 2) > 0)
            {
                Instantiate(egg, new Vector3(position, transform.parent.position.y + spawnHeightPickUp, -2f), Quaternion.identity);
            }
            Instantiate(platform2, new Vector3(position, transform.parent.position.y + spawnHeightPlatform, 0), Quaternion.identity);
        }
        if ((int)Random.Range(0, 9) == 0)
        {
            Instantiate(shieldPower, new Vector3(transform.parent.position.x + Random.Range(-spawnConstraint, spawnConstraint), transform.parent.position.y + spawnHeightPickUp, -1f), Quaternion.identity);
        }

        if ((int)Random.Range(0, 9) == 0)
        {
            Instantiate(life, new Vector3(transform.parent.position.x + Random.Range(-spawnConstraint, spawnConstraint), transform.parent.position.y + spawnHeightPickUp, -1f), Quaternion.identity);
        }
        lastSpawnPosition = transform.parent.position.y;
    }

}
