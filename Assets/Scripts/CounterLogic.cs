using UnityEngine;
using System.Collections;

public class CounterLogic : MonoBehaviour
{
    private readonly float _delayBeforeIncrease = 0.5f;
    private WaitForSeconds _wait;
    private int _counter = 0;
    private Coroutine _counterCoroutine;

    public event System.Action<int> OnCounterUpdated;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delayBeforeIncrease);
    }

    public void ToggleCounter()
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
            OnCounterUpdated?.Invoke(_counter);
            _counter++;
            yield return _wait;
        }
    }
}