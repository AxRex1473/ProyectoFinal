using UnityEngine.SceneManagement;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    [SerializeField] GameObject _creditsGameObject;

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Credits()
    {
        _creditsGameObject.SetActive(true);
    }

    public void ReturnCredits()
    {
        _creditsGameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
