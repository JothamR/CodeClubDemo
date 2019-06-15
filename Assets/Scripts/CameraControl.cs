using UnityEngine;

public class CameraControl : MonoBehaviour 
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 6, -10);

    void Start()
    {
        this.transform.position = target.position + offset;
        this.transform.LookAt(target.position);
    }

    void Update()
    {
        this.transform.position = target.position + offset;
    }

}
