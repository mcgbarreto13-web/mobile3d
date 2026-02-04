using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBaseSetup : ScriptableObject
{
    public ArtManager.ArtType artType;
    
   [Header ("Pieces")]
   public List<LevelPieceBase> levelPieceStart;
    public List<LevelPieceBase> levelPiece;
    public List<LevelPieceBase> levelPieceEnd;

    public int piecesStartNumber = 2;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;

}
