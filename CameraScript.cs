using UnityEngine;

[ExecuteInEditMode]
public class CameraScript : MonoBehaviour
{

	public Transform Follow;
	public Transform LookAtTarget;

	public bool lookAt = false;

	[Range(0, 1)] public float camSpeed;
    public Vector3 offset;


	private void Start()
    {
		if (Follow) {
			transform.position = offset + Follow.position;
		}	
    }

	void FixedUpdate()
    {
		if (Follow) {
			Vector3 newPos = Follow.position + offset;
			transform.position = Vector3.Lerp(transform.position, newPos, camSpeed);
		}

		if(LookAtTarget && lookAt) {
			transform.LookAt(LookAtTarget);
		}
    }

}
