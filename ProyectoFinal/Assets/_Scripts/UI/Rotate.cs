using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private GameObject _objectToRotate = default;
    [SerializeField] private float _time = default;
    [SerializeField] private float _timeToDelay = default;

    void Update()
    {
        _time = Time.deltaTime * _timeToDelay;
        _objectToRotate.transform.Rotate(0f, 1f * _time, 0f);
    }
}
