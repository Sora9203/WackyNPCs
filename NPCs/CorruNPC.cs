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
    public class Corru : ModNPC
    {
        public override string Texture
        {
            get
            {
                return "WackyNPCs/NPCs/Corru";
            }
        }

        public override bool Autoload(ref string name)
        {
            name = "CorruptionFangirl";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            // DisplayName.SetDefault("Example Person");
            Main.npcFrameCount[npc.type] = 23;
            NPCID.Sets.ExtraFramesCount[npc.type] = 7;
            NPCID.Sets.AttackFrameCount[npc.type] = 2;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 2;
            NPCID.Sets.AttackTime[npc.type] = 30;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.MagicAuraColor[npc.type] = Color.Purple;
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
            animationType = NPCID.Wizard;
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
                        if (player.inventory[j].type == 836)
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
                    return "Violet";
                case 1:
                    return "Indigo";
                case 2:
                    return "Hyacinth";
                case 3:
                    return "Iolanthe";
                case 4:
                    return "Lavender";
                case 5:
                    return "Mauve";      
                default:
                    return "Yolanda";
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
            int Dryad = NPC.FindFirstNPC(NPCID.Dryad);
            if (Dryad >= 0 && Main.rand.Next(14) == 0)
            {
                return "… " + Main.npc[Dryad].GivenName + " just doesn’t understands it… don’t listen to her, don’t purify the corruption… okay…?";
            }
            if (Main.rand.Next(13) == 0 && Main.bloodMoon)
            {
                return "…Just leave me alone now… just let me pretend to be dead like the corruption…";
            }
            if (Main.rand.Next(12) == 0 && Main.hardMode)
            {
                return "…Hey, hey… If you happen to get a Clentaminator, you know... buy purple solution… Kinda… Lots of it…!";
            }
            if (Main.rand.Next(11) == 0 && Main.hardMode)
            {
                return "…Slimes that fly and slimes that bursts into smaller slimes… that’s kinda wicked cute, isn’t it…?";
            }
            if (Main.rand.Next(10) == 0 && Main.hardMode)
            {
                return "…There is a thing called cursed flames. Not even water can put it out, it’s very strong. And you can craft lots of things from it. Corruption is kinda wicked cool, isn’t it…?";
            }
             if (Main.rand.Next(9) == 0 && Main.hardMode)
            {
                return "…Look, it’s a corruptor plushie… It’s kinda… wicked cute, isn’t it…?";
            }
            if (Main.rand.Next(8) == 0 && ModLoader.GetMod("TerrariaOverhaul") != null)
            {
                return "…Did you visit the Corruption in the autumn when it’s blooming? Eyes… eyes everywhere. Everything watches you. That kinda makes me wanna do something wicked too while I’m being watched… watched by everything… hehe…";
            }
            switch (Main.rand.Next(7))
            {
                case 0:
                    return "…The Corruption… the lightless chasms... rotting and decaying deadlands, with worms feeding on it. Isn’t that kinda amazing…?";
                case 1:
                    return "…Don’t eat rotten chunks, they taste awful… Why do I know? Well…";
                case 2:
                    return "… … … Shh… I’m pretending to be dead… like the corruption…";
                case 3:
                    return "…Eater of Souls are kinda weak, but they attack in swarms… that’s a bit cool, isn’t it…?";
                case 4:
                    return "…You know Devourers? They’re rare to show up… but they’re kinda wicked cool…";
                case 5:
                    return "…If you look around deeper in the chasms, you might find the large worm that made those… it’s really nasty. I kinda wanna hug it…";
                case 6:
                    return "…Hug an ebonwood tree. Today too. They need more love. Because they deserve it…";
                default:
                    return "…Deep in the chasms, there are those shadow orbs. They have some wicked evil power. Isn’t that kinda cool…? Makes me wanna keep one as a pet…";
            }
        }

        /* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.Next(4) == 0)
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

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
            shop.item[nextSlot].SetDefaults(61);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(370);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(3274);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(3276);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(833);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(619);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            if (NPC.downedQueenBee)
            {
                shop.item[nextSlot].SetDefaults(942);
                nextSlot++;
            }
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(67);
            nextSlot++;
            }
            if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(423);
                shop.item[nextSlot].value = 1500;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(782);
                nextSlot++;
            }
            shop.item[nextSlot].SetDefaults(59);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(68);
            shop.item[nextSlot].value = 600;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(69);
            shop.item[nextSlot].value = 1000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(60);
            shop.item[nextSlot].value = 300;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(1488);
            nextSlot++;
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(3217);
                nextSlot++;
            }
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(70);
                shop.item[nextSlot].value = 12500;
                nextSlot++;
            }
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(2318);
                shop.item[nextSlot].value = 10000;
                nextSlot++;
            }
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(2330);
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(3203);
                shop.item[nextSlot].value = 120000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(56);
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(86);
                shop.item[nextSlot].value = 5000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(96);
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(162);
                shop.item[nextSlot].value = 60000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(64);
                shop.item[nextSlot].value = 60000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(111);
                shop.item[nextSlot].value = 100000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(115);
                shop.item[nextSlot].value = 150000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(994);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(3224);
                shop.item[nextSlot].value = 1000000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(1529);
                shop.item[nextSlot].value = 10000;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(522);
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(3210);
                shop.item[nextSlot].value = 350000;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(3008);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(3023);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(3012);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(3014);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(3015);
                shop.item[nextSlot].value = 500000;
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
            projType = ProjectileID.CursedFlameFriendly;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}