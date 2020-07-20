using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  private bool hasGameEnded = false;
  public float restartDelay = 2f;
  public GameObject completeLevelUI;
  public PlayerMovement movement;

  public void EndGame()
  {
    if (!hasGameEnded)
    {
      hasGameEnded = true;
      Debug.Log("GAME OVER");
      Invoke("Restart", restartDelay);
    }
  }

  void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void LevelComplete()
  {
    movement.enabled = false;
    completeLevelUI.SetActive(true);
  }
}
