using UnityEngine;

public class EnemyLocalData : MonoBehaviour
{
    private bool canMove = true;
    private bool canLook = true;
    private bool IsAttacking = false;
    public bool getCanMove(){
        return canMove;
    }

    public void setCanMove(bool canMoveIn){
        canMove= canMoveIn;
    }

    public bool getCanLook(){
        return canLook;
    }

    public void setCanLook(bool canLookIn){
        canLook= canLookIn;
    }

    public bool getIsAttacking(){
        return IsAttacking;
    }

    public void setIsAttacking(bool isAttackingIn){
        IsAttacking= isAttackingIn;
    }
}
