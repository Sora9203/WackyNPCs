using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace WackyNPCs.NPCs
{
    [AutoloadHead]
    public class Professor : ModNPC
    {
        public override string Texture
        {
            get
            {
                return "WackyNPCs/NPCs/Professor";
            }
        }

        public override bool Autoload(ref string name)
        {
            name = "Professor";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            // DisplayName.SetDefault("Example Person");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
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
                        if (player.inventory[j].type == 3347)
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
                    return "Dr. Quicksand";
                case 1:
                    return "Professor Porter";
                case 2:
                    return "Dr. Goof";
                case 3:
                    return "Prof. Oaks";
                case 4:
                    return "Dr. Ruin";
                case 5:
                    return "Dr Klutz";      
                default:
                    return "Dr. Dingbat";
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
            if (Main.rand.Next(12) == 0 && Main.LocalPlayer.ZoneSnow)
            {
                return "Brrr... turn on the heater please. What? What you mean by you don't have one?";
            }
            if (Main.rand.Next(11) == 0 && Main.LocalPlayer.ZoneDesert)
            {
                return "Could you turn on the air conditioning? Huh? What do you mean you don't have one...?";
            }
            if (Main.rand.Next(10) == 0 && Main.LocalPlayer.ZoneDesert)
            {
                return "Hmmm... I think there was the pyramid of Amenhotep XXIII. somewhere around here... or was it not here...?";
            }
            if (Main.rand.Next(9) == 0 && Main.LocalPlayer.ZoneDesert)
            {
                return "...And if I would extract the ancient blood from this mosquito in the amber, I could probably... Oh, hi!";
            }
            if (Main.rand.Next(8) == 0 && Main.LocalPlayer.ZoneDesert)
            {
                return "Wow! It's the fossilized scaphoid bone of a Calliorhinotitan! Quick, help me digging it up! What? You're busy...?";
            }
            if (Main.rand.Next(7) == 0 && Main.LocalPlayer.ZoneJungle)
            {
                return "...And the humidity is 223.5%. ...What? 223.5%? This hygrometer must be broken... Oh, why hello there!";
            }
            if (Main.rand.Next(6) == 0 && Main.LocalPlayer.ZoneJungle)
            {
                return "Did you know there's an ancient temple here somewhere deep in this jungle? I remember I seen it the other day, but... where was it again?";
            }
            if (Main.rand.Next(5) == 0 && Main.LocalPlayer.ZoneJungle)
            {
                return "Shh, keep it quiet, there are some fascinating insects in these bushes, don't scare them away...";
            }
			if (Main.rand.Next(4) == 0 && Main.bloodMoon)
            {
                return "The fruitcake? Ah, I found it when organised my stuff at home the other time. It's probably from Christmas last year or the year before. I would advise against eating it... but looks like it's good to hammer nails or ward off monsters...";
            }
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Yeah, yeah, stop nagging me with lunch now, I'm in the middle of field research...! Huh?! You're not my wife...";
                case 1:
                    return "Yes, this insect has exactly 3 543 legs and... Hey! Watch where you're stepping!";
                case 3:
                    return "What? You want to buy something to support my researches? Why, thank you. ...Now... Where did I put those bugs again...?";
                default:
                    return "Yes, yes, I'll catch you now you fascinating little...! What?! Ah! Rats! You scared it away!";
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
            shop.item[nextSlot].SetDefaults(ItemID.MonarchButterfly);
            shop.item[nextSlot].value = 1000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.SulphurButterfly);
            shop.item[nextSlot].value = 1500;
            nextSlot++;
			if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.ZebraSwallowtailButterfly);
                shop.item[nextSlot].value = 2000;
                nextSlot++;
            }
			if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.UlyssesButterfly);
                shop.item[nextSlot].value = 2500;
                nextSlot++;
            }
			if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(ItemID.JuliaButterfly);
                shop.item[nextSlot].value = 3500;
                nextSlot++;
            }
			if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(ItemID.RedAdmiralButterfly);
                shop.item[nextSlot].value = 4500;
                nextSlot++;
            }
			if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PurpleEmperorButterfly);
                shop.item[nextSlot].value = 8000;
                nextSlot++;
            }
			if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.TreeNymphButterfly);
                shop.item[nextSlot].value = 20000;
                nextSlot++;
            }
			if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.GoldButterfly);
                shop.item[nextSlot].value = 150000;
                nextSlot++;
            }
			if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Firefly);
                shop.item[nextSlot].value = 1000;
                nextSlot++;
            }
			if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Worm);
                shop.item[nextSlot].value = 1500;
                nextSlot++;
            }
			if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.GoldWorm);
                shop.item[nextSlot].value = 200000;
                nextSlot++;
            }
            shop.item[nextSlot].SetDefaults(ItemID.Snail);
            shop.item[nextSlot].value = 2500;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Grasshopper);
            shop.item[nextSlot].value = 1500;
            nextSlot++;
			if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.GoldGrasshopper);
                shop.item[nextSlot].value = 200000;
                nextSlot++;
            }
			shop.item[nextSlot].SetDefaults(ItemID.WoodenCrate);
            shop.item[nextSlot].value = 500000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.IronCrate);
            shop.item[nextSlot].value = 750000;
            nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.GoldenCrate);
            shop.item[nextSlot].value = 1000000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Mouse);
            shop.item[nextSlot].value = 2500;
            nextSlot++;
			if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.GoldMouse);
                shop.item[nextSlot].value = 200000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneDesert)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Scorpion);
                shop.item[nextSlot].value = 2000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneDesert && NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(ItemID.BlackScorpion);
                shop.item[nextSlot].value = 2500;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneDesert)
            {
                shop.item[nextSlot].SetDefaults(ItemID.DesertFossil);
                shop.item[nextSlot].value = 7500;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneDesert && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.AncientCloth);
                shop.item[nextSlot].value = 10000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneDesert && NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(ItemID.DjinnLamp);
                shop.item[nextSlot].value = 150000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneJungle)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Grubby);
                shop.item[nextSlot].value = 2500;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneJungle && NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Sluggy);
                shop.item[nextSlot].value = 5000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneJungle && NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Buggy);
                shop.item[nextSlot].value = 10000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneJungle && NPC.downedQueenBee)
            {
                shop.item[nextSlot].SetDefaults(ItemID.JungleFishingCrate);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneJungle && NPC.downedQueenBee)
            {
                shop.item[nextSlot].SetDefaults(ItemID.JungleSpores);
                shop.item[nextSlot].value = 10000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneJungle && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.HerculesBeetle);
                shop.item[nextSlot].value = 400000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneJungle && NPC.downedQueenBee)
            {
                shop.item[nextSlot].SetDefaults(ItemID.HoneyedGoggles);
                shop.item[nextSlot].value = 1000000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneHoly)
            {
                shop.item[nextSlot].SetDefaults(ItemID.LightningBug);
                shop.item[nextSlot].value = 2500;
                nextSlot++;
            }
			if (NPC.downedBoss3)
            {
			shop.item[nextSlot].SetDefaults(ItemID.GlowingSnail);
            shop.item[nextSlot].value = 100000;
            nextSlot++;
			}
			if (NPC.downedPlantBoss)
            {
			shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm);
            shop.item[nextSlot].value = 1000000;
            nextSlot++;
			}
			if (Main.LocalPlayer.ZoneBeach && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.BlueJellyfish);
                shop.item[nextSlot].value = 100000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneBeach && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.GreenJellyfish);
                shop.item[nextSlot].value = 100000;
                nextSlot++;
            }
			if (Main.LocalPlayer.ZoneBeach && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PinkJellyfish);
                shop.item[nextSlot].value = 100000;
                nextSlot++;
            }
			if (Main.bloodMoon)
            {
                shop.item[nextSlot].SetDefaults(ItemID.FruitcakeChakram);
                shop.item[nextSlot].value = 50000;
                nextSlot++;
            }
			if (NPC.downedMechBossAny)
			{
			shop.item[nextSlot].SetDefaults(ItemID.SpiderFang);
            shop.item[nextSlot].value = 10000;
			nextSlot++;
			}
			if (Main.hardMode)
			{
			shop.item[nextSlot].SetDefaults(ItemID.GoldenBugNet);
            shop.item[nextSlot].value = 2000000;
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
            projType = ProjectileID.FruitcakeChakram;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}