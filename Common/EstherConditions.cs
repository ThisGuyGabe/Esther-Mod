﻿using System;
using EstherMod.Core.Quests;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EstherMod.Common.Conditions;

public static class EstherConditions {
	public static Condition QuestCompleted<T>(Func<Player> playerGetter) where T : ModQuest {
		return new Condition(Language.GetText("Mods.EstherMod.Conditions.QuestCompletion").Format(ModContent.GetInstance<T>().DisplayName), () => ModContent.GetInstance<T>().IsCompleted(playerGetter()));
	}
}
