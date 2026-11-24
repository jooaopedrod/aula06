
using UnityEngine;

public class GazeTeleport : MonoBehaviour
{
    [Header("Configuracao")]
    public Transform player;
    public Camera playerCamera;

    [Header("Teletransporte")]
    public float gazeTime = 2f;
    public float maxDistance = 20f;

    private WaypointController currentWaypoint;
    private float gazeTimer;
    private bool teleporting;

    void Update()
    {
        if (teleporting)
            return;

        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            WaypointController waypoint =
                hit.collider.GetComponentInParent<WaypointController>();

            if (waypoint != null)
            {
                if (currentWaypoint != waypoint)
                {
                    currentWaypoint = waypoint;
                    gazeTimer = 0f;
                }

                gazeTimer += Time.deltaTime;

                if (gazeTimer >= gazeTime)
                {
                    Teleport(waypoint);
                }

                return;
            }
        }

        currentWaypoint = null;
        gazeTimer = 0f;
    }

    void Teleport(WaypointController waypoint)
    {
        teleporting = true;

        Vector3 destination = waypoint.transform.position;
        Vector3 cameraPosition = playerCamera.transform.position;

        Vector3 offset = new Vector3(
            destination.x - cameraPosition.x,
            0f,
            destination.z - cameraPosition.z
        );

        player.position += offset;

        Debug.Log("Teletransporte realizado!");

        currentWaypoint = null;
        gazeTimer = 0f;

        Invoke(nameof(EnableTeleport), 0.5f);
    }

    void EnableTeleport()
    {
        teleporting = false;
    }
}
