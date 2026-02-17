using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    public void Play()

    {
        SceneManager.LoadScene("idk");
    }

    public void Story()

    {
        SceneManager.LoadScene("story");
    }


    public void Quit()

    {

        Application.Quit();

    }

}