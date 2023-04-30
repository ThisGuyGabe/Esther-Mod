using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace EstherMod.Content.Items.Weapons
{
	public class StellarRain : ModItem
	{
		public override void SetStaticDefaults() {

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;

			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 21;
			Item.knockBack = 3;

			Item.value = Item.buyPrice(gold: 5);
			Item.rare = ItemRarityID.Green;

			Item.shoot = Mod.Find<ModProjectile>("StellarRainProjectile").Type;
			Item.shootSpeed = 7.5f; 

		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f) {
				ceilingLimit = player.Center.Y - 200f;
			}
			for (int i = 0; i < 3; i++) {
				position = player.Center - new Vector2(Main.rand.NextFloat(201) * player.direction, 300f);
				position.Y -= 100 * i;
				position.X -= 100 * i;
				Vector2 heading = target - position;

				if (heading.Y < 0f) {
					heading.Y *= -1f;
				}

				if (heading.Y < 10f) {
					heading.Y = 10f;
				}

				heading.Normalize();
				heading *= velocity.Length();
				heading.Y += Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
			}

			return false;

		}
	}
}
