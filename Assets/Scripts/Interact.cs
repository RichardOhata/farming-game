using TMPro;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private float raycastDistance = 3f;

    public TextMeshProUGUI interactText;

    private bool interactInput;
    private void Awake()
    {
        InputManager.Instance.controls.Enable();
    }
    private void OnEnable()
    {
        InputManager.Instance.controls.Player.Interact.performed += OnInteractPerformed;
        InputManager.Instance.controls.Player.Interact.canceled += OnInteractCanceled;
    }

    private void OnDisable()
    {
        InputManager.Instance.controls.Player.Interact.performed -= OnInteractPerformed;
        InputManager.Instance.controls.Player.Interact.canceled -= OnInteractCanceled;
    }

    private void OnInteractPerformed(UnityEngine.InputSystem.InputAction.CallbackContext ctx) 
    {
        interactInput = true;
    }

    private void OnInteractCanceled(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        interactInput = false;
    }

    // Update is called once per frame
    void Update()
    {
     
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                interactText.gameObject.SetActive(true);
                if (interactInput)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    interactInput = false;
                }

            } else
            {
                interactText.gameObject.SetActive(false);
            }
         
        }
    }
}
