using UnityEngine;
using UnityEngine.SceneManagement;

namespace HamiMicsFuncs
{
    public class Redirection : MonoBehaviour
    {
        void Start()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}