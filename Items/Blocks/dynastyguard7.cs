using Terraria.ID;
using Terraria.ModLoader;

namespace WackyNPCs.Items.Blocks
{
    public class dynastyguard7 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dynasty Guard 7");
            Tooltip.SetDefault("A stationary guard");
        }


        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 58;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType("dynastyguard7");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(mod,"guardcaptainsdesk");
            recipe.AddIngredient(mod,"hireaguard");
            recipe.AddIngredient(ItemID.DynastyWood,5);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}