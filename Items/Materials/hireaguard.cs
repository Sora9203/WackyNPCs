using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;

namespace WackyNPCs.Items.Materials{

    public class hireaguard : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hire A Guard");
			Tooltip.SetDefault("A neatly written document");
		}
        public override void SetDefaults()
        {
            item.maxStack = 999;                 //this is where you set the max stack of item
            item.consumable = false;           //this make that the item is consumable when used
            item.width = 14;
            item.height = 28;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 2;
			item.expert = false;
			item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldCoin, 3);
            recipe.AddTile(mod, "guardcaptainsdesk");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		
    }
}