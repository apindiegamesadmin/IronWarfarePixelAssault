using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetector : MonoBehaviour
{
    public enum shape { circle, box };
    public shape detectorShape;

    [Range(1, 15)]
    [SerializeField]
    private float viewRadius = 11;

    [SerializeField] Vector2 boxSize;
    [SerializeField] Transform targetAngle;

    [SerializeField]
    private float detectionCheckDelay = 0.1f;
    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private LayerMask playerLayerMask;
    [SerializeField]
    private LayerMask visibilityLayer;

    [field: SerializeField]
    public bool TargetVisible { get; private set; }
    public Transform Target
    {
        get => target;
        set
        {
            target = value;
            TargetVisible = false;
        }
    }

    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    private void Update()
    {
        if (Target != null)
            TargetVisible = CheckTargetVisible();
    }

    private bool CheckTargetVisible()
    {
        var result = Physics2D.Raycast(transform.position, Target.position - transform.position, viewRadius, visibilityLayer);
        if (result.collider != null)
        {
            return (playerLayerMask & (1 << result.collider.gameObject.layer)) != 0;
        }
        return false;
    }

    private void DetectTarget()
    {
        if (Target == null)
            CheckIfPlayerInRange();
        else if (Target != null)
            DetectIfOutOfRange();
    }

    private void DetectIfOutOfRange()
    {
        if (Target == null || Target.gameObject.activeSelf == false || Vector2.Distance(transform.position, Target.position) > viewRadius + 1)
        {
            Target = null;
        }
    }

    private void CheckIfPlayerInRange()
    {
        switch (detectorShape)
        {
            case shape.circle:
                Collider2D collision = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);

                if (collision != null)
                {
                    Target = collision.transform;
                }
                break;
            case shape.box:
                Collider2D collision1 = Physics2D.OverlapBox(transform.position, boxSize, targetAngle.eulerAngles.z);

                if (collision1 != null)
                {
                    Target = collision1.transform;
                }
                break;
        }
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionCheckDelay);
        DetectTarget();
        StartCoroutine(DetectionCoroutine());

    }

    private void OnDrawGizmos()
    {
        switch (detectorShape)
        {
            case shape.circle:
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(transform.position, viewRadius);
                break;
            case shape.box:
                Gizmos.color = Color.red;
                //Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
                //Gizmos.matrix = rotationMatrix;
                Gizmos.DrawWireCube(transform.position, boxSize);
                break;
        }

    }
}
