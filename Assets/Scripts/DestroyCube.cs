using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Destroyer")
        {
            Destruction();
        }
    }
    private void Destruction()
    {
        Destroy(this.gameObject);
        FindObjectOfType<GameManager>().EndGame();
    }
}
