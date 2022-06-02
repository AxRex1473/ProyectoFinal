using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Transitions : MonoBehaviour
{
    [SerializeField] GameObject _creditsGameObject;
    [SerializeField] GameObject _activateTransitionPlay;
    [SerializeField] Slider _slider;

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

    public void LoadLevel(int _sceneIndex)
    {
        _activateTransitionPlay.SetActive(true);
        StartCoroutine(WaitForPlay(_sceneIndex));
    }

    private IEnumerator WaitForPlay(int _sceneIndex)
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(LoadAsynchonously(_sceneIndex));
    }

    private IEnumerator LoadAsynchonously(int _sceneIndex)
    {
        //Pregunta, Habra una mejor manera de hacer esto sin AsyncOperation
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneIndex);
        operation.allowSceneActivation = false;

        while (_slider.value < 1)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            _slider.value = Mathf.MoveTowards(_slider.value, progress, Time.deltaTime * 0.9f);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        operation.allowSceneActivation = true;
    }
}
