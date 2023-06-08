using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractsHandler : MonoBehaviour
{
    private IInteractive _closestInteractableObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractive interactableObject))
        {
            _closestInteractableObject = interactableObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractive interactableObject))
        {
            _closestInteractableObject = null;
        }
    }

    private void Update()
    {
        if (PlayerInput.CheckInteractKeyDown() && _closestInteractableObject != null)
        {
            _closestInteractableObject.Use();
        }
    }
}
