using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionTrigger : MonoBehaviour {
    private SelectionManager selectionManager;

    public List<GameObject> selectedUnits = new List<GameObject>();

    public Vector3 mousePositionA;
    public Vector3 mousePositionB;

	// Use this for initialization
	void Start () {
        selectionManager = GameObject.FindObjectOfType<SelectionManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && selectionManager.mousePositionValid)
        {
            mousePositionB = selectionManager.mousePosition;

            // work out the scale for the box
            Vector3 scale = mousePositionA - mousePositionB;
            scale.y = 3f;

            // scale and reposition the box
            transform.localScale = scale;
            transform.position = (mousePositionA + mousePositionB) / 2;
        }
        else
        {
            selectionManager.isSelecting = false;
            selectionManager.selectedUnits = selectedUnits;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            selectedUnits.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            selectedUnits.Remove(other.gameObject);
    }
}
