using UnityEngine;
using System;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    public event Action OnMouseButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseButtonClicked?.Invoke();
        }
    }
}
