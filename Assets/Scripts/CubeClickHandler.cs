using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
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
                    CubeBehaviour cubeBehaviour = cube.GetComponent<CubeBehaviour>();
                    if (cubeBehaviour != null)
                    {
                        cubeBehaviour.HandleClick();
                    }
                }
            }
        }
    }
}