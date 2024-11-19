using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _mesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 wishDir = (transform.forward * z + transform.right * x).normalized;

        if(wishDir != Vector3.zero)
        {
            transform.position += wishDir * _speed * Time.deltaTime;

            _mesh.transform.forward = wishDir;
        }
    }
}
