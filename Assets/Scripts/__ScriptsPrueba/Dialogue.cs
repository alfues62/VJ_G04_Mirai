using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public string name;
    [TextArea(10,30)]
    public string[] sentences;

}
