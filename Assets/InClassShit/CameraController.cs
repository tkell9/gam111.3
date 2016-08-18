using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject cameraObject;

    public float minHeight = 10f;
    public float maxHeight = 80f;

    public float minAngle = 30f;
    public float maxAngle = 80f;

    public float currentZoom = 0.5f;

    public float zoomSpeed = 10f;

    public float scrollDistance = 5f;
    public float scrollSpeed = 25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Update_Movement();

        Update_Zoom();
	}

    void Update_Movement()
    {
        // read the Horizontal and Vertical axes and move camera accordingly

        if (Input.mousePosition.x < scrollDistance)
            transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        else if (Input.mousePosition.x > (Screen.width - scrollDistance))
            transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);

        if (Input.mousePosition.y < scrollDistance)
            transform.Translate(Vector3.forward * -scrollSpeed * Time.deltaTime);
        else if (Input.mousePosition.y > (Screen.height - scrollDistance))
            transform.Translate(Vector3.forward * scrollSpeed * Time.deltaTime);
    }

    void Update_Zoom()
    {
        // update the current zoom
        float scrollInput = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        currentZoom = Mathf.Clamp01(currentZoom + scrollInput);

        // make the zooming smoother (make the resolution finer at the top and bottom end of the range)
        float lerpFactor = Mathf.Clamp01(0.5f - Mathf.Cos(currentZoom * Mathf.PI));

        // work out the new height and the new angle
        float newHeight = Mathf.Lerp(minHeight, maxHeight, lerpFactor);
        float newAngle = Mathf.Lerp(minAngle, maxAngle, lerpFactor);

        // rotate the camera
        cameraObject.transform.localEulerAngles = new Vector3(newAngle, 0f, 0f);

        // move of the camera
        Vector3 currentPosition = transform.position;
        currentPosition.y = newHeight;
        transform.position = currentPosition;

        // if we want to conform to the terrain do a raycast and set the position to
        // newHeight above the point it hits
    }
}
