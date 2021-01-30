using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The referenced collider is used to apply \"Ignore Self\" option. That option won't work if set to true but this field is empty")]
    private Collider m_Collider = null;

    [SerializeField, Min(.05f)]
    [Tooltip("Defines how far this entity can detect objects")]
    private float m_SightRange = 8f;

    [SerializeField]
    [Tooltip("Defines an offset to add to this object's transform position")]
    private Vector3 m_DetectionOriginOffset = Vector3.zero;

    [SerializeField]
    [Tooltip("Defines the layers that can be detected when checking if objects are in range. You should target only the layers that the objects to detect are on")]
    private LayerMask m_RangeDetectionLayer = ~0;

    [System.Serializable]
    private class DetectionSightDebugSettings
    {
        [SerializeField]
        public Color sightRangeGizmosColor = Color.red;

        [SerializeField]
        public Color sightAngleGizmosColor = Color.red;

        [SerializeField]
        public Color detectionOriginGizmosColor = Color.magenta;

        [SerializeField, Min(.5f)]
        public float sightAngleGizmoAngleInterval = 5f;

        [SerializeField, Min(0)]
        public float detectionOriginSphereRadius = .15f;
    }

    [Header("Debug")]

    [SerializeField]
    private DetectionSightDebugSettings m_DebugSettings = new DetectionSightDebugSettings();

    private void Awake()
    {
        if (!m_Collider) { m_Collider = GetComponent<Collider>(); }
    }

    /// <summary>
    /// Gets the detection origin point, which is this object's position + the offset.
    /// </summary>
    public Vector3 DetectionOrigin
    {
        get { return transform.position + m_DetectionOriginOffset; }
    }

    /// <summary>
    /// Gets all the colliders in the detection range. Note that this method doesn't check the detection angle.
    /// </summary>
    /// <returns>Returns an array of all the detected colliders.</returns>
    public Collider[] GetAllCollidersInRange()
    {
        Collider[] objectsInRange = Physics.OverlapSphere(DetectionOrigin, m_SightRange, m_RangeDetectionLayer);

        List<Collider> output = new List<Collider>();
        foreach (Collider collider in objectsInRange)
        {
            // If the object detects itself, but "Ignore Self" option is enabled, skip the current object in range
            if (m_Collider && collider == m_Collider)
                continue;
            else
                output.Add(collider);
        }
        return output.ToArray();
    }

    /// <summary>
    /// Gets all the GameObject in the detection range. Note that this method doesn't check the detection angle.
    /// </summary>
    /// <returns>Returns an array of all the detected GameObjects.</returns>
    public GameObject[] GetAllObjectsInRange()
    {
        Collider[] objectsInRange = GetAllCollidersInRange();
        GameObject[] objs = new GameObject[objectsInRange.Length];
        for (int i = 0; i < objectsInRange.Length; i++)
        {
            objs[i] = objectsInRange[i].gameObject;
        }
        return objs;
    }

    public GameObject GetActionnableInRange()
    {
        Collider[] dialoguablesInRange = Physics.OverlapSphere(DetectionOrigin, m_SightRange, m_RangeDetectionLayer);
        return dialoguablesInRange[0].gameObject;
    }

    public bool HasActionnableInRange()
    {
        Collider[] dialoguablesInRange = Physics.OverlapSphere(DetectionOrigin, m_SightRange, m_RangeDetectionLayer);
        return dialoguablesInRange.Length > 0;
    }


    private void OnDrawGizmos()
    {
        // Draw the detection origin point
        Gizmos.color = m_DebugSettings.detectionOriginGizmosColor;
        Gizmos.DrawLine(transform.position, DetectionOrigin);
        Gizmos.DrawSphere(DetectionOrigin, m_DebugSettings.detectionOriginSphereRadius);

        // Draw sight range gizmo
        Gizmos.color = m_DebugSettings.sightRangeGizmosColor;
        Vector3 start = DetectionOrigin;
        Gizmos.DrawWireSphere(start, m_SightRange);
    }
}
