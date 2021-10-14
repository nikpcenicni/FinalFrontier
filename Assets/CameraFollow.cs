using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    
    public Transform target;
    public float smoothTime = 0.3f;
    public float posY;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private Vector3 velocity = Vector3.zero;
    void Update() {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, posY, -10));
        Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        minXUpdate(targetPosition);
        transform.position = new Vector3(Mathf.Clamp(desiredPosition.x, minX, maxX), Mathf.Clamp(desiredPosition.y, minY, maxY), desiredPosition.z); 
    }

    void minXUpdate(Vector3 targetPosition) {
        if (targetPosition.x > minX)
            minX = targetPosition.x;
        else if (target.position.x == (targetPosition.x/3))
            minX = (targetPosition.x/4); 
    }
}