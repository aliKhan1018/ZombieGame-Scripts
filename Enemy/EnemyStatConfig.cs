using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shooter/Enemy/EnemyStatConfig")]
public class EnemyStatConfig : ScriptableObject
{
	public float damage;
	public float speed;
	public uint score;
}
