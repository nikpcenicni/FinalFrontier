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
        xUpdate(targetPosition);
        transform.position = new Vector3(Mathf.Clamp(desiredPosition.x, minX, maxX), Mathf.Clamp(desiredPosition.y, minY, maxY), desiredPosition.z); 
    }

    void xUpdate(Vector3 targetPosition) {
        if (targetPosition.x > minX)
        {
            minX = targetPosition.x;
            maxX = minX + 1;
        }
        else if (targetPosition.x < maxX)
        {
            maxX = targetPosition.x;
            minX = maxX - 1;
        }
            
    }
}
