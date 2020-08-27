using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    /// <summary>
    /// Serialized Fields force Unity to make a disk representation of the variable/class/method/etc 
    /// for use later. This allows you to save/restore this thing at will from or to the disk
    /// (Possibly the basics of a save system?)
    /// </summary>
    [SerializeField] Transform target;
    
    //Late update is used to make an update after the traditional update
    void LateUpdate()
    {
        transform.position = target.position;
    }
}
