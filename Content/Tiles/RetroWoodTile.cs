using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using EstherMod.Content.Items.Placeable;

namespace EstherMod.Content.Tiles
{
    public class RetroWoodTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = false;
            HitSound = SoundID.Tink;
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Retro Wood");
            AddMapEntry(new Color(182, 205, 177), name);
            ItemDrop = ItemType<RetroWood>();
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.5f;
            g = 0.5f;
            b = 0.5f;
        }
    }
}