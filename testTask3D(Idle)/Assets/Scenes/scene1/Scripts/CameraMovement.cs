using UnityEngine;

namespace Scripts
{
    public class CameraMovement : MonoBehaviour
    {

        [SerializeField] private float panSpeed = 20f;
        [SerializeField] private float zoomSpeed = 20f;
        [SerializeField] private float minZoom = 5f;
        [SerializeField] private float maxZoom = 30f;
        [SerializeField] private Vector3 minPosition;
        [SerializeField] private Vector3 maxPosition;


        void Update()
        {
            if (GameManager.instance.isNoOtherMenuShown)
            {
                if (Input.GetMouseButton(0))
                {
                    float mouseX = Input.GetAxis("Mouse X");
                    float mouseY = Input.GetAxis("Mouse Y");

                    Vector3 moveDir = new Vector3(mouseX, 0f, mouseY);

                    Vector3 desiredPos = transform.position + (-moveDir * panSpeed * Time.deltaTime);
                    desiredPos.x = Mathf.Clamp(desiredPos.x, minPosition.x, maxPosition.x);
                    desiredPos.z = Mathf.Clamp(desiredPos.z, minPosition.z, maxPosition.z);
                    transform.position = desiredPos;

                }

                float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");


                if (scrollWheelInput != 0f)
                {
                    ZoomCamera(scrollWheelInput);
                }
                else if (Input.touchCount == 2)
                {
                    ZoomCameraWithTouch();
                }
            }
        }

        void ZoomCamera(float zoomInput)
        {
            float newZoom = Mathf.Clamp(transform.position.y - zoomInput * zoomSpeed * Time.deltaTime, minZoom, maxZoom);
            Vector3 newPos = new Vector3(transform.position.x, newZoom, transform.position.z);
            transform.position = newPos;
        }
        void ZoomCameraWithTouch()
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            float newZoom = Mathf.Clamp(transform.position.y - deltaMagnitudeDiff * zoomSpeed * Time.deltaTime, minZoom, maxZoom);

            Vector3 newPos = new Vector3(transform.position.x, newZoom, transform.position.z);

            transform.position = newPos;
        }

    }
}