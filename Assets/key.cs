using UnityEngine;

public class Key : MonoBehaviour
{
    public string Name; 
    public KeyHolder playerObject; 

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playerObject.gameObject)
        {
            playerObject.AddKey(this); 
            gameObject.SetActive(false); 
        }
    }
}
