using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    [SerializeField] private GameObject GraveOpen;
    [SerializeField] private GameObject GraveClosed;
    private bool isGraveOpen=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GraveOpen.SetActive(isGraveOpne?true:false);
        //GraveClosed.SetActive(isGraveOpne ? false : true);
    }
    public void OpenGrave()
    {
        isGraveOpen = true;
        GraveOpen.SetActive(isGraveOpen);
        GraveClosed.SetActive(!isGraveOpen);
    }
    public bool IsGraveOpen()
    {
        return isGraveOpen;
    }
}
