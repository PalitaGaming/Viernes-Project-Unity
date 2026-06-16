using UnityEngine;

public class finish : MonoBehaviour
{
    
    public KeyHolder playerObject; 

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playerObject.gameObject)
        {
            playerObject.FinishTouched();
            gameObject.SetActive(false);
        }
    }
}
