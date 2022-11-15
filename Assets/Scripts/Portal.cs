using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;
    public MeshRenderer myRenderPlane;
    Camera playerCamera;
    Camera myCamera;
    [HideInInspector] public PortalTeleport myTeleport;

    private void Awake()
    {
        playerCamera = Camera.main;
        myCamera = GetComponentInChildren<Camera>();
        myTeleport = GetComponentInChildren<PortalTeleport>();
    }

    private void Start()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0);
        myCamera.targetTexture = rt;
        linkedPortal.myRenderPlane.material.SetTexture("_MainTex", rt);

        myTeleport.receiver = linkedPortal.myTeleport.transform;
    }

    private void Update()
    {
        Matrix4x4 m = transform.localToWorldMatrix * linkedPortal.transform.worldToLocalMatrix
            * playerCamera.transform.localToWorldMatrix;
        myCamera.transform.SetPositionAndRotation(m.GetColumn(3), m.rotation);
    }

}
