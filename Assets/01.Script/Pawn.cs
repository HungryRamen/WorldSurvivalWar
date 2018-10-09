using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Obj
{

    protected enum ESTATE //폰의 FSM 상태
    {
        eNormal,
        eWalk,
    }

    private ESTATE eState;
    private float fSpeed;
    private float fLength;
    private Vector2 vTargetPos;

    protected float GetSpeed() { return fSpeed; }
    protected void SetSpeed(float fspeed) { fSpeed = fspeed; }

    protected ESTATE GetState() { return eState; }
    protected void SetState(ESTATE estate) { eState = estate; }

    protected float GetLength() { return fLength; }
    protected void SetLength(float flength) { fLength = flength; }

    protected Vector2 GetTargetPos() { return vTargetPos; }
    protected void SetTargetPos(Vector2 vPos) { vTargetPos = vPos; }

    void Awake()
    {
        fLength = 0.0f;
        eState = ESTATE.eNormal;
    }

    protected void FSM()
    {
        switch (eState)
        {
            case ESTATE.eNormal:

                break;
            case ESTATE.eWalk:
                {
                    Vector2 CurPos = this.transform.position;
                    float step = fSpeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(CurPos, vTargetPos, step);
                    fLength -= fSpeed * Time.deltaTime;

                    if (fLength <= 0.0f)
                    {
                        eState = ESTATE.eNormal;
                        base.ImgChange((int)eState);
                        fLength = 0.0f;
                        vTargetPos = this.transform.position;
                    }
                }
                break;
        }
    }
}
