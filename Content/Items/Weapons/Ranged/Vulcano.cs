using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace EstherMod.Content.Items.Weapons.Ranged
{
    public class Vulcano : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Vulcano");
            // Tooltip.SetDefault("");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            //DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Polish), "Wulkan");
        }
        public override void SetDefaults()
        {
            Item.damage = 71;
            Item.crit = 10;
            Item.rare = ItemRarityID.LightRed;
            Item.width = 32;
            Item.height = 72;
            Item.useAnimation = 27;
            Item.useTime = 27;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 15f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = 1;
            Item.value = Item.sellPrice(gold: 25, silver: 67);
            Item.UseSound = SoundID.Item5;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
             if (type == ProjectileID.WoodenArrowFriendly) {
                type = Mod.Find<ModProjectile>("VulcanoProjectile").Type;
            }

            if (type == ProjectileID.FireArrow) {
                type = Mod.Find<ModProjectile>("VulcanoProjectile").Type;
            }

            if (type == ProjectileID.FrostburnArrow) {
                type = Mod.Find<ModProjectile>("VulcanoProjectile").Type; 
            }

            if (type == ProjectileID.HellfireArrow) {
                type = Mod.Find<ModProjectile>("VulcanoProjectile").Type;
            }

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f) {
                ceilingLimit = player.Center.Y - 200f;
            }
            // Loop these functions 12 times.
            for (int i = 0; i < 12; i++) {
                position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
                position.Y -= 200 * i;
                Vector2 heading = target - position;

                if (heading.Y < 0f) {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f) {
                    heading.Y = 20f;
                }

                heading.Normalize();
                heading *= velocity.Length();
                heading.Y += Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
            }

            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddIngredient(Mod.Find<ModItem>("ForgedFury").Type, 1);
            recipe.AddIngredient(ItemID.DaedalusStormbow, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
