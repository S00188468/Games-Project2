using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    public PathNode NextNode;
    public Color debugColor = Color.red;
    private void OnDrawGizmos()
    {
        if (NextNode!=null)
        {
            Gizmos.color = debugColor;
            Gizmos.DrawLine(transform.position, NextNode.transform.position);

            Vector3 direction = NextNode.transform.position - transform.position;
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, (transform.position + direction* 0.5f));
        }
    }
}
