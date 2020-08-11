using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Color safeColor, hurtColor, dangerColor;
	[SerializeField] private Image fillImage;

	PlayerHealth playerHealth;
	Image healthBarImage;

	void Awake()
	{
		healthBarImage = GetComponent<Image>();
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}

	private void Start()
	{
		healthBarImage.color = safeColor;
	}

	public void UpdateHealthBar()
	{
		healthBarImage.fillAmount = playerHealth.HealthAsPercentage01;

		if (playerHealth.HealthAsPercentage01 > 0.5f)
			fillImage.color = safeColor;
		else if (playerHealth.HealthAsPercentage01 > 0.2f)
			fillImage.color = hurtColor;
		else 
			fillImage.color = dangerColor;
	}
}
