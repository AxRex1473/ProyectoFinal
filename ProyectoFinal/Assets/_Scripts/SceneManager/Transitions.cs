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
        yield return new WaitForSeconds(3f);
        StartCoroutine(LoadAsynchonously(_sceneIndex));
    }

    private IEnumerator LoadAsynchonously(int _sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            _slider.value = Mathf.Lerp(_slider.minValue, _slider.maxValue, Time.deltaTime * 0.9f);
            yield return null;
        }
    }
}
