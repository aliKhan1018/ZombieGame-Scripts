using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

	[SerializeField] private EnemyStatConfig statConfig;

	public float timeBetweenAttacks = 0.5f;
	public float Damage { get => statConfig.damage; }

	private bool playerInRange = false;
	private float timer;

	PlayerHealth playerHealth;

	private void Awake()
	{
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}

	private void Update()
	{
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange)
		{
			Attack();
		}
	}

	void Attack()
	{
		timer = 0f;

		if(playerHealth.CurrentHealth > 0f)
		{
			playerHealth.TakeDamage(Damage);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerInRange = true;
		}
		
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerInRange = false;
		}																	
	}	
	

}
