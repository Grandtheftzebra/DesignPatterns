using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SupportAlly
{
   public string AllyType;

   public List<GameObject> components = new();

   public GameObject Parent;

   public SupportAlly(string newBuiltAlly)
   {
      AllyType = newBuiltAlly;
      Parent = new GameObject(newBuiltAlly);
   } 

   public void AddComponent(GameObject go)
   {
      go.transform.SetParent(Parent.transform);
      components.Add(go);
      Debug.Log($"Component {go.name} has been added.");
   }

   public string GetBluePrint()
   {
      if (components.Count == 0)
      {
         return ("No components listed, use the Director Class");
      }

      StringBuilder blueprintLog = new StringBuilder();
      blueprintLog.Append($"Support type: {AllyType}\n\n");

      foreach (var component in components)
      {
         blueprintLog.Append( $"{component.name} ---- installed\n");
      }

      return blueprintLog.ToString();
   }
}
