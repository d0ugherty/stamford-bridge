using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    public string type;

    public void SetType(string typStr){
        type = typStr;
    }
    
    public string GetType(){
        return type;
    }

}
