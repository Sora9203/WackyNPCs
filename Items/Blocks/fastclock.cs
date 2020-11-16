using Terraria.ID;
using Terraria.ModLoader;

namespace WackyNPCs.Items.Blocks
{
    public class fastclock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fast Clock");
            Tooltip.SetDefault("A decoration fast clock");
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
            item.createTile = mod.TileType("fastclock");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ItemID.SlimeBlock, 5);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}