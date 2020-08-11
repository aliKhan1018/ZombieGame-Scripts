using UnityEngine;

[CreateAssetMenu(menuName="Shooter/Weapons/Gun")]
public class GunConfig : ScriptableObject
{
    [Header("Stats")]
    public float fireRate;
    [Range(1,100)] public float firePower;
    public float range;

    [Space]

    [Header("Ammo")]
    public int magazineSize;

    [Space]

    [Header("Sounds")]
	public AudioClip gunshot;
    public AudioClip reload;
	
}
