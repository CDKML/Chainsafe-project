using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFTColliderManager : MonoBehaviour
{
    [SerializeField]
    private string URL;
    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player touched collider");
            Application.OpenURL(URL);
        }
    }
}
