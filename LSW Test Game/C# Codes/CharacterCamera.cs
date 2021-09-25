using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    private GameObject ThisObject;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        ThisObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ThisObject.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, this.transform.position.z);
    }
}
