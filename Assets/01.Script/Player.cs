using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pawn
{
    void Awake()
    {
		ImgLoad("Pawn/");
        ImgChange((int)GetState());
        SetObj(EOBJ.ePawn);
        SetSpeed(5.0f);
    }
	
	// Update is called once per frame
	void Update () {
        MouseEvent();
        FSM();
	}

    void MouseEvent() //마우스 클릭 처리
    {
        if (Input.GetMouseButton(0))
        { 
            Vector2 MousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 WorldPos = Vector2Round(Camera.main.ScreenToWorldPoint(MousePos));

            SetLength(Vector2.Distance(this.transform.position, WorldPos));
            if (this.transform.position.x <= WorldPos.x && IsDirection() || this.transform.position.x > WorldPos.x && !IsDirection())
            {
                this.transform.localScale = Flip(this.transform.localScale);
            }
            SetTargetPos(WorldPos);
            SetState(ESTATE.eWalk);
            ImgChange((int)GetState());
        }
    }
}
