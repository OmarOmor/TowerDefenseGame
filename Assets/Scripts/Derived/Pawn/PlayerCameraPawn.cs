using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class PlayerCameraPawn : Pawn
{

    [SerializeField] float zoomSpeed = 10f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Vector2 cameraMovementLimitX;
    [SerializeField] Vector2 cameraMovementLimitY;
    float scrollValue;
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        
        if(ReceiveInput)
        {
            scrollValue = Input.GetAxis("Mouse ScrollWheel");
            cam.orthographicSize -=  scrollValue * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 14, 26);

            var hInput = -TD_HUD.Instance.TouchField.TouchDist.x;
            var vInput = -TD_HUD.Instance.TouchField.TouchDist.y;

            Vector3 currentPos = transform.position;
            float xMovement = currentPos.x + hInput * movementSpeed * Time.deltaTime;
            xMovement = Mathf.Clamp(xMovement, cameraMovementLimitX.x, cameraMovementLimitX.y);
            float yMovement = currentPos.y + vInput * movementSpeed * Time.deltaTime;
            yMovement = Mathf.Clamp(yMovement, cameraMovementLimitY.x, cameraMovementLimitY.y);
            transform.position = new Vector3(xMovement,yMovement,currentPos.z);
            
        }
    }
}
