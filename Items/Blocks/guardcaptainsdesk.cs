using Terraria.ID;
using Terraria.ModLoader;

namespace WackyNPCs.Items.Blocks
{
    public class guardcaptainsdesk : ModItem
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guard Captain's Desk");
			Tooltip.SetDefault("Used for hiring guards");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = mod.TileType("guardcaptainsdesk");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bar);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}