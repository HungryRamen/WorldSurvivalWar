using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
    public enum EGROUND
    {
        eWall,
        eFloor,
        eCeiling,
    }

    protected EGROUND eGround;

    public EGROUND GetGround() { return eGround; }
    public void SetGround(EGROUND eground) { eGround = eground; }
}
