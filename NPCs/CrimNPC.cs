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
    public class Crim : ModNPC
    {
        public override string Texture
        {
            get
            {
                return "WackyNPCs/NPCs/Crim";
            }
        }

        public override bool Autoload(ref string name)
        {
            name = "CrimsonFangirl";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            // DisplayName.SetDefault("Example Person");
            Main.npcFrameCount[npc.type] = 23;
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
            animationType = NPCID.Mechanic;
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
                        if (player.inventory[j].type == 61)
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
                    return "Scarlet";
                case 1:
                    return "Carmine";
                case 2:
                    return "Cerise";
                case 3:
                    return "Flann";
                case 4:
                    return "Flannery";
                case 5:
                    return "Garnet";
                default:
                    return "Rose";
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
            if (Dryad >= 0 && Main.rand.Next(13) == 0)
            {
                return "" + Main.npc[Dryad].GivenName + " just doesn’t understands it… don’t listen to her, don’t purify the crimson… okay, okay!? Absolutely never purify it!";
            }
            if (Main.rand.Next(12) == 0 && Main.bloodMoon)
            {
                return "Leave me alone now, okay?!";
            }
            if (Main.rand.Next(11) == 0 && Main.hardMode)
            {
                return "If you happen to get a Clentaminator, buy red solution… Looooooots of red solution…! Yes! You could turn even more area into crimson! I’m shivering with excitement just thinking about it!";
            }
            if (Main.rand.Next(10) == 0 && Main.hardMode)
            {
                return "Do you wanna see my ichor sticker collection? No…? Okay…";
            }
            if (Main.rand.Next(9) == 0 && Main.hardMode)
            {
                return "Floaty gross can pass through walls. That’s real cool isn’t it? And some of them carry vitamins and meat grinders and stuff too. That’s so cool. See? They know that a healthy diet is important and… ah, you want to buy something?";
            }
            if (Main.rand.Next(8) == 0 && Main.hardMode)
            {
                return "Do you know about ichor? It’s the blood of gods. It’s a really-really potent material. Spell tomes, bullets, arrows, and all sorts of other stuff, ichor is great!";
            }
            if (Main.rand.Next(7) == 0 && ModLoader.GetMod("TerrariaOverhaul") != null)
            {
                return "Have you ever visited the crimson in the autumn when it’s blooming? It’s incredibly cool, the ground is full of flesh things, the shadewood trees are bleeding, and everything is full of life! You might even meet the Cerebral Mastermind!";
            }
            switch (Main.rand.Next(6))
            {
                case 0:
                    return "The Crimson. It’s alive, so alive! rich, verdant crimson vegetation with adorable little eyeballs and crimtane thorns and crimson vines and all sorts of other stuff growing in it, shadewood trees that grow flesh among the leaves, the chasms, and, and face monsters, and blood crawlers, and crimera and, and…, sorry, you wanted to buy something?";
                case 1:
                    return "Graaaah! Face monsters! They’re so cute, I wanna hug them! And crimera too, and blood crawlers too! Awww, I wanna hug them all! All the crimson creatures!!!";
                case 2:
                    return "While traveling, I stumbled upon a restaurant somewhere, the Crimson Kitchen. Their motto is “Taste the crimson!” And the menu is full of crimson stuff, like batter fried blood crawler legs, and roasted crimera and… the best thing is, the barkeeper is a facemonster! It’s just too cool and… the furniture is made of shadewood and… ah, you wanted to buy something?";
                case 3:
                    return "Did you know? There’s an insect named crimket. It’s like a cricket, but it’s crimson. They have vertebras and stuff too, like any crimson creatures. It’s really cool! If you listen to the little sounds of the Crimson, you will hear their chirr for sure.";
                case 4:
                    return "It’s just visceral malignity, the crimson isn’t actually evil. It’s just a natural, visceral desire of self-preservation. At the cost of other’s blood and flesh. Like a predator! Isn’t that cool? And did you know, it’s not just flesh and hearts, there’s a brain too somewhere! Isn’t that the coolest thing ever?!";
                case 5:
                    return "Crimson hearts are so cute. Just looking at them makes my heart race too! I wanna hug them! I totally want one as a pet!";
                default:
                    return "Once I had seen someone purifying crimstone. It felt horrible. It’s like petrifying a living creature. Don’t do such, okay? Just make sure you have barriers to not let it spreading further than… aww, actually, you could just let it spreading. If this whole place would turn crimson, that would be something incredibly cool!";
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
            shop.item[nextSlot].SetDefaults(836);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(1246);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(3275);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(3277);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(835);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(911);
            shop.item[nextSlot].value = 10;
            nextSlot++;
            if (NPC.downedQueenBee)
            {
                shop.item[nextSlot].SetDefaults(943);
                nextSlot++;
            }
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(2886);
                nextSlot++;
            }
            if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(3477);
                shop.item[nextSlot].value = 1500;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(784);
                nextSlot++;
            }
            shop.item[nextSlot].SetDefaults(2171);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(1330);
            shop.item[nextSlot].value = 600;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(2887);
            shop.item[nextSlot].value = 300;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(1492);
            nextSlot++;
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(3218);
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(310);
                shop.item[nextSlot].value = 5000;
                nextSlot++;
            }
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(1331);
                shop.item[nextSlot].value = 13500;
                nextSlot++;
            }
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(2305);
                shop.item[nextSlot].value = 10000;
                nextSlot++;
            }
            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(2319);
                shop.item[nextSlot].value = 10000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(3204);
                shop.item[nextSlot].value = 120000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(880);
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(1329);
                shop.item[nextSlot].value = 6000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(800);
                shop.item[nextSlot].value = 100000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(802);
                shop.item[nextSlot].value = 60000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(1256);
                shop.item[nextSlot].value = 100000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(1290);
                shop.item[nextSlot].value = 100000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(3062);
                shop.item[nextSlot].value = 150000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(3060);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(3223);
                shop.item[nextSlot].value = 1000000;
                nextSlot++;
            }
            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(1530);
                shop.item[nextSlot].value = 10000;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(1332);
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(996);
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(2193);
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(3211);
                shop.item[nextSlot].value = 350000;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(3006);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(3007);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(3013);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(3016);
                shop.item[nextSlot].value = 500000;
                nextSlot++;
            }
            if (NPC.downedMechBossAny)
            {
                shop.item[nextSlot].SetDefaults(3020);
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
            projType = ProjectileID.IchorArrow;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}