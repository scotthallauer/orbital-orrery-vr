using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereConstraints : MonoBehaviour
{
      Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //This locks the RigidBody so that it does not move or rotate in the Z axis.

             
      if (transform.position.y >= 3) {
             m_Rigidbody.useGravity = true;
             Debug.Log("Constraints2: " + m_Rigidbody.constraints);
      }else if (transform.position.y <= 1){
         m_Rigidbody.useGravity = false;
      }
    }

    // Update is called once per frame
    void Update()
    {
       
      if (transform.position.y >= 3) {
             m_Rigidbody.useGravity = true;
             Debug.Log("Constraints2: " + m_Rigidbody.constraints);
      }else if (transform.position.y <= 1){
         m_Rigidbody.useGravity = false;
      }

    }
}
