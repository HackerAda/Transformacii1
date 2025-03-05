using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
    private int _counter = 0;
    private Coroutine _counterCoroutine;
    private static readonly WaitForSeconds _wait = new WaitForSeconds(0.5f);

    public void OnButtonClicked()
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
        while (true)
        {
            Debug.Log("Counter: " + _counter);
            _counter++;
            yield return _wait;
        }
    }
}