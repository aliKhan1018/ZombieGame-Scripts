using UnityEngine;

[RequireComponent(typeof(EnemyAttack), typeof(EnemyMovement), typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
	public static int enemyCount = 0;
	
	void OnEnable()
	{
		enemyCount++;
	}

	void OnDisable()
	{
		enemyCount--;
	}

}
