using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();            
        }
        else if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("GamePlayPvsC");
        }
    }
}
