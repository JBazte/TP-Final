using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private PlayerController Player;
    public float SmoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    private static bool cameraExists;
    private bool bounds;
    public Vector3 MinCameraPos;
    public Vector3 MaxCameraPos;
    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;
    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    // Use this for initialization
    void Start()
    {
        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
        bounds = true;
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
    }

    void FixedUpdate()
    {
        Player = FindObjectOfType<PlayerController>();
        float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, SmoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.y, SmoothTime);
        transform.position = new Vector3(posX, posY, transform.position.z);

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinCameraPos.x, MaxCameraPos.x), (Mathf.Clamp(transform.position.y, MinCameraPos.y, MaxCameraPos.y)), (Mathf.Clamp(transform.position.z, MinCameraPos.z, MaxCameraPos.z)));
        }

        if (boundBox == null)
        {
            boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
        }
    }

    public void SetBounds(BoxCollider2D newBounds)
    {
        boundBox = newBounds;
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
    }

}