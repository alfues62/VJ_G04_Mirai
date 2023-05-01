using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class lockOn : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Camera mainCamera;            // your main camera object.
    [SerializeField] private CinemachineFreeLook cinemachineFreeLook; //cinemachine free lock camera object.
    [Header("UI")]
    [SerializeField] private Image aimIcon;  // ui image of aim icon u can leave it null.
    [Header("Settings")]
    [SerializeField] private string enemyTag; // the enemies tag.
    [SerializeField] private KeyCode _Input;
    [SerializeField] private Vector2 targetLockOffset;
    [SerializeField] private float minDistance; // minimum distance to stop rotation if you get close to target
    [SerializeField] private float maxDistance;

    private GameObject[] targets;
    public GameObject target;

    public bool isTargeting;

    private float maxAngle;
    private Transform currentTarget;
    private float mouseX;
    private float mouseY;
    [SerializeField] private int targetIndex;

    void Start()
    {
        maxAngle = 90f; // always 90 to target enemies in front of camera.
        cinemachineFreeLook.m_XAxis.m_InputAxisName = "";
        cinemachineFreeLook.m_YAxis.m_InputAxisName = "";
        targetIndex = -1;
    }

    void Update()
    {
        if (currentTarget == null)
        {
            isTargeting = false;
            currentTarget = null;
            targetIndex = -1;
        }

        if (!isTargeting)
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.P))
            {
                GameObject newTarget = ClosestTarget();
                if (newTarget != null)
                {
                    currentTarget = newTarget.transform;
                    targetIndex = -1;
                }
            }
            else
            {
                NewInputTarget(currentTarget);
            }

            // Si hay un objetivo actual, haz que el personaje mire hacia él
            if (currentTarget != null)
            {
                transform.LookAt(currentTarget);
            }

            // Agregar esta línea para suavizar la rotación de la cámara
            cinemachineFreeLook.m_YAxis.m_MaxSpeed = 5f;
            cinemachineFreeLook.m_XAxis.m_MaxSpeed = 200f;
        }

        if (aimIcon)
            aimIcon.gameObject.SetActive(isTargeting);

        cinemachineFreeLook.m_XAxis.m_InputAxisValue = mouseX;
        cinemachineFreeLook.m_YAxis.m_InputAxisValue = mouseY;

        if (Input.GetKeyDown(_Input))
        {
            AssignTarget();
        }
    }

    private void AssignTarget()
    {
        if (isTargeting)
        {
            isTargeting = false;
            currentTarget = null;
            target = null; // Añade esta línea para desasignar el target actual
            return;
        }

        GameObject closestTarget = ClosestTarget();
        if (closestTarget != null)
        {
            currentTarget = closestTarget.transform;
            isTargeting = true;
            target = closestTarget; // Añade esta línea para asignar el nuevo target
        }
    }

    private void NewInputTarget(Transform target)
    {
        if (!currentTarget) return;

        Vector3 viewPos = mainCamera.WorldToViewportPoint(target.position);

        if (aimIcon)
            aimIcon.transform.position = mainCamera.WorldToScreenPoint(target.position);

        float distanceToTarget = (target.position - transform.position).magnitude;
        if (distanceToTarget > maxDistance) // Si el jugador está demasiado lejos o demasiado cerca, no se fija.
        {
            isTargeting = false;
            currentTarget = null;
            target = null; // Añade esta línea para desasignar el target actual
            return;
        }

        mouseX = (viewPos.x - 0.5f + targetLockOffset.x) * 3f;
        mouseY = (viewPos.y - 0.5f + targetLockOffset.y) * 3f;

        currentTarget = target.transform;
    }



    private GameObject ClosestTarget()
    {
        Debug.Log("Finding closest target...");
        targets = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject closest = null;
        float distance = maxDistance;
        float currAngle = maxAngle;
        Vector3 position = transform.position;
        foreach (GameObject go in targets)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.magnitude;
            if (curDistance < distance)
            {
                Vector3 viewPos = mainCamera.WorldToViewportPoint(go.transform.position);
                Vector2 newPos = new Vector3(viewPos.x - 0.5f, viewPos.y - 0.5f);
                if (Vector3.Angle(diff.normalized, mainCamera.transform.forward) < maxAngle)
                {
                    closest = go;
                    currAngle = Vector3.Angle(diff.normalized, mainCamera.transform.forward.normalized);
                    distance = curDistance;
                }
            }
        }
        Debug.Log("Closest target: " + closest + " Distance: " + distance + " Angle: " + currAngle);
        return closest;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
