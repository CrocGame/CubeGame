using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedPanel : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {        
        SceneManager.LoadScene(0);
    }
}
