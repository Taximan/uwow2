/*
File:             F:\games\World of Warcraft\wow.exe
InternalName:     World of Warcraft
OriginalFilename: WoW.exe
FileVersion:      3, 0, 9, 9551
FileDescription:  World of Warcraft
Product:          World of Warcraft
ProductVersion:   Version 3.0
Debug:            False
Patched:          False
PreRelease:       True
PrivateBuild:     False
SpecialBuild:     False
Language:         Language Neutral
*/
namespace Hazzik {
	public enum UpdateFields {
		OBJECT_FIELD_GUID = 0, // 2 4:Long 1:Public
		OBJECT_FIELD_TYPE = 2, // 1 1:Int 1:Public
		OBJECT_FIELD_ENTRY = 3, // 1 1:Int 1:Public
		OBJECT_FIELD_SCALE_X = 4, // 1 3:Single 1:Public
		OBJECT_FIELD_PADDING = 5, // 1 1:Int 0:None
		OBJECT_END = 6,

		CONTAINER_FIELD_NUM_SLOTS = ITEM_END + 0, // 1 1:Int 1:Public
		CONTAINER_ALIGN_PAD = ITEM_END + 1, // 1 5:Bytes 0:None
		CONTAINER_FIELD_SLOT_1 = ITEM_END + 2, // 72 4:Long 1:Public
		CONTAINER_END = ITEM_END + 74,

		ITEM_FIELD_OWNER = OBJECT_END + 0, // 2 4:Long 1:Public
		ITEM_FIELD_CONTAINED = OBJECT_END + 2, // 2 4:Long 1:Public
		ITEM_FIELD_CREATOR = OBJECT_END + 4, // 2 4:Long 1:Public
		ITEM_FIELD_GIFTCREATOR = OBJECT_END + 6, // 2 4:Long 1:Public
		ITEM_FIELD_STACK_COUNT = OBJECT_END + 8, // 1 1:Int 20:Owner, ItemOwner
		ITEM_FIELD_DURATION = OBJECT_END + 9, // 1 1:Int 20:Owner, ItemOwner
		ITEM_FIELD_SPELL_CHARGES = OBJECT_END + 10, // 5 1:Int 20:Owner, ItemOwner
		ITEM_FIELD_FLAGS = OBJECT_END + 15, // 1 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_1_1 = OBJECT_END + 16, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_1_3 = OBJECT_END + 18, // 1 2:Shorts 1:Public
		ITEM_FIELD_ENCHANTMENT_2_1 = OBJECT_END + 19, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_2_3 = OBJECT_END + 21, // 1 2:Shorts 1:Public
		ITEM_FIELD_ENCHANTMENT_3_1 = OBJECT_END + 22, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_3_3 = OBJECT_END + 24, // 1 2:Shorts 1:Public
		ITEM_FIELD_ENCHANTMENT_4_1 = OBJECT_END + 25, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_4_3 = OBJECT_END + 27, // 1 2:Shorts 1:Public
		ITEM_FIELD_ENCHANTMENT_5_1 = OBJECT_END + 28, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_5_3 = OBJECT_END + 30, // 1 2:Shorts 1:Public
		ITEM_FIELD_ENCHANTMENT_6_1 = OBJECT_END + 31, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_6_3 = OBJECT_END + 33, // 1 2:Shorts 1:Public
		ITEM_FIELD_ENCHANTMENT_7_1 = OBJECT_END + 34, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_7_3 = OBJECT_END + 36, // 1 2:Shorts 1:Public
		ITEM_FIELD_ENCHANTMENT_8_1 = OBJECT_END + 37, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_8_3 = OBJECT_END + 39, // 1 2:Shorts 1:Public
		ITEM_FIELD_ENCHANTMENT_9_1 = OBJECT_END + 40, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_9_3 = OBJECT_END + 42, // 1 2:Shorts 1:Public
		ITEM_FIELD_ENCHANTMENT_10_1 = OBJECT_END + 43, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_10_3 = OBJECT_END + 45, // 1 2:Shorts 1:Public
		ITEM_FIELD_ENCHANTMENT_11_1 = OBJECT_END + 46, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_11_3 = OBJECT_END + 48, // 1 2:Shorts 1:Public
		ITEM_FIELD_ENCHANTMENT_12_1 = OBJECT_END + 49, // 2 1:Int 1:Public
		ITEM_FIELD_ENCHANTMENT_12_3 = OBJECT_END + 51, // 1 2:Shorts 1:Public
		ITEM_FIELD_PROPERTY_SEED = OBJECT_END + 52, // 1 1:Int 1:Public
		ITEM_FIELD_RANDOM_PROPERTIES_ID = OBJECT_END + 53, // 1 1:Int 1:Public
		ITEM_FIELD_ITEM_TEXT_ID = OBJECT_END + 54, // 1 1:Int 4:Owner
		ITEM_FIELD_DURABILITY = OBJECT_END + 55, // 1 1:Int 20:Owner, ItemOwner
		ITEM_FIELD_MAXDURABILITY = OBJECT_END + 56, // 1 1:Int 20:Owner, ItemOwner
		ITEM_FIELD_PAD = OBJECT_END + 57, // 1 1:Int 0:None
		ITEM_END = OBJECT_END + 58,

