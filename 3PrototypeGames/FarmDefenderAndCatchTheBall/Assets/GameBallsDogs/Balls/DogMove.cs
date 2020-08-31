using UnityEngine;

public class DogMove : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private GameObject target;
    private void Update()
    {
        transform.position=Vector3.MoveTowards(transform.position,target.transform.position,velocity*Time.deltaTime);
        if (transform.position == target.transform.position)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
