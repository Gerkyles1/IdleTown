using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool isDragging = false;
    private Vector3 dragStartPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragStartPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 dragDelta = Input.mousePosition - dragStartPosition;
            float moveX = dragDelta.x * moveSpeed * Time.deltaTime;
            float moveZ = dragDelta.z * moveSpeed * Time.deltaTime; // Враховуємо Y-координату миші для руху по Z-осі

            // Переміщуємо камеру по осях X та Z
            transform.Translate(new Vector3(-moveX, 0f, -moveZ));
        }
    }
}