		UNIT_FIELD_CHARM = OBJECT_END + 0, // 2 4:Long 1:Public
		UNIT_FIELD_SUMMON = OBJECT_END + 2, // 2 4:Long 1:Public
		UNIT_FIELD_CRITTER = OBJECT_END + 4, // 2 4:Long 2:Private
		UNIT_FIELD_CHARMEDBY = OBJECT_END + 6, // 2 4:Long 1:Public
		UNIT_FIELD_SUMMONEDBY = OBJECT_END + 8, // 2 4:Long 1:Public
		UNIT_FIELD_CREATEDBY = OBJECT_END + 10, // 2 4:Long 1:Public
		UNIT_FIELD_TARGET = OBJECT_END + 12, // 2 4:Long 1:Public
		UNIT_FIELD_CHANNEL_OBJECT = OBJECT_END + 14, // 2 4:Long 1:Public
		UNIT_FIELD_BYTES_0 = OBJECT_END + 16, // 1 5:Bytes 1:Public
		UNIT_FIELD_HEALTH = OBJECT_END + 17, // 1 1:Int 1:Public
		UNIT_FIELD_POWER1 = OBJECT_END + 18, // 1 1:Int 1:Public
		UNIT_FIELD_POWER2 = OBJECT_END + 19, // 1 1:Int 1:Public
		UNIT_FIELD_POWER3 = OBJECT_END + 20, // 1 1:Int 1:Public
		UNIT_FIELD_POWER4 = OBJECT_END + 21, // 1 1:Int 1:Public
		UNIT_FIELD_POWER5 = OBJECT_END + 22, // 1 1:Int 1:Public
		UNIT_FIELD_POWER6 = OBJECT_END + 23, // 1 1:Int 1:Public
		UNIT_FIELD_POWER7 = OBJECT_END + 24, // 1 1:Int 1:Public
		UNIT_FIELD_MAXHEALTH = OBJECT_END + 25, // 1 1:Int 1:Public
		UNIT_FIELD_MAXPOWER1 = OBJECT_END + 26, // 1 1:Int 1:Public
		UNIT_FIELD_MAXPOWER2 = OBJECT_END + 27, // 1 1:Int 1:Public
		UNIT_FIELD_MAXPOWER3 = OBJECT_END + 28, // 1 1:Int 1:Public
		UNIT_FIELD_MAXPOWER4 = OBJECT_END + 29, // 1 1:Int 1:Public
		UNIT_FIELD_MAXPOWER5 = OBJECT_END + 30, // 1 1:Int 1:Public
		UNIT_FIELD_MAXPOWER6 = OBJECT_END + 31, // 1 1:Int 1:Public
		UNIT_FIELD_MAXPOWER7 = OBJECT_END + 32, // 1 1:Int 1:Public
		UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER = OBJECT_END + 33, // 7 3:Single 6:Private, Owner
		UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER = OBJECT_END + 40, // 7 3:Single 6:Private, Owner
		UNIT_FIELD_LEVEL = OBJECT_END + 47, // 1 1:Int 1:Public
		UNIT_FIELD_FACTIONTEMPLATE = OBJECT_END + 48, // 1 1:Int 1:Public
		UNIT_VIRTUAL_ITEM_SLOT_ID = OBJECT_END + 49, // 3 1:Int 1:Public
		UNIT_FIELD_FLAGS = OBJECT_END + 52, // 1 1:Int 1:Public
		UNIT_FIELD_FLAGS_2 = OBJECT_END + 53, // 1 1:Int 1:Public
		UNIT_FIELD_AURASTATE = OBJECT_END + 54, // 1 1:Int 1:Public
		UNIT_FIELD_BASEATTACKTIME = OBJECT_END + 55, // 2 1:Int 1:Public
		UNIT_FIELD_RANGEDATTACKTIME = OBJECT_END + 57, // 1 1:Int 2:Private
		UNIT_FIELD_BOUNDINGRADIUS = OBJECT_END + 58, // 1 3:Single 1:Public
		UNIT_FIELD_COMBATREACH = OBJECT_END + 59, // 1 3:Single 1:Public
		UNIT_FIELD_DISPLAYID = OBJECT_END + 60, // 1 1:Int 1:Public
		UNIT_FIELD_NATIVEDISPLAYID = OBJECT_END + 61, // 1 1:Int 1:Public
		UNIT_FIELD_MOUNTDISPLAYID = OBJECT_END + 62, // 1 1:Int 1:Public
		UNIT_FIELD_MINDAMAGE = OBJECT_END + 63, // 1 3:Single 38:Private, Owner, PartyLeader
		UNIT_FIELD_MAXDAMAGE = OBJECT_END + 64, // 1 3:Single 38:Private, Owner, PartyLeader
		UNIT_FIELD_MINOFFHANDDAMAGE = OBJECT_END + 65, // 1 3:Single 38:Private, Owner, PartyLeader
		UNIT_FIELD_MAXOFFHANDDAMAGE = OBJECT_END + 66, // 1 3:Single 38:Private, Owner, PartyLeader
		UNIT_FIELD_BYTES_1 = OBJECT_END + 67, // 1 5:Bytes 1:Public
		UNIT_FIELD_PETNUMBER = OBJECT_END + 68, // 1 1:Int 1:Public
		UNIT_FIELD_PET_NAME_TIMESTAMP = OBJECT_END + 69, // 1 1:Int 1:Public
		UNIT_FIELD_PETEXPERIENCE = OBJECT_END + 70, // 1 1:Int 4:Owner
		UNIT_FIELD_PETNEXTLEVELEXP = OBJECT_END + 71, // 1 1:Int 4:Owner
		UNIT_DYNAMIC_FLAGS = OBJECT_END + 72, // 1 1:Int 256:Dynamic
		UNIT_CHANNEL_SPELL = OBJECT_END + 73, // 1 1:Int 1:Public
		UNIT_MOD_CAST_SPEED = OBJECT_END + 74, // 1 3:Single 1:Public
		UNIT_CREATED_BY_SPELL = OBJECT_END + 75, // 1 1:Int 1:Public
		UNIT_NPC_FLAGS = OBJECT_END + 76, // 1 1:Int 256:Dynamic
		UNIT_NPC_EMOTESTATE = OBJECT_END + 77, // 1 1:Int 1:Public
		UNIT_FIELD_STAT0 = OBJECT_END + 78, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_STAT1 = OBJECT_END + 79, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_STAT2 = OBJECT_END + 80, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_STAT3 = OBJECT_END + 81, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_STAT4 = OBJECT_END + 82, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_POSSTAT0 = OBJECT_END + 83, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_POSSTAT1 = OBJECT_END + 84, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_POSSTAT2 = OBJECT_END + 85, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_POSSTAT3 = OBJECT_END + 86, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_POSSTAT4 = OBJECT_END + 87, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_NEGSTAT0 = OBJECT_END + 88, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_NEGSTAT1 = OBJECT_END + 89, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_NEGSTAT2 = OBJECT_END + 90, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_NEGSTAT3 = OBJECT_END + 91, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_NEGSTAT4 = OBJECT_END + 92, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_RESISTANCES = OBJECT_END + 93, // 7 1:Int 38:Private, Owner, PartyLeader
		UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE = OBJECT_END + 100, // 7 1:Int 6:Private, Owner
		UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE = OBJECT_END + 107, // 7 1:Int 6:Private, Owner
		UNIT_FIELD_BASE_MANA = OBJECT_END + 114, // 1 1:Int 1:Public
		UNIT_FIELD_BASE_HEALTH = OBJECT_END + 115, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_BYTES_2 = OBJECT_END + 116, // 1 5:Bytes 1:Public
		UNIT_FIELD_ATTACK_POWER = OBJECT_END + 117, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_ATTACK_POWER_MODS = OBJECT_END + 118, // 1 2:Shorts 6:Private, Owner
		UNIT_FIELD_ATTACK_POWER_MULTIPLIER = OBJECT_END + 119, // 1 3:Single 6:Private, Owner
		UNIT_FIELD_RANGED_ATTACK_POWER = OBJECT_END + 120, // 1 1:Int 6:Private, Owner
		UNIT_FIELD_RANGED_ATTACK_POWER_MODS = OBJECT_END + 121, // 1 2:Shorts 6:Private, Owner
		UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER = OBJECT_END + 122, // 1 3:Single 6:Private, Owner
		UNIT_FIELD_MINRANGEDDAMAGE = OBJECT_END + 123, // 1 3:Single 6:Private, Owner
		UNIT_FIELD_MAXRANGEDDAMAGE = OBJECT_END + 124, // 1 3:Single 6:Private, Owner
		UNIT_FIELD_POWER_COST_MODIFIER = OBJECT_END + 125, // 7 1:Int 6:Private, Owner
		UNIT_FIELD_POWER_COST_MULTIPLIER = OBJECT_END + 132, // 7 3:Single 6:Private, Owner
		UNIT_FIELD_MAXHEALTHMODIFIER = OBJECT_END + 139, // 1 3:Single 6:Private, Owner
		UNIT_FIELD_HOVERHEIGHT = OBJECT_END + 140, // 1 3:Single 1:Public
		UNIT_FIELD_PADDING = OBJECT_END + 141, // 1 1:Int 0:None
		UNIT_END = OBJECT_END + 142,

