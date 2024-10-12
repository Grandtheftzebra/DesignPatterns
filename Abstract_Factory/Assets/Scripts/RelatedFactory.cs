using UnityEngine;

public class RelatedFactory
{
   public interface IAbstractFactory
   {
      public IForge CreateForgeSystem();
      public IMerchant CreateMerchantSystem();
   }
   public interface IForge
   {
      public void Craft();
      public void Disassemble();
   }

   public interface IMerchant
   {
      public void Buy();
      public void Sell();
   }
   
   public class BlacksmithFactory : IAbstractFactory
   {
      public IForge CreateForgeSystem() => new BlacksmithForge();

      public IMerchant CreateMerchantSystem() => new BlacksmithMerchant();
   }
   
   public class FusionFactory : IAbstractFactory
   {
      public IForge CreateForgeSystem() => new FusionForge();

      public IMerchant CreateMerchantSystem() => new FusionMerchant();
   }

   public class BlacksmithForge : IForge
   {
      public void Craft()
      {
         Debug.Log("Crafting item with provided raw materials.");
      }

      public void Disassemble()
      {
         Debug.Log("Disassemble item into raw materials.");
      }
   }

   public class FusionForge : IForge
   {
      public void Craft()
      {
         Debug.Log("Fuse items together...");
      }

      public void Disassemble()
      {
         Debug.Log("Fused item was broken into raw materials");
      }
   }

   public class BlacksmithMerchant : IMerchant
   {
      public void Buy()
      {
         Debug.Log("Come look at my wares. Only Gold accepted");
      }

      public void Sell()
      {
         Debug.Log("Let me have a look at those sweet weapons of yours. Do you accept gold?");
      }
   }
   
   public class FusionMerchant : IMerchant
   {
      public void Buy()
      {
         Debug.Log("Come look at my wares. Only Fusion Coins accepted");
      }

      public void Sell()
      {
         Debug.Log("Let me have a look at those sweet weapons of yours. Do you accept Fusion Coins?");
      }
   }
}
