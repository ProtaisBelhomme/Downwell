using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Overview_Heritage : MonoBehaviour
{
    void Start()
    {
        // Inheritance Essential
        GluantFromDragonQuest baseClass = new GluantFromDragonQuest();
        baseClass.Moving(); // BaseClass Method
        //derived class is also base class but with a different behavior
        baseClass = new RoiGluant();
        baseClass.Moving(); // DerivedClass Method

        // Interface
        IDemoInteractable interactableObj = new LeGrosButtonRouge();
        // i know that the object as the method InterfaceMethod because it implements the interface IMyInterface
        interactableObj.RandomInteraction();

        // Abstract Class
        FireBallSpell concreteClass = new FireBallSpell();
        concreteClass.Cast(); 
    }

}

#region Inheritance Essential
public class GluantFromDragonQuest
{
    // Virtual Method (can be overridden in a subclass)
    public virtual void Moving()
    {
        Debug.Log(" petit gluant se déplace");
    }
}
public class RoiGluant : GluantFromDragonQuest
{
    // Override Method (overrides the base class method)
    public override void Moving()
    {
        Debug.Log("le roi gluant se déplace");
    }
}
public class Médigluant : GluantFromDragonQuest
{
    // Override Method (overrides the base class method)
    public override void Moving()
    {
        Debug.Log("le médi gluant se déplace");
    }
}


public interface IDemoInteractable
{
    // Interface Method (must be implemented by a class)
    void RandomInteraction();
}
public class LeGrosButtonRouge : IDemoInteractable
{
    public void RandomInteraction()
    {
        Debug.Log("tu viens de déclencher une explosion nucléaire");
    }
}
public class LevierEtrange : IDemoInteractable
{
    public void RandomInteraction()
    {
        Debug.Log("une trappe s'ouvre sous tes pieds");
    }
}

public abstract class MagicSpell
{
    // Abstract Method (must be implemented by a subclass)
    public abstract void Cast();
}
public class FireBallSpell : MagicSpell
{
    // Implement Abstract Method
    public override void Cast()
    {
        Debug.Log("FireBallSpell Casted");
    }
}
public class SpaceTimeSpell : MagicSpell
{
    // Implement Abstract Method
    public override void Cast()
    {
        Debug.Log("IceSpell Casted");
    }
}
#endregion