		PLAYER_DUEL_ARBITER = UNIT_END + 0, // 2 4:Long 1:Public
		PLAYER_FLAGS = UNIT_END + 2, // 1 1:Int 1:Public
		PLAYER_GUILDID = UNIT_END + 3, // 1 1:Int 1:Public
		PLAYER_GUILDRANK = UNIT_END + 4, // 1 1:Int 1:Public
		PLAYER_BYTES = UNIT_END + 5, // 1 5:Bytes 1:Public
		PLAYER_BYTES_2 = UNIT_END + 6, // 1 5:Bytes 1:Public
		PLAYER_BYTES_3 = UNIT_END + 7, // 1 5:Bytes 1:Public
		PLAYER_DUEL_TEAM = UNIT_END + 8, // 1 1:Int 1:Public
		PLAYER_GUILD_TIMESTAMP = UNIT_END + 9, // 1 1:Int 1:Public
		PLAYER_QUEST_LOG_1_1 = UNIT_END + 10, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_1_2 = UNIT_END + 11, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_1_3 = UNIT_END + 12, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_1_4 = UNIT_END + 13, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_2_1 = UNIT_END + 14, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_2_2 = UNIT_END + 15, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_2_3 = UNIT_END + 16, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_2_4 = UNIT_END + 17, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_3_1 = UNIT_END + 18, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_3_2 = UNIT_END + 19, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_3_3 = UNIT_END + 20, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_3_4 = UNIT_END + 21, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_4_1 = UNIT_END + 22, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_4_2 = UNIT_END + 23, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_4_3 = UNIT_END + 24, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_4_4 = UNIT_END + 25, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_5_1 = UNIT_END + 26, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_5_2 = UNIT_END + 27, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_5_3 = UNIT_END + 28, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_5_4 = UNIT_END + 29, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_6_1 = UNIT_END + 30, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_6_2 = UNIT_END + 31, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_6_3 = UNIT_END + 32, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_6_4 = UNIT_END + 33, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_7_1 = UNIT_END + 34, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_7_2 = UNIT_END + 35, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_7_3 = UNIT_END + 36, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_7_4 = UNIT_END + 37, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_8_1 = UNIT_END + 38, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_8_2 = UNIT_END + 39, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_8_3 = UNIT_END + 40, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_8_4 = UNIT_END + 41, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_9_1 = UNIT_END + 42, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_9_2 = UNIT_END + 43, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_9_3 = UNIT_END + 44, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_9_4 = UNIT_END + 45, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_10_1 = UNIT_END + 46, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_10_2 = UNIT_END + 47, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_10_3 = UNIT_END + 48, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_10_4 = UNIT_END + 49, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_11_1 = UNIT_END + 50, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_11_2 = UNIT_END + 51, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_11_3 = UNIT_END + 52, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_11_4 = UNIT_END + 53, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_12_1 = UNIT_END + 54, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_12_2 = UNIT_END + 55, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_12_3 = UNIT_END + 56, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_12_4 = UNIT_END + 57, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_13_1 = UNIT_END + 58, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_13_2 = UNIT_END + 59, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_13_3 = UNIT_END + 60, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_13_4 = UNIT_END + 61, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_14_1 = UNIT_END + 62, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_14_2 = UNIT_END + 63, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_14_3 = UNIT_END + 64, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_14_4 = UNIT_END + 65, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_15_1 = UNIT_END + 66, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_15_2 = UNIT_END + 67, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_15_3 = UNIT_END + 68, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_15_4 = UNIT_END + 69, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_16_1 = UNIT_END + 70, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_16_2 = UNIT_END + 71, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_16_3 = UNIT_END + 72, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_16_4 = UNIT_END + 73, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_17_1 = UNIT_END + 74, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_17_2 = UNIT_END + 75, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_17_3 = UNIT_END + 76, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_17_4 = UNIT_END + 77, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_18_1 = UNIT_END + 78, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_18_2 = UNIT_END + 79, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_18_3 = UNIT_END + 80, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_18_4 = UNIT_END + 81, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_19_1 = UNIT_END + 82, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_19_2 = UNIT_END + 83, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_19_3 = UNIT_END + 84, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_19_4 = UNIT_END + 85, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_20_1 = UNIT_END + 86, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_20_2 = UNIT_END + 87, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_20_3 = UNIT_END + 88, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_20_4 = UNIT_END + 89, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_21_1 = UNIT_END + 90, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_21_2 = UNIT_END + 91, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_21_3 = UNIT_END + 92, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_21_4 = UNIT_END + 93, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_22_1 = UNIT_END + 94, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_22_2 = UNIT_END + 95, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_22_3 = UNIT_END + 96, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_22_4 = UNIT_END + 97, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_23_1 = UNIT_END + 98, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_23_2 = UNIT_END + 99, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_23_3 = UNIT_END + 100, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_23_4 = UNIT_END + 101, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_24_1 = UNIT_END + 102, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_24_2 = UNIT_END + 103, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_24_3 = UNIT_END + 104, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_24_4 = UNIT_END + 105, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_25_1 = UNIT_END + 106, // 1 1:Int 64:PartyMember
		PLAYER_QUEST_LOG_25_2 = UNIT_END + 107, // 1 1:Int 2:Private
		PLAYER_QUEST_LOG_25_3 = UNIT_END + 108, // 1 5:Bytes 2:Private
		PLAYER_QUEST_LOG_25_4 = UNIT_END + 109, // 1 1:Int 2:Private
		PLAYER_VISIBLE_ITEM_1_CREATOR = UNIT_END + 110, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_1_0 = UNIT_END + 112, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_1_PROPERTIES = UNIT_END + 125, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_1_SEED = UNIT_END + 126, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_1_PAD = UNIT_END + 127, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_2_CREATOR = UNIT_END + 128, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_2_0 = UNIT_END + 130, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_2_PROPERTIES = UNIT_END + 143, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_2_SEED = UNIT_END + 144, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_2_PAD = UNIT_END + 145, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_3_CREATOR = UNIT_END + 146, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_3_0 = UNIT_END + 148, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_3_PROPERTIES = UNIT_END + 161, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_3_SEED = UNIT_END + 162, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_3_PAD = UNIT_END + 163, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_4_CREATOR = UNIT_END + 164, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_4_0 = UNIT_END + 166, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_4_PROPERTIES = UNIT_END + 179, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_4_SEED = UNIT_END + 180, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_4_PAD = UNIT_END + 181, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_5_CREATOR = UNIT_END + 182, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_5_0 = UNIT_END + 184, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_5_PROPERTIES = UNIT_END + 197, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_5_SEED = UNIT_END + 198, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_5_PAD = UNIT_END + 199, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_6_CREATOR = UNIT_END + 200, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_6_0 = UNIT_END + 202, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_6_PROPERTIES = UNIT_END + 215, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_6_SEED = UNIT_END + 216, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_6_PAD = UNIT_END + 217, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_7_CREATOR = UNIT_END + 218, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_7_0 = UNIT_END + 220, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_7_PROPERTIES = UNIT_END + 233, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_7_SEED = UNIT_END + 234, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_7_PAD = UNIT_END + 235, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_8_CREATOR = UNIT_END + 236, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_8_0 = UNIT_END + 238, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_8_PROPERTIES = UNIT_END + 251, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_8_SEED = UNIT_END + 252, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_8_PAD = UNIT_END + 253, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_9_CREATOR = UNIT_END + 254, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_9_0 = UNIT_END + 256, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_9_PROPERTIES = UNIT_END + 269, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_9_SEED = UNIT_END + 270, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_9_PAD = UNIT_END + 271, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_10_CREATOR = UNIT_END + 272, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_10_0 = UNIT_END + 274, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_10_PROPERTIES = UNIT_END + 287, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_10_SEED = UNIT_END + 288, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_10_PAD = UNIT_END + 289, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_11_CREATOR = UNIT_END + 290, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_11_0 = UNIT_END + 292, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_11_PROPERTIES = UNIT_END + 305, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_11_SEED = UNIT_END + 306, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_11_PAD = UNIT_END + 307, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_12_CREATOR = UNIT_END + 308, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_12_0 = UNIT_END + 310, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_12_PROPERTIES = UNIT_END + 323, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_12_SEED = UNIT_END + 324, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_12_PAD = UNIT_END + 325, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_13_CREATOR = UNIT_END + 326, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_13_0 = UNIT_END + 328, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_13_PROPERTIES = UNIT_END + 341, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_13_SEED = UNIT_END + 342, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_13_PAD = UNIT_END + 343, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_14_CREATOR = UNIT_END + 344, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_14_0 = UNIT_END + 346, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_14_PROPERTIES = UNIT_END + 359, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_14_SEED = UNIT_END + 360, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_14_PAD = UNIT_END + 361, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_15_CREATOR = UNIT_END + 362, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_15_0 = UNIT_END + 364, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_15_PROPERTIES = UNIT_END + 377, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_15_SEED = UNIT_END + 378, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_15_PAD = UNIT_END + 379, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_16_CREATOR = UNIT_END + 380, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_16_0 = UNIT_END + 382, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_16_PROPERTIES = UNIT_END + 395, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_16_SEED = UNIT_END + 396, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_16_PAD = UNIT_END + 397, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_17_CREATOR = UNIT_END + 398, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_17_0 = UNIT_END + 400, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_17_PROPERTIES = UNIT_END + 413, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_17_SEED = UNIT_END + 414, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_17_PAD = UNIT_END + 415, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_18_CREATOR = UNIT_END + 416, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_18_0 = UNIT_END + 418, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_18_PROPERTIES = UNIT_END + 431, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_18_SEED = UNIT_END + 432, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_18_PAD = UNIT_END + 433, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_19_CREATOR = UNIT_END + 434, // 2 4:Long 1:Public
		PLAYER_VISIBLE_ITEM_19_0 = UNIT_END + 436, // 13 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_19_PROPERTIES = UNIT_END + 449, // 1 2:Shorts 1:Public
		PLAYER_VISIBLE_ITEM_19_SEED = UNIT_END + 450, // 1 1:Int 1:Public
		PLAYER_VISIBLE_ITEM_19_PAD = UNIT_END + 451, // 1 1:Int 1:Public
		PLAYER_CHOSEN_TITLE = UNIT_END + 452, // 1 1:Int 1:Public
		PLAYER_FIELD_PAD_0 = UNIT_END + 453, // 1 1:Int 0:None
		PLAYER_FIELD_INV_SLOT_HEAD = UNIT_END + 454, // 46 4:Long 2:Private
		PLAYER_FIELD_PACK_SLOT_1 = UNIT_END + 500, // 32 4:Long 2:Private
		PLAYER_FIELD_BANK_SLOT_1 = UNIT_END + 532, // 56 4:Long 2:Private
		PLAYER_FIELD_BANKBAG_SLOT_1 = UNIT_END + 588, // 14 4:Long 2:Private
		PLAYER_FIELD_VENDORBUYBACK_SLOT_1 = UNIT_END + 602, // 24 4:Long 2:Private
		PLAYER_FIELD_KEYRING_SLOT_1 = UNIT_END + 626, // 64 4:Long 2:Private
		PLAYER_FIELD_VANITYPET_SLOT_1 = UNIT_END + 690, // 36 4:Long 2:Private
		PLAYER_FIELD_CURRENCYTOKEN_SLOT_1 = UNIT_END + 726, // 64 4:Long 2:Private
		PLAYER_FIELD_QUESTBAG_SLOT_1 = UNIT_END + 790, // 64 4:Long 2:Private
		PLAYER_FARSIGHT = UNIT_END + 854, // 2 4:Long 2:Private
		PLAYER__FIELD_KNOWN_TITLES = UNIT_END + 856, // 2 4:Long 2:Private
		PLAYER__FIELD_KNOWN_TITLES1 = UNIT_END + 858, // 2 4:Long 2:Private
		PLAYER_FIELD_KNOWN_CURRENCIES = UNIT_END + 860, // 2 4:Long 2:Private
		PLAYER_XP = UNIT_END + 862, // 1 1:Int 2:Private
		PLAYER_NEXT_LEVEL_XP = UNIT_END + 863, // 1 1:Int 2:Private
		PLAYER_SKILL_INFO_1_1 = UNIT_END + 864, // 384 2:Shorts 2:Private
		PLAYER_CHARACTER_POINTS1 = UNIT_END + 1248, // 1 1:Int 2:Private
		PLAYER_CHARACTER_POINTS2 = UNIT_END + 1249, // 1 1:Int 2:Private
		PLAYER_TRACK_CREATURES = UNIT_END + 1250, // 1 1:Int 2:Private
		PLAYER_TRACK_RESOURCES = UNIT_END + 1251, // 1 1:Int 2:Private
		PLAYER_BLOCK_PERCENTAGE = UNIT_END + 1252, // 1 3:Single 2:Private
		PLAYER_DODGE_PERCENTAGE = UNIT_END + 1253, // 1 3:Single 2:Private
		PLAYER_PARRY_PERCENTAGE = UNIT_END + 1254, // 1 3:Single 2:Private
		PLAYER_EXPERTISE = UNIT_END + 1255, // 1 1:Int 2:Private
		PLAYER_OFFHAND_EXPERTISE = UNIT_END + 1256, // 1 1:Int 2:Private
		PLAYER_CRIT_PERCENTAGE = UNIT_END + 1257, // 1 3:Single 2:Private
		PLAYER_RANGED_CRIT_PERCENTAGE = UNIT_END + 1258, // 1 3:Single 2:Private
		PLAYER_OFFHAND_CRIT_PERCENTAGE = UNIT_END + 1259, // 1 3:Single 2:Private
		PLAYER_SPELL_CRIT_PERCENTAGE1 = UNIT_END + 1260, // 7 3:Single 2:Private
		PLAYER_SHIELD_BLOCK = UNIT_END + 1267, // 1 1:Int 2:Private
		PLAYER_SHIELD_BLOCK_CRIT_PERCENTAGE = UNIT_END + 1268, // 1 3:Single 2:Private
		PLAYER_EXPLORED_ZONES_1 = UNIT_END + 1269, // 128 5:Bytes 2:Private
		PLAYER_REST_STATE_EXPERIENCE = UNIT_END + 1397, // 1 1:Int 2:Private
		PLAYER_FIELD_COINAGE = UNIT_END + 1398, // 1 1:Int 2:Private
		PLAYER_FIELD_MOD_DAMAGE_DONE_POS = UNIT_END + 1399, // 7 1:Int 2:Private
		PLAYER_FIELD_MOD_DAMAGE_DONE_NEG = UNIT_END + 1406, // 7 1:Int 2:Private
		PLAYER_FIELD_MOD_DAMAGE_DONE_PCT = UNIT_END + 1413, // 7 1:Int 2:Private
		PLAYER_FIELD_MOD_HEALING_DONE_POS = UNIT_END + 1420, // 1 1:Int 2:Private
		PLAYER_FIELD_MOD_TARGET_RESISTANCE = UNIT_END + 1421, // 1 1:Int 2:Private
		PLAYER_FIELD_MOD_TARGET_PHYSICAL_RESISTANCE = UNIT_END + 1422, // 1 1:Int 2:Private
		PLAYER_FIELD_BYTES = UNIT_END + 1423, // 1 5:Bytes 2:Private
		PLAYER_AMMO_ID = UNIT_END + 1424, // 1 1:Int 2:Private
		PLAYER_SELF_RES_SPELL = UNIT_END + 1425, // 1 1:Int 2:Private
		PLAYER_FIELD_PVP_MEDALS = UNIT_END + 1426, // 1 1:Int 2:Private
		PLAYER_FIELD_BUYBACK_PRICE_1 = UNIT_END + 1427, // 12 1:Int 2:Private
		PLAYER_FIELD_BUYBACK_TIMESTAMP_1 = UNIT_END + 1439, // 12 1:Int 2:Private
		PLAYER_FIELD_KILLS = UNIT_END + 1451, // 1 2:Shorts 2:Private
		PLAYER_FIELD_TODAY_CONTRIBUTION = UNIT_END + 1452, // 1 1:Int 2:Private
		PLAYER_FIELD_YESTERDAY_CONTRIBUTION = UNIT_END + 1453, // 1 1:Int 2:Private
		PLAYER_FIELD_LIFETIME_HONORBALE_KILLS = UNIT_END + 1454, // 1 1:Int 2:Private
		PLAYER_FIELD_BYTES2 = UNIT_END + 1455, // 1 5:Bytes 2:Private
		PLAYER_FIELD_WATCHED_FACTION_INDEX = UNIT_END + 1456, // 1 1:Int 2:Private
		PLAYER_FIELD_COMBAT_RATING_1 = UNIT_END + 1457, // 25 1:Int 2:Private
		PLAYER_FIELD_ARENA_TEAM_INFO_1_1 = UNIT_END + 1482, // 18 1:Int 2:Private
		PLAYER_FIELD_HONOR_CURRENCY = UNIT_END + 1500, // 1 1:Int 2:Private
		PLAYER_FIELD_ARENA_CURRENCY = UNIT_END + 1501, // 1 1:Int 2:Private
		PLAYER_FIELD_MAX_LEVEL = UNIT_END + 1502, // 1 1:Int 2:Private
		PLAYER_FIELD_DAILY_QUESTS_1 = UNIT_END + 1503, // 25 1:Int 2:Private
		PLAYER_RUNE_REGEN_1 = UNIT_END + 1528, // 4 3:Single 2:Private
		PLAYER_NO_REAGENT_COST_1 = UNIT_END + 1532, // 3 1:Int 2:Private
		PLAYER_FIELD_GLYPH_SLOTS_1 = UNIT_END + 1535, // 8 1:Int 2:Private
		PLAYER_FIELD_GLYPHS_1 = UNIT_END + 1543, // 8 1:Int 2:Private
		PLAYER_GLYPHS_ENABLED = UNIT_END + 1551, // 1 1:Int 2:Private
		PLAYER_END = UNIT_END + 1552,

