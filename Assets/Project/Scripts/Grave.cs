using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    [SerializeField] private GameObject GraveOpen;
    [SerializeField] private GameObject GraveClosed;
    private bool isGraveOpen=false;
    // Start is called before the first frame update
    
    public void OpenGrave()
    {
        ICollectible collectible =gameObject.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();
        }
        isGraveOpen = true;
        GraveOpen.SetActive(isGraveOpen);
        GraveClosed.SetActive(!isGraveOpen);
    }
    public bool IsGraveOpen()
    {
        return isGraveOpen;
    }
}
