using Terraria.ModLoader;
using EstherMod.Content.Tiles;
using Terraria.ID;
using Terraria;
using EstherMod.Core;

namespace EstherMod.Content.Items.Placeables;

public sealed class RetroWood : BaseItem {
	public override void SetStaticDefaults() {
		Item.ResearchUnlockCount = 100;
	}

	public override void SetDefaults() {
		Item.DefaultToPlaceableTile(ModContent.TileType<RetroWoodTile>());
	}

	public override void AddRecipes() {
		CreateRecipe()
			.AddIngredient<PixilWood>()
			.AddTile(TileID.DemonAltar)
			.Register();
	}
}