using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.DataStructures;
using System.IO;
using Terraria.GameContent.Generation;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using System;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;



namespace EstherMod.Content.Tiles
{
    public class GalvanicOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 975;
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Galvanic Ore");
            AddMapEntry(new Color(205, 127, 50), name);
            DustType = 84;
            ItemDrop = ModContent.ItemType<Items.Placeable.GalvanicOre>();
            HitSound = SoundID.Tink;
            MinPick = 65;
        }
    }


    public class GalvanicOreTileSystem : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) {
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

			if (ShiniesIndex != -1) {

				tasks.Insert(ShiniesIndex + 1, new GalvanicOreTilePass("Galvanic  Ore", 237.4298f));
			}
		}
	}

	public class GalvanicOreTilePass : GenPass
	{
		public GalvanicOreTilePass(string name, float loadWeight) : base(name, loadWeight) {
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
		{
			
				progress.Message = "Galvanic Ore spreads throughout the world";

				for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
				{
					int x = WorldGen.genRand.Next(0, Main.maxTilesX);
					int y = WorldGen.genRand.Next((int)GenVars.rockLayer, Main.maxTilesY);
					WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(4, 8), ModContent.TileType<GalvanicOreTile>());

					WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 5), WorldGen.genRand.Next(3, 6), ModContent.TileType<GalvanicOreTile>());
				}

		}
	}
}
