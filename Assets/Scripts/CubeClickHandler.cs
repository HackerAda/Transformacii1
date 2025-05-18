using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public event Action<Cube> OnCubeClicked;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Cube cube = hit.collider.GetComponent<Cube>();
                if (cube != null)
                {
                    OnCubeClicked?.Invoke(cube);
                }
            }
        }
    }
}