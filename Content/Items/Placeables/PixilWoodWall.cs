using EstherMod.Content.Walls;
using EstherMod.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EstherMod.Content.Items.Placeables;

public sealed class PixilWoodWall : BaseItem {
	public override void SetStaticDefaults() {
		Item.ResearchUnlockCount = 400;
	}

	public override void SetDefaults() {
		Item.DefaultToPlaceableWall(ModContent.WallType<PixilWoodWallTile>());
	}

	public override void AddRecipes() {
		CreateRecipe(4)
			.AddIngredient<PixilWood>()
			.AddTile(TileID.WorkBenches)
			.Register();
	}
}
