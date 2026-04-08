using BaseLib.Abstracts;
using BaseLib.Utils;
using Paladin.PaladinCode.Character;

namespace Paladin.PaladinCode.Potions;

[Pool(typeof(PaladinPotionPool))]
public abstract class PaladinPotion : CustomPotionModel;