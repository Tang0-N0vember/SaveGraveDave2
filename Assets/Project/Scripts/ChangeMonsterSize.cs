using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMonsterSize : MonoBehaviour
{
    [SerializeField] float headSize;
    [SerializeField] float bodySize;
    [SerializeField] float armSize;
    [SerializeField] float legSize;

    [SerializeField] GameObject monsterHead;
    [SerializeField] GameObject monsterBody;
    [SerializeField] GameObject monsterArmLeft;
    [SerializeField] GameObject monsterArmRight;
    [SerializeField] GameObject monsterLegLeft;
    [SerializeField] GameObject monsterLegRight;

    private void Awake()
    {
        //headSize = GameDirector.instance.GetHeadCount()+1;
    }
    private void Update()
    {
        monsterBody.transform.localScale = Vector3.one * bodySize;
        monsterHead.transform.localScale=Vector3.one*headSize/bodySize;
        monsterArmLeft.transform.localScale = Vector3.one * armSize / bodySize;
        monsterArmRight.transform.localScale = Vector3.one * armSize / bodySize;
        monsterLegLeft.transform.localScale = Vector3.one * legSize;
        monsterLegRight.transform.localScale = Vector3.one * legSize;

    }
}
