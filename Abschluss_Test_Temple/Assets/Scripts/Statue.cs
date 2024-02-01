using UnityEngine;

public class Statue : MonoBehaviour
{
    public bool IsOnRightSpot;

    [SerializeField] private float rotationSpeed = 50f;

    [SerializeField] private GameObject rayCastTransform;

    [SerializeField] private string targetTag = "HitPoint";
    [SerializeField] private float raycastDistance = 50f;

    void Update()
    {
        if (IsMouseOverGameObject())
        {
            if (Input.GetMouseButton(0))
            {
                // Rotate to the left
                Rotate(-rotationSpeed);
            }

            if (Input.GetMouseButton(1))
            {
                // Rotate to the right
                Rotate(rotationSpeed);
            }
        }

        CastRay();
    }

    private void CastRay()
    {
        Ray ray = new Ray(rayCastTransform.transform.position, rayCastTransform.transform.forward);
        RaycastHit hit;

        // Check if the ray hits an object
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                IsOnRightSpot = true;
            }
            else
            {
                IsOnRightSpot= false;
            }
        }
    }

    void Rotate(float rotateAmount)
    {
        // Rotate the object
        transform.Rotate(Vector3.up, rotateAmount * Time.deltaTime, Space.World);
    }

    bool IsMouseOverGameObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                // Mouse over the GameObject
                return true;
            }
        }

        return false;
    }
}
