using System;
using UnityEngine;
using static DependentFactory;
using static RelatedFactory;

public class Client
{
   private IAbstractFactory _factory;
   private AbstractRecipeFactory _absFactory;

   public Client(IAbstractFactory factory, AbstractRecipeFactory absFactory)
   {
      _factory = factory;
      _absFactory = absFactory;
   } 

   public void RunFactoryProcesses()
   {
      IForge forge = _factory.CreateForgeSystem();
      IMerchant merchant = _factory.CreateMerchantSystem();

      Item item = _absFactory.GetItem();
      UpgradeMaterial material = _absFactory.GetUpgradeMaterial();
      
      forge.Craft();
      merchant.Buy();
      
      item.Upgrade(material);
   }
}