		OBJECT_FIELD_CREATED_BY = OBJECT_END + 0, // 2 4:Long 1:Public
		GAMEOBJECT_DISPLAYID = OBJECT_END + 2, // 1 1:Int 1:Public
		GAMEOBJECT_FLAGS = OBJECT_END + 3, // 1 2:Shorts 1:Public
		GAMEOBJECT_ROTATION = OBJECT_END + 4, // 2 4:Long 1:Public
		GAMEOBJECT_PARENTROTATION = OBJECT_END + 6, // 4 3:Single 1:Public
		GAMEOBJECT_POS_X = OBJECT_END + 10, // 1 3:Single 1:Public
		GAMEOBJECT_POS_Y = OBJECT_END + 11, // 1 3:Single 1:Public
		GAMEOBJECT_POS_Z = OBJECT_END + 12, // 1 3:Single 1:Public
		GAMEOBJECT_FACING = OBJECT_END + 13, // 1 3:Single 1:Public
		GAMEOBJECT_DYNAMIC = OBJECT_END + 14, // 1 2:Shorts 256:Dynamic
		GAMEOBJECT_FACTION = OBJECT_END + 15, // 1 1:Int 1:Public
		GAMEOBJECT_LEVEL = OBJECT_END + 16, // 1 1:Int 1:Public
		GAMEOBJECT_BYTES_1 = OBJECT_END + 17, // 1 5:Bytes 1:Public
		GAMEOBJECT_END = OBJECT_END + 18,

