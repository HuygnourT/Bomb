using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform follow;
    [SerializeField] private float limitRight, limitLeft, limitUp, limitDown;

    // Start is called before the first frame update
    void Start()
    {
        InitialPostionCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (follow == null && mainCamera == null)
            return;

        if (follow.position.x >= limitLeft && follow.position.x <= limitRight)
            mainCamera.transform.position = new Vector3(follow.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);

        if (follow.position.y >= limitDown && follow.position.y <= limitUp)
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, follow.position.y, mainCamera.transform.position.z);

    }

    private void InitialPostionCamera()
    {
        if (follow == null && mainCamera == null)
            return;

        if (follow.position.x <= limitLeft)
            mainCamera.transform.position = new Vector3(limitLeft, mainCamera.transform.position.y, mainCamera.transform.position.z);

        if (follow.position.x >= limitRight)
            mainCamera.transform.position = new Vector3(limitRight, mainCamera.transform.position.y, mainCamera.transform.position.z);

        if (follow.position.y >= limitUp)
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, limitUp, mainCamera.transform.position.z);

        if (follow.position.y <= limitDown)
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, limitDown, mainCamera.transform.position.z);
    }
}
