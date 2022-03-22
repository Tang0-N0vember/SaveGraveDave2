using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    [SerializeField] private GameObject GraveOpen;
    [SerializeField] private GameObject GraveClosed;
    [SerializeField] private bool isGraveOpne=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GraveOpen.SetActive(isGraveOpne?true:false);
        GraveClosed.SetActive(isGraveOpne ? false : true);
    }
}