		DYNAMICOBJECT_CASTER = OBJECT_END + 0, // 2 4:Long 1:Public
		DYNAMICOBJECT_BYTES = OBJECT_END + 2, // 1 5:Bytes 1:Public
		DYNAMICOBJECT_SPELLID = OBJECT_END + 3, // 1 1:Int 1:Public
		DYNAMICOBJECT_RADIUS = OBJECT_END + 4, // 1 3:Single 1:Public
		DYNAMICOBJECT_POS_X = OBJECT_END + 5, // 1 3:Single 1:Public
		DYNAMICOBJECT_POS_Y = OBJECT_END + 6, // 1 3:Single 1:Public
		DYNAMICOBJECT_POS_Z = OBJECT_END + 7, // 1 3:Single 1:Public
		DYNAMICOBJECT_FACING = OBJECT_END + 8, // 1 3:Single 1:Public
		DYNAMICOBJECT_CASTTIME = OBJECT_END + 9, // 1 1:Int 1:Public
		DYNAMICOBJECT_END = OBJECT_END + 10,

		CORPSE_FIELD_OWNER = OBJECT_END + 0, // 2 4:Long 1:Public
		CORPSE_FIELD_PARTY = OBJECT_END + 2, // 2 4:Long 1:Public
		CORPSE_FIELD_FACING = OBJECT_END + 4, // 1 3:Single 1:Public
		CORPSE_FIELD_POS_X = OBJECT_END + 5, // 1 3:Single 1:Public
		CORPSE_FIELD_POS_Y = OBJECT_END + 6, // 1 3:Single 1:Public
		CORPSE_FIELD_POS_Z = OBJECT_END + 7, // 1 3:Single 1:Public
		CORPSE_FIELD_DISPLAY_ID = OBJECT_END + 8, // 1 1:Int 1:Public
		CORPSE_FIELD_ITEM = OBJECT_END + 9, // 19 1:Int 1:Public
		CORPSE_FIELD_BYTES_1 = OBJECT_END + 28, // 1 5:Bytes 1:Public
		CORPSE_FIELD_BYTES_2 = OBJECT_END + 29, // 1 5:Bytes 1:Public
		CORPSE_FIELD_GUILD = OBJECT_END + 30, // 1 1:Int 1:Public
		CORPSE_FIELD_FLAGS = OBJECT_END + 31, // 1 1:Int 1:Public
		CORPSE_FIELD_DYNAMIC_FLAGS = OBJECT_END + 32, // 1 1:Int 256:Dynamic
		CORPSE_FIELD_PAD = OBJECT_END + 33, // 1 1:Int 0:None
		CORPSE_END = OBJECT_END + 34,

	}
}