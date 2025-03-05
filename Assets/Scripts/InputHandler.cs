using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Counter _counterController;

    private void Awake()
    {
        _counterController = GetComponent<Counter>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _counterController.OnButtonClicked();
        }
    }
}