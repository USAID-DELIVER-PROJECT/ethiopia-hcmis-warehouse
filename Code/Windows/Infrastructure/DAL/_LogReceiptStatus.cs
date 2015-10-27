
/*
'===============================================================================
'  Generated From - CSharp_dOOdads_BusinessEntity.vbgen
' 
'  ** IMPORTANT  ** 
'  How to Generate your stored procedures:
' 
'  SQL        = SQL_StoredProcs.vbgen
'  ACCESS     = Access_StoredProcs.vbgen
'  ORACLE     = Oracle_StoredProcs.vbgen
'  FIREBIRD   = FirebirdStoredProcs.vbgen
'  POSTGRESQL = PostgreSQL_StoredProcs.vbgen
'
'  The supporting base class SqlClientEntity is in the Architecture directory in "dOOdads".
'  
'  This object is 'abstract' which means you need to inherit from it to be able
'  to instantiate it.  This is very easilly done. You can override properties and
'  methods in your derived class, this allows you to regenerate this class at any
'  time and not worry about overwriting custom code. 
'
'  NEVER EDIT THIS FILE.
'
'  public class YourObject :  _YourObject
'  {
'
'  }
'
'===============================================================================
*/

// Generated by MyGeneration Version # (1.2.0.7)

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;

using MyGeneration.dOOdads;

namespace DAL
{
	public abstract class _LogReceiptStatus : SqlClientEntity
	{
		public _LogReceiptStatus()
		{
			this.QuerySource = "LogReceiptStatus";
			this.MappingName = "LogReceiptStatus";

		}	

		//=================================================================
		//  public Overrides void AddNew()
		//=================================================================
		//
		//=================================================================
		public override void AddNew()
		{
			base.AddNew();
			
		}
		
		
		public override void FlushData()
		{
			this._whereClause = null;
			this._aggregateClause = null;
			base.FlushData();
		}
		
		//=================================================================
		//  	public Function LoadAll() As Boolean
		//=================================================================
		//  Loads all of the records in the database, and sets the currentRow to the first row
		//=================================================================
		public bool LoadAll() 
		{
			ListDictionary parameters = null;
			
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_LogReceiptStatusLoadAll]", parameters);
		}
	
