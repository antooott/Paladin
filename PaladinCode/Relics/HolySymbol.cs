using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Rooms;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Relics;
using Paladin.PaladinCode.Powers;

#nullable enable
namespace Paladin.PaladinCode.Relics;

public sealed class HolySymbol : PaladinRelic
{
    public override RelicRarity Rarity => RelicRarity.Starter;

    public override async Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        HolySymbol holySymbol = this;
        if (player != holySymbol.Owner)
            return;
        //await CommonActions.Apply<SpellSlotPower>(holySymbol.Owner.Creature, holySymbol.DynamicVars["SpellSlotPower"]);
        SpellSlotPower spellSlotPower = await PowerCmd.Apply<SpellSlotPower>(player.Creature, 2m, player.Creature, null);
        holySymbol.Flash();
    }

    public override RelicModel GetUpgradeReplacement()
    {
        return ModelDb.Relic<BurningBlood>();
    }
}