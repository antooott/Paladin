using BaseLib.Abstracts;
using BaseLib.Utils.NodeFactories;
using Paladin.PaladinCode.Extensions;
using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Relics;
using MegaCrit.Sts2.Core.Nodes.Vfx;
using Paladin.PaladinCode.Cards.Basic;
using Paladin.PaladinCode.Relics;

namespace Paladin.PaladinCode.Character;

public class Paladin : PlaceholderCharacterModel
{
    public const string CharacterId = "Paladin";

    public static readonly Color Color = new("#ffd700");

    public override Color NameColor => Color;
    public override CharacterGender Gender => CharacterGender.Neutral;
    public override int StartingHp => 70;

    public override IEnumerable<CardModel> StartingDeck =>
    [
        ModelDb.Card<StrikeIronclad>(),
        ModelDb.Card<StrikeIronclad>(),
        ModelDb.Card<StrikeIronclad>(),
        ModelDb.Card<StrikeIronclad>(),
        ModelDb.Card<DivineSmite>(),
        ModelDb.Card<DefendPaladin>(),
        ModelDb.Card<DefendPaladin>(),
        ModelDb.Card<DefendPaladin>(),
        ModelDb.Card<DefendPaladin>(),
        ModelDb.Card<DefendPaladin>(),
    ];

    public override IReadOnlyList<RelicModel> StartingRelics =>
    [
        ModelDb.Relic<HolySymbol>()
    ];

    public override CardPoolModel CardPool => ModelDb.CardPool<PaladinCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<PaladinRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<PaladinPotionPool>();

    /*  PlaceholderCharacterModel will utilize placeholder basegame assets for most of your character assets until you
        override all the other methods that define those assets.
        These are just some of the simplest assets, given some placeholders to differentiate your character with.
        You don't have to, but you're suggested to rename these images. */
    public override Control CustomIcon
    {
        get
        {
            var icon = NodeFactory<Control>.CreateFromResource(CustomIconTexturePath);
            icon.SetAnchorsAndOffsetsPreset(Control.LayoutPreset.FullRect);
            return icon;
        }
    }

    public override string CustomIconTexturePath => "character_icon_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectIconPath => "char_select_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectLockedIconPath => "char_select_char_name_locked.png".CharacterUiPath();
    public override string CustomMapMarkerPath => "map_marker_char_name.png".CharacterUiPath();
    
    //public override Color EnergyLabelOutlineColor => new Color("ffd700");

    public override Color DialogueColor => new Color("ffd700");

    public override VfxColor SpeechBubbleColor => VfxColor.Gold;

    public override Color MapDrawingColor => new Color("ffd700");

    public override Color RemoteTargetingLineColor => new Color("ffd700");

    public override Color RemoteTargetingLineOutline => new Color("ffd700");
}