using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData_New", menuName = "GameData")]
public class SO_GameData : ScriptableObject,ISerializationCallbackReceiver
{
    public int score = 0;
    public int life = 3;
    // Start is called before the first frame update
    void ISerializationCallbackReceiver.OnAfterDeserialize(){
        score =0;
        life = 3;
    }
    void ISerializationCallbackReceiver.OnBeforeSerialize(){
        
    }
}
