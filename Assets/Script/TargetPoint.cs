using UnityEngine;

public class TargetPoint : MonoBehaviour
{

    public Transform viewPoint;

    public Camera cameraLink;

    public float targetInSkyDistance;

    void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            viewPoint.position = hit.point;
        }
        else
        {
            viewPoint.position = ray.GetPoint(targetInSkyDistance);
        }

        transform.LookAt(viewPoint.transform.position);
    }
}
