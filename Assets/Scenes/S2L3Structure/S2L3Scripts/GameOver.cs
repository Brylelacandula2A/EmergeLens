using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [Tooltip("The Game Over UI screen to show. Drag your Game Over panel here.")]
    public GameObject gameOverScreen;

    [Tooltip("Optional: pause the game when triggered.")]
    public bool pauseOnGameOver = true;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        if (pauseOnGameOver)
        {
            Time.timeScale = 0f;
        }
    }
}