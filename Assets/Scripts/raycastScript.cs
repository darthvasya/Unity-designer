using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class raycastScript : MonoBehaviour {
	public GameObject cub;
	public GameObject crug;
	public GameObject treyg;

	bool objectCreated = false;

	float sensitivityX = 5;
	float sensitivityY = 5;
	RaycastHit _hit;
	RaycastHit _hitDrag;

	public GameObject selectedFatherObject = null;
	public GameObject selectedObject = null;


	public Material selectedMaterial;
	public Material normalMaterial;
	public Renderer rend;

	Transform xDir;
	Transform yDir;
	Transform zDir;


	LayerMask mask = 8;
 

	float minFov = 15f;
	float maxFov = 90f;
	float sensitivity = 10f;

	void Update() {
		bool isHit = false;
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
			isHit = Physics.Raycast(ray, out _hit, Mathf.Infinity);
		 
			if(_hit.transform != null && isHit) {
				selectedObject = _hit.transform.gameObject;

				if(selectedFatherObject == null)
					selectedFatherObject = _hit.transform.gameObject;
				 
				rend = selectedFatherObject.GetComponent<Renderer>();
				rend.material = selectedMaterial;
			 
			} 
		
		}

		if (Input.GetMouseButton (1)) {
			
			float rotationX = Input.GetAxis ("Mouse X") * sensitivityX;
			float rotationY = Input.GetAxis ("Mouse Y") * sensitivityY;
			
			//Rotate the object around the camera's "up" axis, and the camera's "right" axis.
			selectedFatherObject.transform.RotateAroundLocal (Camera.main.transform.up, -Mathf.Deg2Rad * rotationX);
			selectedFatherObject.transform.RotateAroundLocal (Camera.main.transform.right, Mathf.Deg2Rad * rotationY);
		} 




		float fov = Camera.main.fieldOfView;
		fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		Camera.main.fieldOfView = fov;


	}

	public void createCub() {
		if (!objectCreated ) {
			Instantiate (cub, new Vector3(0f, 1f, 0f), Quaternion.identity);
			objectCreated = true;
		}
	}
	public void createCrug() {
		if (!objectCreated) {
			Instantiate (crug, new Vector3(0f, 1f, 0f), Quaternion.identity);
			objectCreated = true;
		}
	}
	public void createTreyg() {
		if (!objectCreated) {
			Instantiate (treyg, new Vector3(0f, 1f, 0f), Quaternion.identity);
			objectCreated = true;
		}
	}
	public void deleteObject() {
		Destroy (selectedFatherObject);
		objectCreated = false;
	}

	public void addScale(string type) {

		if (type == "x") {
			selectedFatherObject.transform.localScale += new Vector3 (0.1F, 0, 0);
		} else if (type == "y") {
			selectedFatherObject.transform.localScale += new Vector3 (0, 0.1F, 0);
		} else {
			selectedFatherObject.transform.localScale += new Vector3 (0, 0, 0.1F);
		}
	}

	public void minusScale(string type) {
		if (type == "x") {
			selectedFatherObject.transform.localScale -= new Vector3 (0.1F, 0, 0);
		} else if (type == "y") {
			selectedFatherObject.transform.localScale -= new Vector3 (0, 0.1F, 0);
		} else {
			selectedFatherObject.transform.localScale -= new Vector3 (0, 0, 0.1F);
		}
	}

 
}









/*
			if(Input.GetMouseButton (0) && selectedObject.transform == xDir) {
				Debug.Log(_hit.transform.gameObject.name);

				float rotationX = Input.GetAxis ("Mouse X") * sensitivityX;
				float rotationY = Input.GetAxis ("Mouse Y") * sensitivityY;
				
				//Rotate the object around the camera's "up" axis, and the camera's "right" axis.
				Debug.Log(rotationX);
				selectedFatherObject.transform.localScale += new Vector3(rotationX, 0, 0); // - scale
				//selectedFatherObject.transform.RotateAroundLocal (Camera.main.transform.right, Mathf.Deg2Rad * rotationY);
			}
			*/
//rigid = _hit.transform.GetComponent<Rigidbody>();
//_hit.transform
//_hit.transform.Rotate(Vector3.left * 100 * Time.deltaTime); // - rotation
//_hit.transform.localScale += new Vector3(0.1F, 0, 0); // - scale
//_hit.transform.Rotate(Vector3.left * 100 * Time.deltaTime); // - rotation









//Debug.Log (selectedFatherObject.ToString());

/*
			float rotationX = Input.GetAxis("Mouse X") * sensitivityX;
			float rotationY = Input.GetAxis("Mouse Y") * sensitivityY;
			
			//Rotate the object around the camera's "up" axis, and the camera's "right" axis.
			_hit.transform.RotateAroundLocal( Camera.main.transform.up         , -Mathf.Deg2Rad * rotationX );
			_hit.transform.RotateAroundLocal( Camera.main.transform.right      ,  Mathf.Deg2Rad * rotationY );
		*/	