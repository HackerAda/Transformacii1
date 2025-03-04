using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
    private int counter = 0;
    private bool isCounting = false;
    private Coroutine counterCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isCounting)
            {
                isCounting = true;
                counterCoroutine = StartCoroutine(CounterCoroutine());
            }
            else
            {
                isCounting = false;
                StopCoroutine(counterCoroutine);
            }
        }
    }

    private IEnumerator CounterCoroutine()
    {
        while (true)
        {
            Debug.Log("Counter: " + counter);
            counter++;
            yield return new WaitForSeconds(0.5f);
        }
    }
}