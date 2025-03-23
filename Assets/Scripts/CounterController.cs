using UnityEngine;

[RequireComponent(typeof(InputHandler), typeof(CounterLogic))]
public class CounterController : MonoBehaviour
{
    private InputHandler _inputHandler;
    private CounterLogic _counterLogic;

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        _counterLogic = GetComponent<CounterLogic>();
    }

    private void OnEnable()
    {
        _inputHandler.OnMouseButtonClicked += _counterLogic.ToggleCounter;
    }

    private void OnDisable()
    {
        _inputHandler.OnMouseButtonClicked -= _counterLogic.ToggleCounter;
    }
}