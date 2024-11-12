using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridPiece : MonoBehaviour
{
    [SerializeField] protected MeshRenderer mesh;
    public Vector2Int pos;
    public bool isWalkable;
    public bool isEmpty;
    public GridPieceType pieceType;
    protected Color defaultColor;
    protected GridEntity currentGridEntity;

    public void ChangeColor(Color color, bool isDefaultColor)
    {
        mesh.material.color = color;
        if(isDefaultColor) defaultColor = color;
    }

    public void ResetColor()
    {
        if(defaultColor == null)
        {
            print("Default collor no ha sido seteado");
            return;
        }
        mesh.material.color = defaultColor;
    }

    //Acion que realiza la pieza si una entidad entra en ella DEBE SER LLAMADA
    public virtual void OnEntityEnter(GridEntity gridEntity)
    {
        currentGridEntity = gridEntity;
    }

    //Acion que realiza la pieza si una entidad se encuentra en ella en ella DEBE SER LLAMADA
    public abstract void OnEntityStay();


    //Acion que realiza la pieza si una entidad sale de ella DEBE SER LLAMADA
    public abstract void OnEntityExit();

}
