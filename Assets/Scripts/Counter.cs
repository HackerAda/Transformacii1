using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    private CounterController _counterController;

    private void Awake()
    {
        _counterController = GetComponent<CounterController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _counterController.OnButtonClicked();
        }
    }
}

public class CounterController : MonoBehaviour
{
    private int _counter = 0;
    private bool _isCounting = false;
    private Coroutine _counterCoroutine;

    public void OnButtonClicked()
    {
        if (_isCounting == false)
        {
            _isCounting = true;
            _counterCoroutine = StartCoroutine(CounterCoroutine());
        }
        else
        {
            _isCounting = false;
            StopCoroutine(_counterCoroutine);
        }
    }

    private IEnumerator CounterCoroutine()
    {
        while (true)
        {
            Debug.Log("Counter: " + _counter);
            _counter++;
            yield return new WaitForSeconds(0.5f);
        }
    }
}