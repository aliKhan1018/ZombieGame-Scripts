using UnityEngine;

[CreateAssetMenu(menuName = "Shooter/HealthConfig")]
public class HealthConfig : ScriptableObject
{
	[Range(0, 500)]
	[SerializeField] private float m_maxHealth;

	public float MaxHealth { get => m_maxHealth; }

}
