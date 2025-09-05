using System;
using UnityEngine;

public class Trap_Attack_Rotate : MonoBehaviour
{
    public enum Chess
    {
        ChessTypeKing,
        ChessTypeQueen,
    }
    [SerializeField]
    private Chess chessType;
    
    [SerializeField]
    private Trap_Chess_Attack tChess;

    [SerializeField] 
    private GameObject tChess2;
    
    void Start()
    {
        if (chessType == Chess.ChessTypeKing)
        {
            tChess2 = GameObject.Find("Black King");
            tChess = tChess2.GetComponent<Trap_Chess_Attack>();
        }

        if (chessType == Chess.ChessTypeQueen)
        {
            tChess2 = GameObject.Find("Black Queen");
            tChess = tChess2.GetComponent<Trap_Chess_Attack>();
        }
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tChess.ChessAttack();
        }
    }
}
