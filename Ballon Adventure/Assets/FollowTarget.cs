using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        if (target != null)
        {
            var targetPos = target.transform.position;
            transform.position = new Vector3(targetPos.x, transform.position.y, transform.position.z) + offset;
        }
    }
}