using UnityEngine;
using System.Collections;

public class Bandit : MonoBehaviour {

    public Elements elementScript;
    GameObject firstBlock;


    private Animator            m_animator;
    private Rigidbody2D m_body2d;
    private Sensor_Bandit m_groundSensor;
  

    public int[] hand = { -2, 2 };
    //  -1:Fire, -2:Earth, 1:Water, 2:Air
    private bool isCombo=false;

    public KeyCode dominantHandKey = KeyCode.J;
    public KeyCode SecondaryHandKey = KeyCode.K;

  
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        
    }
	
	
	void Update () {

             firstBlock = Elements.blockInGame[0];
            if (Input.GetKeyDown(dominantHandKey))
            {
                Interaction(0);
            }
            if (Input.GetKeyDown(SecondaryHandKey))
            {
                Interaction(1);
            }

    }

    void Interaction(int key)
    {

        if (Mathf.Abs(hand[0]) - Mathf.Abs(hand[1]) == 0)
            OppositeInteraction(key);
        else
            NeighbourInteraction(key);

    }

    void OppositeInteraction(int key)
    {
        int block = TagIndex();

        if (-hand[key] == block)
        {
            DestroyBlockOfType(block);
        }
        else if( !CompareNumber(block,hand[key]) && !isCombo)
        {
            isCombo = true;
        }
        else if( CompareNumber(block, hand[key]) && isCombo)
        {
            DestroyBlockOfType(block);
            isCombo = false;
        }

    }

    void NeighbourInteraction(int key)
    {
        int block = TagIndex();

        if (-hand[key] == block)
        {
            DestroyBlockOfType(block);
        }
        else if (block != hand[key] && !isCombo)
        {
            isCombo = true;
        }
        else if (block == hand[key] && isCombo)
        {
            DestroyBlockOfType(block);
            isCombo = false;
        }

    }

    void DestroyBlockOfType(int tag)
    {
        string index = IndexTag(tag);
        if (firstBlock != null)
        {
            if (firstBlock.CompareTag(index))
            {
                Destroy(firstBlock);
                m_animator.SetTrigger("Attack");
                firstBlock = Elements.blockInGame[0];
            }
        }
    }

    private int TagIndex()
    {
        if (firstBlock.CompareTag("Fire"))
        {
            return -1;
        }
        if (firstBlock.CompareTag("Earth"))
        {
            return -2;
        }
        if (firstBlock.CompareTag("Water"))
        {
            return 1;
        }
        return 2;
    }

    private string IndexTag(int index)
    {
        if (index==-1)
        {
            return "Fire";
        }
        if (index==-2)
        {
            return "Earth";
        }
        if (index==1)
        {
            return "Water";
        }
        return "Air";
    }

    private bool CompareNumber(int x, int y)
    {
        if (x < 0 && y < 0)
            return true;
        else if (x > 0 && y > 0)
            return true;
        
        return false;
    }
}


