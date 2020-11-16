using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace WackyNPCs.NPCs
{
    [AutoloadHead]
    public class ScamArtist : ModNPC
    {
        public override string Texture
        {
            get
            {
                return "WackyNPCs/NPCs/ScamArtist";
            }
        }

        public override bool Autoload(ref string name)
        {
            name = "ScamArtist";
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
                        if (player.inventory[j].type == 87)
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
                    return "Jade";
                case 1:
                    return "Blanche";
                case 2:
                    return "Eirlys";
                case 3:
                    return "Erica";
                case 4:
                    return "Jasmin";
                case 5:
                    return "Euria";      
                default:
                    return "Lorelei";
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
            int Merchant = NPC.FindFirstNPC(NPCID.Merchant);
            if (Merchant >= 0 && Main.rand.Next(18) == 0)
            {
                return "My father is a paragon merchant, isn't he? I learned most things from him.";
            }
            int Angler = NPC.FindFirstNPC(NPCID.Angler);
            if (Angler >= 0 && Main.rand.Next(17) == 0)
            {
                return "" + Main.npc[Angler].GivenName + " can be such an annoying brat isn't he? Don't worry, I have an Angler's Tacke Bag and a Fish Finder right here!";
            }
            int Nurse = NPC.FindFirstNPC(NPCID.Nurse);
            if (Nurse >= 0 && Main.rand.Next(16) == 0)
            {
                return "Is it raining? Getting tired to have " + Main.npc[Nurse].GivenName + " treat your broken leg? Or looking for those rumored floating islands? Here's the perfect tool for you, this multipurpose umbrella! Look, it comes in this lovely red-white color and... it isn't even expensive for something so amazing!";
            }
            int GoblinTinkerer = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
            if (GoblinTinkerer >= 0 && Main.rand.Next(15) == 0)
            {
                return "If you find them a tiny bit expensive, think about how much you pay for that pointy eared " + Main.npc[GoblinTinkerer].GivenName + " to break your blades.";
            }
            if (Main.rand.Next(14) == 0 && Main.bloodMoon)
            {
                return "Buy something or get lost.";
            }
            if (Main.rand.Next(13) == 0 && Main.hardMode)
            {
                return "Smashing altars is dangerous and fishing for crates is tedious, right? Then check out these ores!";
            }
            if (Main.rand.Next(12) == 0 && Main.hardMode)
            {
                return "Aiming for the ankh charm? Check my wares, maybe I have just the component you need!";
            }
            switch (Main.rand.Next(11))
            {
                case 0:
                    return "Yes, yes, it's true! All these super rare wares are for sale!";
                case 1:
                    return "If you buy today, you can get three, for the price of three!";
                case 2:
                    return "It's the finest spider-silk, just touch it, it's so tender, just think about all the things you could craft with it! Don't you want a velvety sofa or a dreamy, fluffy-fluffy bed? Or maybe a beautiful robe?";
                case 3:
                    return "Are you a narcissist? Or getting tired of the taste of recall potions? Don't worry! I have magic mirrors for sale today.";
                case 4:
                    return "If you buy an extractinator today, you get an extra...ctinator!";
                case 5:
                    return "Wanna try swimming in lava? This lava charm is just what you need! It offers complete protection from lava for seven whole... hou... minutes...? I think? Worry not, it worth the price!";
                case 6:
                    return "Just got some extremely rare wares! Look, this mask and robe belonged to a pharaoh once! But that's not all! Look at this! It's a flying carpet! Yes! It's real! And all are for sale today!";
                case 7:
                    return "Look at these lovely little clouds in a bottle. If you get one, it will change your life forever! You can reach some places you only dreamed about before!";
                case 8:
                    return "Are you looking for climbing claws or shoe spikes? Here's my answer, tiger climbing gear! Two in one! And at such a dirt cheap price!";
                case 9:
                    return "I have some merchandise for the cold winter days too! Would you like a pair of soft and fluffy hard warmers? Or wanna go skating on ice? These ice skates work even on thin ice!";
                default:
                    return "Ever wanted to grow moss on stone? Look no further, this staff of regrowth is what you need!";
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
            shop.item[nextSlot].SetDefaults(ItemID.Silk);
            shop.item[nextSlot].value = 19900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Aglet);
            shop.item[nextSlot].value = 199900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.TigerClimbingGear);
            shop.item[nextSlot].value = 499900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Umbrella);
            shop.item[nextSlot].value = 199900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Radar);
            shop.item[nextSlot].value = 499900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.MagicMirror);
            shop.item[nextSlot].value = 249900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.CloudinaBottle);
            shop.item[nextSlot].value = 299900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.HermesBoots);
            shop.item[nextSlot].value = 199900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Extractinator);
            shop.item[nextSlot].value = 249900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.LavaCharm);
            shop.item[nextSlot].value = 249900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.PharaohsMask);
            shop.item[nextSlot].value = 199900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.PharaohsRobe);
            shop.item[nextSlot].value = 199900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.FlyingCarpet);
            shop.item[nextSlot].value = 499900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.AnkletoftheWind);
            shop.item[nextSlot].value = 299900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.StaffofRegrowth);
            shop.item[nextSlot].value = 499900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.JungleRose);
            shop.item[nextSlot].value = 299900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.NaturesGift);
            shop.item[nextSlot].value = 299900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.WaterWalkingBoots);
            shop.item[nextSlot].value = 299900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.HandWarmer);
            shop.item[nextSlot].value = 199900;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.IceSkates);
            shop.item[nextSlot].value = 199900;
            nextSlot++;
            if (NPC.savedAngler)
            {
                shop.item[nextSlot].SetDefaults(ItemID.AnglerTackleBag);
                shop.item[nextSlot].value = 990000;
                nextSlot++;
            }
            if (NPC.savedAngler)
            {
                shop.item[nextSlot].SetDefaults(ItemID.FishFinder);
                shop.item[nextSlot].value = 4990000;
                nextSlot++;
            }
            if (NPC.downedQueenBee)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Bezoar);
                shop.item[nextSlot].value = 499900;
                nextSlot++;
            }
            if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Nazar);
                shop.item[nextSlot].value = 999900;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.CobaltOre);
                shop.item[nextSlot].value = 19900;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PalladiumOre);
                shop.item[nextSlot].value = 19900;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.MythrilOre);
                shop.item[nextSlot].value = 29900;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.OrichalcumOre);
                shop.item[nextSlot].value = 29900;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.AdamantiteOre);
                shop.item[nextSlot].value = 39900;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.TitaniumOre);
                shop.item[nextSlot].value = 39900;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Vitamins);
                shop.item[nextSlot].value = 4990000;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.ArmorPolish);
                shop.item[nextSlot].value = 4990000;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.AdhesiveBandage);
                shop.item[nextSlot].value = 4990000;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Megaphone);
                shop.item[nextSlot].value = 4990000;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.TrifoldMap);
                shop.item[nextSlot].value = 4990000;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.FastClock);
                shop.item[nextSlot].value = 4990000;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Blindfold);
                shop.item[nextSlot].value = 4990000;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.MoonCharm);
                shop.item[nextSlot].value = 4990000;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.NeptunesShell);
                shop.item[nextSlot].value = 4990000;
                nextSlot++;
            }
            if (NPC.downedGolemBoss)
            {
                shop.item[nextSlot].SetDefaults(ItemID.CelestialStone);
                shop.item[nextSlot].value = 9990000;
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
            projType = ProjectileID.PoisonedKnife;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}