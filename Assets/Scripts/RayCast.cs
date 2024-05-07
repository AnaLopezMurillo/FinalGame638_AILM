using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Transform interactionSource;
    public float contactDistance = 5f;
    public GameObject interactText;

    void Update()
    {
        Ray ray = new Ray(interactionSource.position, interactionSource.forward);
        Debug.DrawRay(interactionSource.position, interactionSource.forward * contactDistance, Color.green);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, contactDistance))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                interactText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
            else
            {
                interactText.SetActive(false);
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}
