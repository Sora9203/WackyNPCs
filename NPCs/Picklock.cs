using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Microsoft.Xna.Framework;

namespace WackyNPCs.NPCs
{
	[AutoloadHead]
	public class Picklock : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "WackyNPCs/NPCs/Picklock";
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "Picklock";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 1;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.ArmsDealer;
		}


		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == 346)
						{
							return true;
						}
					}
				}
			}
			return false;
		}


		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(7))
			{
				case 0:
					return "Mathieu";
				case 1:
					return "Adalberto";
				case 2:
					return "Pascal";
				case 3:
					return "Igor";
				case 4:
					return "Brandon";
				case 5:
					return "Giordano";
				default:
					return "Giovanni";
			}
		}

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
			int merchant = NPC.FindFirstNPC(NPCID.Merchant);
			if (merchant >= 0 && Main.rand.NextBool(8))
			{
				return "" + Main.npc[merchant].GivenName + "calls that a safe? That's what I call a toy!";
			}
			 if (Main.rand.Next(7) == 0 && Main.hardMode)
            {
                return "Who in their right minds would try to pet a chest?";
				return "I recently found that there is a way to make keys out of souls of monsters, but I don' like how they look. Be careful where you put them, that's all I'm saying.";

			}
			switch (Main.rand.Next(6))
			{
				case 0:
					return "Have you ever stopped to consider what you will do with this purple key once you return from hell? Please don't sell it back to me.";
				case 1:
					return "This is not a briefcase. This is a highly efficient, small tool carrying device.";
				case 2:
					return "Wait... if safes can be accessed from Anywhere, does that mean I can pick trans-dimensional locks? Go me!";
				case 3:	
					return "Closed Chest you want me to open? Hmm... No. ...Wait... how much?";
				case 4:
					return "I wonder who designed these gold keys... they're way too fragile, but if I tinker a bit with them to be stronger, they don't fit into the lock anymore...";
				default:
					return "You saw nothin kid.";
			}
		}

		

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}
		public override void SetupShop(Chest shop, ref int nextSlot)
		{
				shop.item[nextSlot].SetDefaults(ItemID.GoldenKey);
				shop.item[nextSlot].value = 20000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ShadowKey);
				shop.item[nextSlot].value = 150000;
				nextSlot++;
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(ItemID.LightKey);
				shop.item[nextSlot].value = 250000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.NightKey);
				shop.item[nextSlot].value = 250000;
				nextSlot++;
			}
			if (NPC.downedPlantBoss)
			{
				shop.item[nextSlot].SetDefaults(ItemID.HallowedKey);
				shop.item[nextSlot].value = 5000000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.JungleKey);
				shop.item[nextSlot].value = 5000000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.CorruptionKey);
				shop.item[nextSlot].value = 5000000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.CrimsonKey);
				shop.item[nextSlot].value = 5000000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.FrozenKey);
				shop.item[nextSlot].value = 5000000;
				nextSlot++;
			}
		}


		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.Bullet;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
		
		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
		{
			scale = 0.5f;
			item = 164;
			closeness = 2;
		}	
	}
}