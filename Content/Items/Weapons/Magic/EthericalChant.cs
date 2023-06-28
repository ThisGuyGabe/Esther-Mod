﻿using EstherMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EstherMod.Content.Items.Weapons.Magic
{
    public class EthericalChant : ModItem
    {
        public override void SetDefaults()
        {
            Item.mana = 3;
            Item.damage = 14;
            Item.DamageType = DamageClass.Magic;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 30;
            Item.height = 36;
            Item.UseSound = SoundID.Item8;
            Item.useAnimation = 26;
            Item.useTime = 26;
            Item.rare = ItemRarityID.Blue;
            Item.noMelee = true;
            Item.value = Item.sellPrice(gold: 1, silver: 30, copper: 10);
            Item.crit = 10;
            Item.shoot = ModContent.ProjectileType<ChantSpark>();
            Item.shootSpeed = 7f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < Main.rand.Next(3, 7); i++)
            {
                // Rotate the velocity randomly by 10 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false;
        }
    }
}
