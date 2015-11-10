using UnityEngine;
using System.Collections;

public class ChasingTargetBoltMover : MonoBehaviour {

    public float speed;

    [HideInInspector]
    public  GameObject target;

    private Rigidbody boltRigidbody;
    private Transform boltTransform;

    void Start()
    {
        /*
        if (PlayerController.Instance.gameObject != null)
        {
            Player = PlayerController.Instance.gameObject;
        }
        */
        boltRigidbody = GetComponent<Rigidbody>();
        boltTransform = GetComponent<Transform>();

        StartCoroutine(moveToPlayer());
    }

    IEnumerator moveToPlayer()
    {
        while (true)
        {
            boltRigidbody.velocity = boltTransform.forward * speed;

            //if (Player != null)
            //{
            //    boltTransform.LookAt(Player.transform);
            //}

            if (target != null)
            {
                boltTransform.LookAt(target.transform);
            }

            yield return new WaitForFixedUpdate();
        }
    }

}
