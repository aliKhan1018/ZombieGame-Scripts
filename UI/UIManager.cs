using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[Header("Text Fields")]
	[SerializeField] private Text AmmoCountText;
	[SerializeField] private Text HealthPercent;

	[Header("UI")]
	public GameObject InGameUI;
	public GameObject PauseMenu;
	public GameObject DebugMenu;
	public GameObject GameOver;

	PlayerHealth playerHealth;
	PlayerShooting playerShooting;

	private void Awake()
	{
		UpdateReference();
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	private void Start()
	{
		GameOver.SetActive(false);
		WeaponScroller.OnWeaponChanged += UpdateReference;
		UpdateUIText();
	}
 
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)){
			PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
			InGameUI.SetActive(!InGameUI.activeInHierarchy);
			if (PauseMenu.activeInHierarchy){
				Time.timeScale = 0.0f;
			}else Time.timeScale = 1.0f;
		}

		if(Input.GetKeyDown(KeyCode.F3)){
			DebugMenu.SetActive(!DebugMenu.activeInHierarchy);
		}
		if(!playerHealth.PlayerIsAlive){
			GameOver.SetActive(true);
		}
	}

	private void LateUpdate()
	{
		UpdateUIText();
	}
 

	void UpdateUIText()
	{
		AmmoCountText.text = "Ammo: " + playerShooting.currentBulletCountInMag + "/" + playerShooting.RemainingAmmo;
		//AmmoLeftText.text = "Remaining Ammo: " + playerShooting.RemainingAmmo;

		HealthPercent.text = playerHealth.HealthAsPercentage + "%";
	}
	
	void UpdateReference()
	{
		playerShooting = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerShooting>();
		//playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
}
