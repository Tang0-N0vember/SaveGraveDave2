using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMonsterSize : MonoBehaviour
{
    [SerializeField] float headSize;

    [SerializeField] GameObject monsterHead;
    [SerializeField] GameObject monsterBody;
    [SerializeField] GameObject monsterArmLeft;
    [SerializeField] GameObject monsterArmRight;
    [SerializeField] GameObject monsterLegLeft;
    [SerializeField] GameObject monsterLegRight;

    private void Awake()
    {
        headSize = GameDirector.instance.GetHeadCount()+1;
    }
    private void Update()
    {
        monsterHead.transform.localScale=Vector3.one*headSize;
    }
}
