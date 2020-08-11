using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	public GameObject[] enemies;
	[Range(0, 20)] public float timeBetweenSpawns;
	[Range(1, 50)] public uint maxEnemyCount;
	private const float ZombieProb = 0.5f;
	private const float ZoombieProb = 0.3f;

	private float timer;

	//TODO give the spawn points health so that the player may destroy them.


	private void Update()
	{
		timer += Time.deltaTime;
		//print($"Timer = {timer}");
		if (timer >= (timeBetweenSpawns + Random.Range(0f, 5.0f)) && Enemy.enemyCount < maxEnemyCount)
		{
			float spawnProb = Random.Range(0f, 1f);
			print($"SpawnProb = {spawnProb}");
			if (spawnProb > 0f && spawnProb <= 0.5f) 	SpawnEnemy(enemies[0]);				
			else if(spawnProb > 0.5f) 					SpawnEnemy(enemies[1]);
		}
	}

	void SpawnEnemy(GameObject enemy)
	{
		timer = 0f;

		Instantiate(enemy, transform.position, Quaternion.identity);
	}

}
