using System;
using UnityEngine;

public class WeaponScroller : MonoBehaviour
{
	
	public int currentWeaponIndex = 0;
	public static event Action OnWeaponChanged;

	private void Start()
	{
		SelectWeapon();
	}

	private void Update()
	{
		if(PauseMenu.GamePaused) return;

		int previousWeapon = currentWeaponIndex;

		if(Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetButtonDown("ChangeWeapon"))
		{
			if (currentWeaponIndex >= transform.childCount - 1)
				currentWeaponIndex = 0;
			else
				currentWeaponIndex++;		
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if (currentWeaponIndex <= 0)
				currentWeaponIndex = transform.childCount - 1;
			else
				currentWeaponIndex--;
		}

		if (previousWeapon != currentWeaponIndex)
			SelectWeapon();
	}

	void SelectWeapon()
	{
		int i = 0;
		foreach(Transform weapon in transform)
		{
			if(i == currentWeaponIndex)
			{
				weapon.gameObject.SetActive(true);
				OnWeaponChanged?.Invoke();
			}
			else
			{
				weapon.gameObject.SetActive(false);
			}
			i++;
		}
	}

}
