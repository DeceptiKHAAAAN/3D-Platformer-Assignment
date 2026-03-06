using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
