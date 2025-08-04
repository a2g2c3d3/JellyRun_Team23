using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeActionController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public LineRenderer ropeLine;
    private SpringJoint2D ropeJoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

            // 2D Raycast
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                ConnectRope(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            DisconnectRope();
        }
    }

    void LateUpdate()
    {
        if (ropeJoint != null)
        {
            Vector3 playerPos = new Vector3(playerRb.position.x, playerRb.position.y, 0f);
            ropeLine.SetPosition(0, playerPos);

            Vector3 anchorPos = new Vector3(ropeJoint.connectedAnchor.x, ropeJoint.connectedAnchor.y, 0f);
            ropeLine.SetPosition(1, anchorPos);
        }
        else
        {
            ropeLine.positionCount = 0;
        }
    }

    void ConnectRope(Vector2 targetPoint)
    {
        if (ropeJoint != null) Destroy(ropeJoint);

        ropeJoint = playerRb.gameObject.AddComponent<SpringJoint2D>();
        ropeJoint.autoConfigureConnectedAnchor = false;
        ropeJoint.connectedAnchor = targetPoint;

        float distance = Vector2.Distance(playerRb.position, targetPoint);
        ropeJoint.distance = distance * 0.8f;  // 스프링 조절

        ropeJoint.dampingRatio = 0.7f;  // 댐핑 (0~1)
        ropeJoint.frequency = 3f;       // 스프링 강도

        ropeLine.positionCount = 2;
    }

    void DisconnectRope()
    {
        if (ropeJoint != null)
        {
            Destroy(ropeJoint);
            ropeJoint = null;
            ropeLine.positionCount = 0;
        }
    }
}
