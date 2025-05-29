using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _lookTarget;

    private Vector3 _vector;

    // Start is called before the first frame update
    void Start()
    {
        _vector = transform.position - _lookTarget.position;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _lookTarget.position + _vector;
    }
}
