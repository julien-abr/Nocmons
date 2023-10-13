using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBearActions
{
    /*public virtual void ChestBtn(){return;}
    public virtual void HideEyes(){return;}
    public virtual void UnhideEyes(){return;}
    public virtual void HandBtn(){return;}
    public virtual void HeadBtn(){return;}*/
    void ChestBtn();
    void CanceledChestBtn();
    void HideLeftEye();
    void HideRightEye();
    void ShowLeftEye();
    void ShowRightEye();
    void HandBtn();
    void HeadBtn();
    void CamRotLeft();
    void CamRotRight();
    void CamRotMiddle();
}
