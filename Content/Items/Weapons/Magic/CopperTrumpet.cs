﻿using EstherMod.Common;
using EstherMod.Content.Projectiles;
using EstherMod.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EstherMod.Content.Items.Weapons.Magic;

public sealed class CopperTrumpet : BaseItem {
	public override void SetDefaults() {
		Item.width = 36;
		Item.height = 18;
		Item.rare = ItemRarityID.Blue;
		Item.value = Item.sellPrice(silver: 12);

		Item.damage = 5;
		Item.mana = 4;
		Item.DamageType = DamageClass.Magic;
		Item.knockBack = 1.5f;
		Item.useTime = 16;
		Item.useAnimation = 16;
		Item.autoReuse = true;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.UseSound = EstherSounds.Trumpet;
		Item.shoot = ModContent.ProjectileType<TrumpetThing>();
		Item.shootSpeed = 3.5f;
	}

	public override void AddRecipes() {
		CreateRecipe()
			.AddIngredient(ItemID.CopperBar, 4)
			.AddIngredient(ItemID.Lens, 2)
			.AddTile(TileID.Anvils)
			.Register();
	}
}