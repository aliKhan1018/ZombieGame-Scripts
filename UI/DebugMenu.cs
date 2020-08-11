using UnityEngine;
using UnityEngine.UI;

public class DebugMenu : MonoBehaviour
{
    public Text enemyCount, playerPosition;
    public Transform player;

    void LateUpdate()
    {
        enemyCount.text = "Enemy Count: " + Enemy.enemyCount.ToString();
        playerPosition.text = $"Player Postion: x:{player.position.x.ToString("F1")} " +
                              $"y:{player.position.y.ToString("F1")} z:{player.position.z.ToString("F1")}";
    }
}
