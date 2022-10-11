using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }
}
