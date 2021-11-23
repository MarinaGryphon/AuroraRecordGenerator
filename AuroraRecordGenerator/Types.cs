using ProtoBuf;
using System;

namespace AuroraRecordGenerator
{
	[ProtoContract]
	public enum SpeciesType
	{
		[ProtoEnum]
		None = 0,

		[ProtoEnum]
		Human,

		[ProtoEnum]
		Skrell,

		[ProtoEnum]
		Tajara,

		[ProtoEnum]
		Unathi,

		[ProtoEnum]
		Vulpkanin,

		[ProtoEnum]
		IPC

	}

	[ProtoContract]
	public enum SpeciesSubType
	{
		[ProtoEnum, SubspeciesMeta(SpeciesType.None, "N/A")]
		None = 0,

		[ProtoEnum, SubspeciesMeta(SpeciesType.Unathi, "Yeosa'Unathi", "Ethnicity")]
		YeosaUnathi,

		[ProtoEnum, SubspeciesMeta(SpeciesType.Unathi, "Ahat'Unathi", "Ethnicity")]
		AhatUnathi,

		[ProtoEnum, SubspeciesMeta(SpeciesType.Unathi, "Sundar'Unathi", "Ethnicity")]
		SundarUnathi,

		[ProtoEnum, SubspeciesMeta(SpeciesType.Unathi, "Tzeg'Unathi", "Ethnicity")]
		TzegUnathi,

		[ProtoEnum, SubspeciesMeta(SpeciesType.Unathi, "Hrad'Unathi", "Ethnicity")]
		HradUnathi,

		[ProtoEnum, SubspeciesMeta(SpeciesType.Unathi, "Lessik'Unathi", "Ethnicity")]
		LessikUnathi
	}

	[ProtoContract]
	public enum GenderType
	{
		[ProtoEnum]
		NotApplicable = 0,

		[ProtoEnum]
		Male,

		[ProtoEnum]
		Female
	}

	public static class Info
	{
		/// <summary>
		/// The current in-character date.
		/// </summary>
		public static DateTime IcDate => new DateTime(DateTime.Now.Year + 184,
			DateTime.Now.Month,
			DateTime.Now.Day);
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class SubspeciesMetaAttribute : Attribute
	{
		public SpeciesType AssociatedSpecies {get; private set;}
		public string NiceName { get; private set; }
		public string FieldName { get; private set; }
		public SubspeciesMetaAttribute(SpeciesType associatedType, string nicename, string fieldname = "Subspecies")
		{
			AssociatedSpecies = associatedType;
			NiceName = nicename;
			FieldName = fieldname;
		}
	}
}
