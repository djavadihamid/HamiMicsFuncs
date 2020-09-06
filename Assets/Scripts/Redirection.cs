using UnityEngine;
using UnityEngine.SceneManagement;

public class Redirection : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }
}