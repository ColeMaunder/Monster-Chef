using Unity.VisualScripting;
using UnityEngine;

public class EnemyLocalData : MonoBehaviour
{
    public int enemyIndex = 0;
    private bool canMove = true;
    private bool canLook = true;
    private bool IsAttacking = false;
    private bool vulnrable = true;
    public int getEnemyIndex()
    {
        return enemyIndex;
    }
    public bool getVulnrable(){
        return vulnrable;
    }
    public void setVulnrable(bool state){
        vulnrable = state;
    }
    public void setFullVulnrable(bool state)
    {
        vulnrable = state;
        Physics2D.IgnoreCollision(transform.gameObject.GetComponent<Collider2D>(), GameObject.FindWithTag("PlayerBody").GetComponent<Collider2D>(), !state);
    }
    public bool getCanMove()
    {
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
