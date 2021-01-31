using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rigidBody = null;
    // Start is called before the first frame update
    private void Awake() {
        if (!m_rigidBody) { m_rigidBody = gameObject.GetComponent<Rigidbody>(); }
    }
    void Start()
    {
        m_rigidBody.AddForce(Vector3.down * 10, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
