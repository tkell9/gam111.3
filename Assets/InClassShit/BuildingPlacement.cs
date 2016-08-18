using UnityEngine;
using System.Collections;

public class BuildingPlacement : MonoBehaviour {


    public GameObject BuildingPrefab;

    public Material InvalidMaterial;
    public Material ValidMaterial;
    public MeshRenderer meshRenderer;
    private bool canPlace = true;
    private SelectionManager selectionManager;



    // Use this for initialization
    void Start () {
        selectionManager = FindObjectOfType<SelectionManager>();
       
	}
	
	// Update is called once per frame
	void Update () {
	    //is the selection manager in placement mode?
        if (selectionManager.inPlacementMode)
        {
            transform.position = selectionManager.mousePosition;

            if
                (Input.GetMouseButtonDown(0))
                    {
                    //Create the actual building
                    Instantiate(BuildingPrefab, transform.position, transform.rotation);
                    }
            
        }
	}

   

    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Building"))
        {
            canPlace = false;
            meshRenderer.material = InvalidMaterial;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Building"))
        {
            canPlace = true;
            meshRenderer.material = ValidMaterial;
        }
    }

    public void ConstructionComplete()
    {
        Debug.Log("Building complete!");
    }
}
