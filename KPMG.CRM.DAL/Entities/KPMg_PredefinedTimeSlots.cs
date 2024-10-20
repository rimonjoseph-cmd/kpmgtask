#pragma warning disable CS1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KPMG.CRM.DAL
{
	
	
	/// <summary>
	/// Status of the Predefined Time Slots
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum KPMg_PredefinedTimeSlots_StateCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active", 0)]
		Active = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive", 1)]
		Inactive = 1,
	}
	
	/// <summary>
	/// Reason for the status of the Predefined Time Slots
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum KPMg_PredefinedTimeSlots_StatusCode
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Active", 0)]
		Active = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Inactive", 1)]
		Inactive = 2,
	}
	
	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("kpmg_predefinedtimeslots")]
	public partial class KPMg_PredefinedTimeSlots : Microsoft.Xrm.Sdk.Entity
	{
		
		/// <summary>
		/// Available fields, a the time of codegen, for the kpmg_predefinedtimeslots entity
		/// </summary>
		public partial class Fields
		{
			public const string Business_Unit_KPMg_PredefinedTimeSlots = "business_unit_kpmg_predefinedtimeslots";
			public const string CreatedBy = "createdby";
			public const string CreatedByName = "createdbyname";
			public const string CreatedByYomiName = "createdbyyominame";
			public const string CreatedOn = "createdon";
			public const string CreatedOnBehalfBy = "createdonbehalfby";
			public const string CreatedOnBehalfByName = "createdonbehalfbyname";
			public const string CreatedOnBehalfByYomiName = "createdonbehalfbyyominame";
			public const string ImportSequenceNumber = "importsequencenumber";
			public const string KPMg_BookRoom_From_KPMg_PredefinedTimeSlots = "KPMg_BookRoom_From_KPMg_PredefinedTimeSlots";
			public const string KPMg_BookRoom_To_KPMg_PredefinedTimeSlots = "KPMg_BookRoom_To_KPMg_PredefinedTimeSlots";
			public const string KPMg_Name = "kpmg_name";
			public const string KPMg_PredefinedTimeSlotsId = "kpmg_predefinedtimeslotsid";
			public const string Id = "kpmg_predefinedtimeslotsid";
			public const string KPMg_TimeId = "kpmg_timeid";
			public const string Lk_KPMg_PredefinedTimeSlots_CreatedBy = "lk_kpmg_predefinedtimeslots_createdby";
			public const string Lk_KPMg_PredefinedTimeSlots_CreatedOnBehalfBy = "lk_kpmg_predefinedtimeslots_createdonbehalfby";
			public const string Lk_KPMg_PredefinedTimeSlots_ModifiedBy = "lk_kpmg_predefinedtimeslots_modifiedby";
			public const string Lk_KPMg_PredefinedTimeSlots_ModifiedOnBehalfBy = "lk_kpmg_predefinedtimeslots_modifiedonbehalfby";
			public const string ModifiedBy = "modifiedby";
			public const string ModifiedByName = "modifiedbyname";
			public const string ModifiedByYomiName = "modifiedbyyominame";
			public const string ModifiedOn = "modifiedon";
			public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
			public const string ModifiedOnBehalfByName = "modifiedonbehalfbyname";
			public const string ModifiedOnBehalfByYomiName = "modifiedonbehalfbyyominame";
			public const string OverriddenCreatedOn = "overriddencreatedon";
			public const string OwnerId = "ownerid";
			public const string OwnerIdName = "owneridname";
			public const string OwnerIdYomiName = "owneridyominame";
			public const string OwningBusinessUnit = "owningbusinessunit";
			public const string OwningBusinessUnitName = "owningbusinessunitname";
			public const string OwningTeam = "owningteam";
			public const string OwningUser = "owninguser";
			public const string StateCode = "statecode";
			public const string StateCodename = "statecodename";
			public const string StatusCode = "statuscode";
			public const string StatusCodename = "statuscodename";
			public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";
			public const string User_KPMg_PredefinedTimeSlots = "user_kpmg_predefinedtimeslots";
			public const string UtcConversionTimeZoneCode = "utcconversiontimezonecode";
			public const string VersionNumber = "versionnumber";
		}
		
		[System.Diagnostics.DebuggerNonUserCode()]
		public KPMg_PredefinedTimeSlots(System.Guid id) : 
				base(EntityLogicalName, id)
		{
		}
		
		[System.Diagnostics.DebuggerNonUserCode()]
		public KPMg_PredefinedTimeSlots(string keyName, object keyValue) : 
				base(EntityLogicalName, keyName, keyValue)
		{
		}
		
		[System.Diagnostics.DebuggerNonUserCode()]
		public KPMg_PredefinedTimeSlots(Microsoft.Xrm.Sdk.KeyAttributeCollection keyAttributes) : 
				base(EntityLogicalName, keyAttributes)
		{
		}
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public KPMg_PredefinedTimeSlots() : 
				base(EntityLogicalName)
		{
		}
		
		public const string PrimaryIdAttribute = "kpmg_predefinedtimeslotsid";
		
		public const string PrimaryNameAttribute = "kpmg_name";
		
		public const string EntitySchemaName = "kpmg_PredefinedTimeSlots";
		
		public const string EntityLogicalName = "kpmg_predefinedtimeslots";
		
		public const string EntityLogicalCollectionName = "kpmg_predefinedtimeslotses";
		
		public const string EntitySetName = "kpmg_predefinedtimeslotses";
		
		/// <summary>
		/// Unique identifier of the user who created the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdbyname")]
		public string CreatedByName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("createdby"))
				{
					return this.FormattedValues["createdby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdbyyominame")]
		public string CreatedByYomiName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("createdby"))
				{
					return this.FormattedValues["createdby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Date and time when the record was created.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
		public System.Nullable<System.DateTime> CreatedOn
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who created the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("createdonbehalfby", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfbyname")]
		public string CreatedOnBehalfByName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("createdonbehalfby"))
				{
					return this.FormattedValues["createdonbehalfby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfbyyominame")]
		public string CreatedOnBehalfByYomiName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("createdonbehalfby"))
				{
					return this.FormattedValues["createdonbehalfby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Sequence number of the import that created this record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
		public System.Nullable<int> ImportSequenceNumber
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("importsequencenumber", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("kpmg_name")]
		public string KPMg_Name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("kpmg_name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("kpmg_name", value);
			}
		}
		
		/// <summary>
		/// Unique identifier for entity instances
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("kpmg_predefinedtimeslotsid")]
		public System.Nullable<System.Guid> KPMg_PredefinedTimeSlotsId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("kpmg_predefinedtimeslotsid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("kpmg_predefinedtimeslotsid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("kpmg_predefinedtimeslotsid")]
		public override System.Guid Id
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return base.Id;
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.KPMg_PredefinedTimeSlotsId = value;
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("kpmg_timeid")]
		public System.Nullable<int> KPMg_TimeId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("kpmg_timeid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("kpmg_timeid", value);
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who modified the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedbyname")]
		public string ModifiedByName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("modifiedby"))
				{
					return this.FormattedValues["modifiedby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedbyyominame")]
		public string ModifiedByYomiName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("modifiedby"))
				{
					return this.FormattedValues["modifiedby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Date and time when the record was modified.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
		public System.Nullable<System.DateTime> ModifiedOn
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who modified the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("modifiedonbehalfby", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfbyname")]
		public string ModifiedOnBehalfByName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("modifiedonbehalfby"))
				{
					return this.FormattedValues["modifiedonbehalfby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfbyyominame")]
		public string ModifiedOnBehalfByYomiName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("modifiedonbehalfby"))
				{
					return this.FormattedValues["modifiedonbehalfby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Date and time that the record was migrated.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
		public System.Nullable<System.DateTime> OverriddenCreatedOn
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("overriddencreatedon", value);
			}
		}
		
		/// <summary>
		/// Owner Id
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
		public Microsoft.Xrm.Sdk.EntityReference OwnerId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("ownerid", value);
			}
		}
		
		/// <summary>
		/// Name of the owner
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owneridname")]
		public string OwnerIdName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("ownerid"))
				{
					return this.FormattedValues["ownerid"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Yomi name of the owner
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owneridyominame")]
		public string OwnerIdYomiName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("ownerid"))
				{
					return this.FormattedValues["ownerid"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Unique identifier for the business unit that owns the record
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
		public Microsoft.Xrm.Sdk.EntityReference OwningBusinessUnit
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunitname")]
		public string OwningBusinessUnitName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("owningbusinessunit"))
				{
					return this.FormattedValues["owningbusinessunit"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Unique identifier for the team that owns the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
		public Microsoft.Xrm.Sdk.EntityReference OwningTeam
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
			}
		}
		
		/// <summary>
		/// Unique identifier for the user that owns the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
		public Microsoft.Xrm.Sdk.EntityReference OwningUser
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
			}
		}
		
		/// <summary>
		/// Status of the Predefined Time Slots
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
		public virtual KPMg_PredefinedTimeSlots_StateCode? StateCode
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return ((KPMg_PredefinedTimeSlots_StateCode?)(EntityOptionSetEnum.GetEnum(this, "statecode")));
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("statecode", value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecodename")]
		public string StateCodename
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("statecode"))
				{
					return this.FormattedValues["statecode"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Reason for the status of the Predefined Time Slots
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
		public virtual KPMg_PredefinedTimeSlots_StatusCode? StatusCode
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return ((KPMg_PredefinedTimeSlots_StatusCode?)(EntityOptionSetEnum.GetEnum(this, "statuscode")));
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("statuscode", value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscodename")]
		public string StatusCodename
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("statuscode"))
				{
					return this.FormattedValues["statuscode"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// For internal use only.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
		public System.Nullable<int> TimeZoneRuleVersionNumber
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("timezoneruleversionnumber", value);
			}
		}
		
		/// <summary>
		/// Time zone code that was in use when the record was created.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
		public System.Nullable<int> UtcConversionTimeZoneCode
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("utcconversiontimezonecode", value);
			}
		}
		
		/// <summary>
		/// Version Number
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
		public System.Nullable<long> VersionNumber
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
			}
		}
		
		/// <summary>
		/// 1:N kpmg_bookroom_From_kpmg_predefinedtimeslots
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("kpmg_bookroom_From_kpmg_predefinedtimeslots")]
		public System.Collections.Generic.IEnumerable<KPMG.CRM.DAL.KPMg_BookRoom> KPMg_BookRoom_From_KPMg_PredefinedTimeSlots
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<KPMG.CRM.DAL.KPMg_BookRoom>("kpmg_bookroom_From_kpmg_predefinedtimeslots", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<KPMG.CRM.DAL.KPMg_BookRoom>("kpmg_bookroom_From_kpmg_predefinedtimeslots", null, value);
			}
		}
		
		/// <summary>
		/// 1:N kpmg_bookroom_To_kpmg_predefinedtimeslots
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("kpmg_bookroom_To_kpmg_predefinedtimeslots")]
		public System.Collections.Generic.IEnumerable<KPMG.CRM.DAL.KPMg_BookRoom> KPMg_BookRoom_To_KPMg_PredefinedTimeSlots
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<KPMG.CRM.DAL.KPMg_BookRoom>("kpmg_bookroom_To_kpmg_predefinedtimeslots", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<KPMG.CRM.DAL.KPMg_BookRoom>("kpmg_bookroom_To_kpmg_predefinedtimeslots", null, value);
			}
		}
		
		/// <summary>
		/// N:1 business_unit_kpmg_predefinedtimeslots
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("business_unit_kpmg_predefinedtimeslots")]
		public KPMG.CRM.DAL.BusinessUnit Business_Unit_KPMg_PredefinedTimeSlots
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<KPMG.CRM.DAL.BusinessUnit>("business_unit_kpmg_predefinedtimeslots", null);
			}
		}
		
		/// <summary>
		/// N:1 lk_kpmg_predefinedtimeslots_createdby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_kpmg_predefinedtimeslots_createdby")]
		public KPMG.CRM.DAL.SystemUser Lk_KPMg_PredefinedTimeSlots_CreatedBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<KPMG.CRM.DAL.SystemUser>("lk_kpmg_predefinedtimeslots_createdby", null);
			}
		}
		
		/// <summary>
		/// N:1 lk_kpmg_predefinedtimeslots_createdonbehalfby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_kpmg_predefinedtimeslots_createdonbehalfby")]
		public KPMG.CRM.DAL.SystemUser Lk_KPMg_PredefinedTimeSlots_CreatedOnBehalfBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<KPMG.CRM.DAL.SystemUser>("lk_kpmg_predefinedtimeslots_createdonbehalfby", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntity<KPMG.CRM.DAL.SystemUser>("lk_kpmg_predefinedtimeslots_createdonbehalfby", null, value);
			}
		}
		
		/// <summary>
		/// N:1 lk_kpmg_predefinedtimeslots_modifiedby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_kpmg_predefinedtimeslots_modifiedby")]
		public KPMG.CRM.DAL.SystemUser Lk_KPMg_PredefinedTimeSlots_ModifiedBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<KPMG.CRM.DAL.SystemUser>("lk_kpmg_predefinedtimeslots_modifiedby", null);
			}
		}
		
		/// <summary>
		/// N:1 lk_kpmg_predefinedtimeslots_modifiedonbehalfby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_kpmg_predefinedtimeslots_modifiedonbehalfby")]
		public KPMG.CRM.DAL.SystemUser Lk_KPMg_PredefinedTimeSlots_ModifiedOnBehalfBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<KPMG.CRM.DAL.SystemUser>("lk_kpmg_predefinedtimeslots_modifiedonbehalfby", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntity<KPMG.CRM.DAL.SystemUser>("lk_kpmg_predefinedtimeslots_modifiedonbehalfby", null, value);
			}
		}
		
		/// <summary>
		/// N:1 user_kpmg_predefinedtimeslots
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("user_kpmg_predefinedtimeslots")]
		public KPMG.CRM.DAL.SystemUser User_KPMg_PredefinedTimeSlots
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<KPMG.CRM.DAL.SystemUser>("user_kpmg_predefinedtimeslots", null);
			}
		}
		
		/// <summary>
		/// Constructor for populating via LINQ queries given a LINQ anonymous type
		/// <param name="anonymousType">LINQ anonymous type.</param>
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public KPMg_PredefinedTimeSlots(object anonymousType) : 
				this()
		{
            foreach (var p in anonymousType.GetType().GetProperties())
            {
                var value = p.GetValue(anonymousType, null);
                var name = p.Name.ToLower();
            
                if (value != null && name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum))
                {
                    value = new Microsoft.Xrm.Sdk.OptionSetValue((int) value);
                    name = name.Remove(name.Length - "enum".Length);
                }
            
                switch (name)
                {
                    case "id":
                        base.Id = (System.Guid)value;
                        Attributes["kpmg_predefinedtimeslotsid"] = base.Id;
                        break;
                    case "kpmg_predefinedtimeslotsid":
                        var id = (System.Nullable<System.Guid>) value;
                        if(id == null){ continue; }
                        base.Id = id.Value;
                        Attributes[name] = base.Id;
                        break;
                    case "formattedvalues":
                        // Add Support for FormattedValues
                        FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
                        break;
                    default:
                        Attributes[name] = value;
                        break;
                }
            }
		}
	}
}
#pragma warning restore CS1591
