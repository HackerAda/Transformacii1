using UnityEngine;
using System.Collections;


public class Counter : MonoBehaviour
{
    private static readonly float COUNTER_DELAY = 0.5f; 
    private WaitForSeconds _wait; 
    private int _counter = 0;
    private Coroutine _counterCoroutine;
    private InputHandler _inputHandler;

    private void Awake()
    {
        _wait = new WaitForSeconds(COUNTER_DELAY);
        _inputHandler = GetComponent<InputHandler>();
    }

    private void OnEnable()
    {
        if (_inputHandler != null)
        {
            _inputHandler.OnMouseButtonClicked += HandleMouseClick;
        }
    }

    private void OnDisable()
    {
        if (_inputHandler != null)
        {
            _inputHandler.OnMouseButtonClicked -= HandleMouseClick;
        }
    }

    private void HandleMouseClick()
    {
        if (_counterCoroutine == null)
        {
            _counterCoroutine = StartCoroutine(CounterCoroutine());
        }
        else
        {
            StopCoroutine(_counterCoroutine);
            _counterCoroutine = null;
        }
    }

    private IEnumerator CounterCoroutine()
    {
        while (enabled) 
        {
            Debug.Log("Counter: " + _counter);
            _counter++;

            yield return _wait;
        }
    }
}