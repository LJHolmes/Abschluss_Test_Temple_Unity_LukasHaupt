using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 mousePosition;

    private Rigidbody rb;

    private Apple appleScript;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        appleScript = gameObject.GetComponent<Apple>();
 
        rb.isKinematic = true;
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown() // take object, get mouse Pos
    {
        if (appleScript != null)
        {
            if (appleScript.IsInPlace)
            {
                return;
            }
        }

        rb.isKinematic = false;

        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag() // take object with mouse
    {
        if (appleScript != null)
        {
            if (appleScript.IsInPlace)
            {
                return;
            }
        }

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);

        if (Input.GetMouseButtonDown(1))
        {
            gameObject.transform.Rotate(new Vector3(45, 0, 0));
        }
    }

    private void OnMouseUp() // Drop object
    {
        if (appleScript != null)
        {
            if (appleScript.IsInPlace)
            {
                return;
            }

            rb.isKinematic = true;
        }
    }
}
