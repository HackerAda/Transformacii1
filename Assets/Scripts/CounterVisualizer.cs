using UnityEngine;

[RequireComponent(typeof(CounterLogic))]
public class CounterVisualizer : MonoBehaviour
{
    private CounterLogic _counterLogic;

    private void Awake()
    {
        _counterLogic = GetComponent<CounterLogic>();
    }

    private void OnEnable()
    {
        _counterLogic.OnCounterUpdated += VisualizeCounter;
    }

    private void OnDisable()
    {
        _counterLogic.OnCounterUpdated -= VisualizeCounter;
    }

    private void VisualizeCounter(int counterValue)
    {
        Debug.Log("Counter: " + counterValue); 
    }
}