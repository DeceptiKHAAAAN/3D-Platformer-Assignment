using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLogic : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        playerAnimator.SetBool("isGameOver", true);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
