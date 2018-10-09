using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pawn
{
    void Awake()
    {
		base.ImgLoad("Pawn/");
        base.ImgChange((int)base.GetState());
        base.SetObj(Obj.EOBJ.ePawn);
        base.SetSpeed(5.0f);
    }
	
	// Update is called once per frame
	void Update () {
        MouseEvent();
        base.FSM();
	}

    void MouseEvent() //마우스 클릭 처리
    {
        if (Input.GetMouseButton(0))
        { 
            Vector2 MousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 WorldPos = base.Vector2Round(Camera.main.ScreenToWorldPoint(MousePos));


            SetLength(Vector2.Distance(this.transform.position, WorldPos));
            if (this.transform.position.x <= WorldPos.x && base.IsDirection() || this.transform.position.x > WorldPos.x && !base.IsDirection())
            {
                this.transform.localScale = base.Flip(this.transform.localScale);
            }
            base.SetTargetPos(WorldPos);
            base.SetState(Pawn.ESTATE.eWalk);
            base.ImgChange((int)base.GetState());
        }
    }
}