		//=================================================================
		// public Overridable Function LoadByPrimaryKey()  As Boolean
		//=================================================================
		//  Loads a single row of via the primary key
		//=================================================================
		public virtual bool LoadByPrimaryKey(int ID)
		{
			ListDictionary parameters = new ListDictionary();
			parameters.Add(Parameters.ID, ID);

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_LogReceiptStatusLoadByPrimaryKey]", parameters);
		}
		
		#region Parameters
		protected class Parameters
		{
			
			public static SqlParameter ID
			{
				get
				{
					return new SqlParameter("@ID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter ReceiptID
			{
				get
				{
					return new SqlParameter("@ReceiptID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter StatusChangedDate
			{
				get
				{
					return new SqlParameter("@StatusChangedDate", SqlDbType.DateTime, 0);
				}
			}
			
			public static SqlParameter FromStatusID
			{
				get
				{
					return new SqlParameter("@FromStatusID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter ToStatusID
			{
				get
				{
					return new SqlParameter("@ToStatusID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter ReceiptConfirmationPrintoutID
			{
				get
				{
					return new SqlParameter("@ReceiptConfirmationPrintoutID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter URL
			{
				get
				{
					return new SqlParameter("@URL", SqlDbType.NVarChar, 50);
				}
			}
			
			public static SqlParameter UserID
			{
				get
				{
					return new SqlParameter("@UserID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter ActionIdentifier
			{
				get
				{
					return new SqlParameter("@ActionIdentifier", SqlDbType.NVarChar, 50);
				}
			}
			
			public static SqlParameter Description
			{
				get
				{
					return new SqlParameter("@Description", SqlDbType.NVarChar, 50);
				}
			}
			
		}
		#endregion		
	
		#region ColumnNames
		public class ColumnNames
		{  
            public const string ID = "ID";
            public const string ReceiptID = "ReceiptID";
            public const string StatusChangedDate = "StatusChangedDate";
            public const string FromStatusID = "FromStatusID";
            public const string ToStatusID = "ToStatusID";
            public const string ReceiptConfirmationPrintoutID = "ReceiptConfirmationPrintoutID";
            public const string URL = "URL";
            public const string UserID = "UserID";
            public const string ActionIdentifier = "ActionIdentifier";
            public const string Description = "Description";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[ID] = _LogReceiptStatus.PropertyNames.ID;
					ht[ReceiptID] = _LogReceiptStatus.PropertyNames.ReceiptID;
					ht[StatusChangedDate] = _LogReceiptStatus.PropertyNames.StatusChangedDate;
					ht[FromStatusID] = _LogReceiptStatus.PropertyNames.FromStatusID;
					ht[ToStatusID] = _LogReceiptStatus.PropertyNames.ToStatusID;
					ht[ReceiptConfirmationPrintoutID] = _LogReceiptStatus.PropertyNames.ReceiptConfirmationPrintoutID;
					ht[URL] = _LogReceiptStatus.PropertyNames.URL;
					ht[UserID] = _LogReceiptStatus.PropertyNames.UserID;
					ht[ActionIdentifier] = _LogReceiptStatus.PropertyNames.ActionIdentifier;
					ht[Description] = _LogReceiptStatus.PropertyNames.Description;

				}
				return (string)ht[columnName];
			}

			static private Hashtable ht = null;			 
		}
		#endregion
		
		#region PropertyNames
		public class PropertyNames
		{  
            public const string ID = "ID";
            public const string ReceiptID = "ReceiptID";
            public const string StatusChangedDate = "StatusChangedDate";
            public const string FromStatusID = "FromStatusID";
            public const string ToStatusID = "ToStatusID";
            public const string ReceiptConfirmationPrintoutID = "ReceiptConfirmationPrintoutID";
            public const string URL = "URL";
            public const string UserID = "UserID";
            public const string ActionIdentifier = "ActionIdentifier";
            public const string Description = "Description";

			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[ID] = _LogReceiptStatus.ColumnNames.ID;
					ht[ReceiptID] = _LogReceiptStatus.ColumnNames.ReceiptID;
					ht[StatusChangedDate] = _LogReceiptStatus.ColumnNames.StatusChangedDate;
					ht[FromStatusID] = _LogReceiptStatus.ColumnNames.FromStatusID;
					ht[ToStatusID] = _LogReceiptStatus.ColumnNames.ToStatusID;
					ht[ReceiptConfirmationPrintoutID] = _LogReceiptStatus.ColumnNames.ReceiptConfirmationPrintoutID;
					ht[URL] = _LogReceiptStatus.ColumnNames.URL;
					ht[UserID] = _LogReceiptStatus.ColumnNames.UserID;
					ht[ActionIdentifier] = _LogReceiptStatus.ColumnNames.ActionIdentifier;
					ht[Description] = _LogReceiptStatus.ColumnNames.Description;

				}
				return (string)ht[propertyName];
			}

			static private Hashtable ht = null;			 
		}			 
		#endregion	

		#region StringPropertyNames
		public class StringPropertyNames
		{  
            public const string ID = "s_ID";
            public const string ReceiptID = "s_ReceiptID";
            public const string StatusChangedDate = "s_StatusChangedDate";
            public const string FromStatusID = "s_FromStatusID";
            public const string ToStatusID = "s_ToStatusID";
            public const string ReceiptConfirmationPrintoutID = "s_ReceiptConfirmationPrintoutID";
            public const string URL = "s_URL";
            public const string UserID = "s_UserID";
            public const string ActionIdentifier = "s_ActionIdentifier";
            public const string Description = "s_Description";

		}
		#endregion		
		
		#region Properties
	
		public virtual int ID
	    {
			get
	        {
				return base.Getint(ColumnNames.ID);
			}
			set
	        {
				base.Setint(ColumnNames.ID, value);
			}
		}

		public virtual int ReceiptID
	    {
			get
	        {
				return base.Getint(ColumnNames.ReceiptID);
			}
			set
	        {
				base.Setint(ColumnNames.ReceiptID, value);
			}
		}

		public virtual DateTime StatusChangedDate
	    {
			get
	        {
				return base.GetDateTime(ColumnNames.StatusChangedDate);
			}
			set
	        {
				base.SetDateTime(ColumnNames.StatusChangedDate, value);
			}
		}

		public virtual int FromStatusID
	    {
			get
	        {
				return base.Getint(ColumnNames.FromStatusID);
			}
			set
	        {
				base.Setint(ColumnNames.FromStatusID, value);
			}
		}

		public virtual int ToStatusID
	    {
			get
	        {
				return base.Getint(ColumnNames.ToStatusID);
			}
			set
	        {
				base.Setint(ColumnNames.ToStatusID, value);
			}
		}

		public virtual int ReceiptConfirmationPrintoutID
	    {
			get
	        {
				return base.Getint(ColumnNames.ReceiptConfirmationPrintoutID);
			}
			set
	        {
				base.Setint(ColumnNames.ReceiptConfirmationPrintoutID, value);
			}
		}

		public virtual string URL
	    {
			get
	        {
				return base.Getstring(ColumnNames.URL);
			}
			set
	        {
				base.Setstring(ColumnNames.URL, value);
			}
		}

		public virtual int UserID
	    {
			get
	        {
				return base.Getint(ColumnNames.UserID);
			}
			set
	        {
				base.Setint(ColumnNames.UserID, value);
			}
		}

		public virtual string ActionIdentifier
	    {
			get
	        {
				return base.Getstring(ColumnNames.ActionIdentifier);
			}
			set
	        {
				base.Setstring(ColumnNames.ActionIdentifier, value);
			}
		}

		public virtual string Description
	    {
			get
	        {
				return base.Getstring(ColumnNames.Description);
			}
			set
	        {
				base.Setstring(ColumnNames.Description, value);
			}
		}


		#endregion
		
		#region String Properties
	
		public virtual string s_ID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.ID) ? string.Empty : base.GetintAsString(ColumnNames.ID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.ID);
				else
					this.ID = base.SetintAsString(ColumnNames.ID, value);
			}
		}

		public virtual string s_ReceiptID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.ReceiptID) ? string.Empty : base.GetintAsString(ColumnNames.ReceiptID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.ReceiptID);
				else
					this.ReceiptID = base.SetintAsString(ColumnNames.ReceiptID, value);
			}
		}

		public virtual string s_StatusChangedDate
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.StatusChangedDate) ? string.Empty : base.GetDateTimeAsString(ColumnNames.StatusChangedDate);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.StatusChangedDate);
				else
					this.StatusChangedDate = base.SetDateTimeAsString(ColumnNames.StatusChangedDate, value);
			}
		}

		public virtual string s_FromStatusID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.FromStatusID) ? string.Empty : base.GetintAsString(ColumnNames.FromStatusID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.FromStatusID);
				else
					this.FromStatusID = base.SetintAsString(ColumnNames.FromStatusID, value);
			}
		}

		public virtual string s_ToStatusID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.ToStatusID) ? string.Empty : base.GetintAsString(ColumnNames.ToStatusID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.ToStatusID);
				else
					this.ToStatusID = base.SetintAsString(ColumnNames.ToStatusID, value);
			}
		}

		public virtual string s_ReceiptConfirmationPrintoutID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.ReceiptConfirmationPrintoutID) ? string.Empty : base.GetintAsString(ColumnNames.ReceiptConfirmationPrintoutID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.ReceiptConfirmationPrintoutID);
				else
					this.ReceiptConfirmationPrintoutID = base.SetintAsString(ColumnNames.ReceiptConfirmationPrintoutID, value);
			}
		}

		public virtual string s_URL
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.URL) ? string.Empty : base.GetstringAsString(ColumnNames.URL);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.URL);
				else
					this.URL = base.SetstringAsString(ColumnNames.URL, value);
			}
		}

		public virtual string s_UserID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.UserID) ? string.Empty : base.GetintAsString(ColumnNames.UserID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.UserID);
				else
					this.UserID = base.SetintAsString(ColumnNames.UserID, value);
			}
		}

		public virtual string s_ActionIdentifier
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.ActionIdentifier) ? string.Empty : base.GetstringAsString(ColumnNames.ActionIdentifier);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.ActionIdentifier);
				else
					this.ActionIdentifier = base.SetstringAsString(ColumnNames.ActionIdentifier, value);
			}
		}

		public virtual string s_Description
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Description) ? string.Empty : base.GetstringAsString(ColumnNames.Description);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Description);
				else
					this.Description = base.SetstringAsString(ColumnNames.Description, value);
			}
		}


		#endregion		
	
		#region Where Clause
		public class WhereClause
		{
			public WhereClause(BusinessEntity entity)
			{
				this._entity = entity;
			}
			
			public TearOffWhereParameter TearOff
			{
				get
				{
					if(_tearOff == null)
					{
						_tearOff = new TearOffWhereParameter(this);
					}

					return _tearOff;
				}
			}

			#region WhereParameter TearOff's
			public class TearOffWhereParameter
			{
				public TearOffWhereParameter(WhereClause clause)
				{
					this._clause = clause;
				}
				
				
				public WhereParameter ID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.ID, Parameters.ID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter ReceiptID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.ReceiptID, Parameters.ReceiptID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter StatusChangedDate
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.StatusChangedDate, Parameters.StatusChangedDate);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter FromStatusID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.FromStatusID, Parameters.FromStatusID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter ToStatusID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.ToStatusID, Parameters.ToStatusID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter ReceiptConfirmationPrintoutID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.ReceiptConfirmationPrintoutID, Parameters.ReceiptConfirmationPrintoutID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter URL
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.URL, Parameters.URL);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter UserID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.UserID, Parameters.UserID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter ActionIdentifier
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.ActionIdentifier, Parameters.ActionIdentifier);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Description
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Description, Parameters.Description);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}


				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter ID
		    {
				get
		        {
					if(_ID_W == null)
	        	    {
						_ID_W = TearOff.ID;
					}
					return _ID_W;
				}
			}

			public WhereParameter ReceiptID
		    {
				get
		        {
					if(_ReceiptID_W == null)
	        	    {
						_ReceiptID_W = TearOff.ReceiptID;
					}
					return _ReceiptID_W;
				}
			}

			public WhereParameter StatusChangedDate
		    {
				get
		        {
					if(_StatusChangedDate_W == null)
	        	    {
						_StatusChangedDate_W = TearOff.StatusChangedDate;
					}
					return _StatusChangedDate_W;
				}
			}

			public WhereParameter FromStatusID
		    {
				get
		        {
					if(_FromStatusID_W == null)
	        	    {
						_FromStatusID_W = TearOff.FromStatusID;
					}
					return _FromStatusID_W;
				}
			}

			public WhereParameter ToStatusID
		    {
				get
		        {
					if(_ToStatusID_W == null)
	        	    {
						_ToStatusID_W = TearOff.ToStatusID;
					}
					return _ToStatusID_W;
				}
			}

			public WhereParameter ReceiptConfirmationPrintoutID
		    {
				get
		        {
					if(_ReceiptConfirmationPrintoutID_W == null)
	        	    {
						_ReceiptConfirmationPrintoutID_W = TearOff.ReceiptConfirmationPrintoutID;
					}
					return _ReceiptConfirmationPrintoutID_W;
				}
			}

			public WhereParameter URL
		    {
				get
		        {
					if(_URL_W == null)
	        	    {
						_URL_W = TearOff.URL;
					}
					return _URL_W;
				}
			}

			public WhereParameter UserID
		    {
				get
		        {
					if(_UserID_W == null)
	        	    {
						_UserID_W = TearOff.UserID;
					}
					return _UserID_W;
				}
			}

			public WhereParameter ActionIdentifier
		    {
				get
		        {
					if(_ActionIdentifier_W == null)
	        	    {
						_ActionIdentifier_W = TearOff.ActionIdentifier;
					}
					return _ActionIdentifier_W;
				}
			}

			public WhereParameter Description
		    {
				get
		        {
					if(_Description_W == null)
	        	    {
						_Description_W = TearOff.Description;
					}
					return _Description_W;
				}
			}

			private WhereParameter _ID_W = null;
			private WhereParameter _ReceiptID_W = null;
			private WhereParameter _StatusChangedDate_W = null;
			private WhereParameter _FromStatusID_W = null;
			private WhereParameter _ToStatusID_W = null;
			private WhereParameter _ReceiptConfirmationPrintoutID_W = null;
			private WhereParameter _URL_W = null;
			private WhereParameter _UserID_W = null;
			private WhereParameter _ActionIdentifier_W = null;
			private WhereParameter _Description_W = null;

			public void WhereClauseReset()
			{
				_ID_W = null;
				_ReceiptID_W = null;
				_StatusChangedDate_W = null;
				_FromStatusID_W = null;
				_ToStatusID_W = null;
				_ReceiptConfirmationPrintoutID_W = null;
				_URL_W = null;
				_UserID_W = null;
				_ActionIdentifier_W = null;
				_Description_W = null;

				this._entity.Query.FlushWhereParameters();

			}
	
			private BusinessEntity _entity;
			private TearOffWhereParameter _tearOff;
			
		}
	
		public WhereClause Where
		{
			get
			{
				if(_whereClause == null)
				{
					_whereClause = new WhereClause(this);
				}
		
				return _whereClause;
			}
		}
		
		private WhereClause _whereClause = null;	
		#endregion
	
		#region Aggregate Clause
		public class AggregateClause
		{
			public AggregateClause(BusinessEntity entity)
			{
				this._entity = entity;
			}
			
			public TearOffAggregateParameter TearOff
			{
				get
				{
					if(_tearOff == null)
					{
						_tearOff = new TearOffAggregateParameter(this);
					}

					return _tearOff;
				}
			}

			#region AggregateParameter TearOff's
			public class TearOffAggregateParameter
			{
				public TearOffAggregateParameter(AggregateClause clause)
				{
					this._clause = clause;
				}
				
				
				public AggregateParameter ID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.ID, Parameters.ID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter ReceiptID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.ReceiptID, Parameters.ReceiptID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter StatusChangedDate
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.StatusChangedDate, Parameters.StatusChangedDate);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter FromStatusID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.FromStatusID, Parameters.FromStatusID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter ToStatusID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.ToStatusID, Parameters.ToStatusID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter ReceiptConfirmationPrintoutID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.ReceiptConfirmationPrintoutID, Parameters.ReceiptConfirmationPrintoutID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter URL
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.URL, Parameters.URL);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter UserID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.UserID, Parameters.UserID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter ActionIdentifier
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.ActionIdentifier, Parameters.ActionIdentifier);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Description
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Description, Parameters.Description);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter ID
		    {
				get
		        {
					if(_ID_W == null)
	        	    {
						_ID_W = TearOff.ID;
					}
					return _ID_W;
				}
			}

			public AggregateParameter ReceiptID
		    {
				get
		        {
					if(_ReceiptID_W == null)
	        	    {
						_ReceiptID_W = TearOff.ReceiptID;
					}
					return _ReceiptID_W;
				}
			}

			public AggregateParameter StatusChangedDate
		    {
				get
		        {
					if(_StatusChangedDate_W == null)
	        	    {
						_StatusChangedDate_W = TearOff.StatusChangedDate;
					}
					return _StatusChangedDate_W;
				}
			}

			public AggregateParameter FromStatusID
		    {
				get
		        {
					if(_FromStatusID_W == null)
	        	    {
						_FromStatusID_W = TearOff.FromStatusID;
					}
					return _FromStatusID_W;
				}
			}

			public AggregateParameter ToStatusID
		    {
				get
		        {
					if(_ToStatusID_W == null)
	        	    {
						_ToStatusID_W = TearOff.ToStatusID;
					}
					return _ToStatusID_W;
				}
			}

			public AggregateParameter ReceiptConfirmationPrintoutID
		    {
				get
		        {
					if(_ReceiptConfirmationPrintoutID_W == null)
	        	    {
						_ReceiptConfirmationPrintoutID_W = TearOff.ReceiptConfirmationPrintoutID;
					}
					return _ReceiptConfirmationPrintoutID_W;
				}
			}

			public AggregateParameter URL
		    {
				get
		        {
					if(_URL_W == null)
	        	    {
						_URL_W = TearOff.URL;
					}
					return _URL_W;
				}
			}

			public AggregateParameter UserID
		    {
				get
		        {
					if(_UserID_W == null)
	        	    {
						_UserID_W = TearOff.UserID;
					}
					return _UserID_W;
				}
			}

			public AggregateParameter ActionIdentifier
		    {
				get
		        {
					if(_ActionIdentifier_W == null)
	        	    {
						_ActionIdentifier_W = TearOff.ActionIdentifier;
					}
					return _ActionIdentifier_W;
				}
			}

			public AggregateParameter Description
		    {
				get
		        {
					if(_Description_W == null)
	        	    {
						_Description_W = TearOff.Description;
					}
					return _Description_W;
				}
			}

			private AggregateParameter _ID_W = null;
			private AggregateParameter _ReceiptID_W = null;
			private AggregateParameter _StatusChangedDate_W = null;
			private AggregateParameter _FromStatusID_W = null;
			private AggregateParameter _ToStatusID_W = null;
			private AggregateParameter _ReceiptConfirmationPrintoutID_W = null;
			private AggregateParameter _URL_W = null;
			private AggregateParameter _UserID_W = null;
			private AggregateParameter _ActionIdentifier_W = null;
			private AggregateParameter _Description_W = null;

			public void AggregateClauseReset()
			{
				_ID_W = null;
				_ReceiptID_W = null;
				_StatusChangedDate_W = null;
				_FromStatusID_W = null;
				_ToStatusID_W = null;
				_ReceiptConfirmationPrintoutID_W = null;
				_URL_W = null;
				_UserID_W = null;
				_ActionIdentifier_W = null;
				_Description_W = null;

				this._entity.Query.FlushAggregateParameters();

			}
	
			private BusinessEntity _entity;
			private TearOffAggregateParameter _tearOff;
			
		}
	
		public AggregateClause Aggregate
		{
			get
			{
				if(_aggregateClause == null)
				{
					_aggregateClause = new AggregateClause(this);
				}
		
				return _aggregateClause;
			}
		}
		
		private AggregateClause _aggregateClause = null;	
		#endregion
	
		protected override IDbCommand GetInsertCommand() 
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_LogReceiptStatusInsert]";
	
			CreateParameters(cmd);
			
			SqlParameter p;
			p = cmd.Parameters[Parameters.ID.ParameterName];
			p.Direction = ParameterDirection.Output;
    
			return cmd;
		}
	
		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_LogReceiptStatusUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
	
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_LogReceiptStatusDelete]";
	
			SqlParameter p;
			p = cmd.Parameters.Add(Parameters.ID);
			p.SourceColumn = ColumnNames.ID;
			p.SourceVersion = DataRowVersion.Current;

  
			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
			SqlParameter p;
		
			p = cmd.Parameters.Add(Parameters.ID);
			p.SourceColumn = ColumnNames.ID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.ReceiptID);
			p.SourceColumn = ColumnNames.ReceiptID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.StatusChangedDate);
			p.SourceColumn = ColumnNames.StatusChangedDate;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.FromStatusID);
			p.SourceColumn = ColumnNames.FromStatusID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.ToStatusID);
			p.SourceColumn = ColumnNames.ToStatusID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.ReceiptConfirmationPrintoutID);
			p.SourceColumn = ColumnNames.ReceiptConfirmationPrintoutID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.URL);
			p.SourceColumn = ColumnNames.URL;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.UserID);
			p.SourceColumn = ColumnNames.UserID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.ActionIdentifier);
			p.SourceColumn = ColumnNames.ActionIdentifier;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Description);
			p.SourceColumn = ColumnNames.Description;
			p.SourceVersion = DataRowVersion.Current;


			return cmd;
		}
	}
}