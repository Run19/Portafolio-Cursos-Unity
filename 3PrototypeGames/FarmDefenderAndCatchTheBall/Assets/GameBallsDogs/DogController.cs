using System.Collections;
using UnityEngine;

public class DogController : MonoBehaviour
{
    PlayerInput _controll;
    private bool _dumpTime;
    [SerializeField] private GameObject dog;
    [SerializeField] private float timeBetweenDogs;

    private void Awake()
    {
        _dumpTime = true;
        _controll = new PlayerInput();
        _controll.Dog.GoDog.performed += ctx => StartCoroutine(GoDog());
    }

    private IEnumerator GoDog()
    {
        if (_dumpTime)
        {
            _dumpTime = false;
            GoDogM();
            yield return new WaitForSeconds(timeBetweenDogs);
            _dumpTime = true;
        }
    }

    private void GoDogM()
    {
        Instantiate(dog, this.transform.position, dog.transform.rotation);
    }

    private void OnEnable()
    {
        _controll.Enable();
    }

    private void OnDisable()
    {
        _controll.Enable();
    }
}