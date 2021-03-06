
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
	public abstract class _LogAudit : SqlClientEntity
	{
		public _LogAudit()
		{
			this.QuerySource = "LogAudit";
			this.MappingName = "LogAudit";

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
			
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_LogAuditLoadAll]", parameters);
		}
	
		//=================================================================
		// public Overridable Function LoadByPrimaryKey()  As Boolean
		//=================================================================
		//  Loads a single row of via the primary key
		//=================================================================
		public virtual bool LoadByPrimaryKey(int LogAuditID)
		{
			ListDictionary parameters = new ListDictionary();
			parameters.Add(Parameters.LogAuditID, LogAuditID);

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_LogAuditLoadByPrimaryKey]", parameters);
		}
		
		#region Parameters
		protected class Parameters
		{
			
			public static SqlParameter LogAuditID
			{
				get
				{
					return new SqlParameter("@LogAuditID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter Type
			{
				get
				{
					return new SqlParameter("@Type", SqlDbType.Char, 1);
				}
			}
			
			public static SqlParameter TableName
			{
				get
				{
					return new SqlParameter("@TableName", SqlDbType.VarChar, 128);
				}
			}
			
			public static SqlParameter PrimaryKeyField
			{
				get
				{
					return new SqlParameter("@PrimaryKeyField", SqlDbType.VarChar, 1000);
				}
			}
			
			public static SqlParameter PrimaryKeyValue
			{
				get
				{
					return new SqlParameter("@PrimaryKeyValue", SqlDbType.VarChar, 1000);
				}
			}
			
			public static SqlParameter FieldName
			{
				get
				{
					return new SqlParameter("@FieldName", SqlDbType.VarChar, 128);
				}
			}
			
			public static SqlParameter OldValue
			{
				get
				{
					return new SqlParameter("@OldValue", SqlDbType.VarChar, 4000);
				}
			}
			
			public static SqlParameter NewValue
			{
				get
				{
					return new SqlParameter("@NewValue", SqlDbType.VarChar, 4000);
				}
			}
			
			public static SqlParameter LogChangeSetID
			{
				get
				{
					return new SqlParameter("@LogChangeSetID", SqlDbType.Int, 0);
				}
			}
			
		}
		#endregion		
	
		#region ColumnNames
		public class ColumnNames
		{  
            public const string LogAuditID = "LogAuditID";
            public const string Type = "Type";
            public const string TableName = "TableName";
            public const string PrimaryKeyField = "PrimaryKeyField";
            public const string PrimaryKeyValue = "PrimaryKeyValue";
            public const string FieldName = "FieldName";
            public const string OldValue = "OldValue";
            public const string NewValue = "NewValue";
            public const string LogChangeSetID = "LogChangeSetID";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[LogAuditID] = _LogAudit.PropertyNames.LogAuditID;
					ht[Type] = _LogAudit.PropertyNames.Type;
					ht[TableName] = _LogAudit.PropertyNames.TableName;
					ht[PrimaryKeyField] = _LogAudit.PropertyNames.PrimaryKeyField;
					ht[PrimaryKeyValue] = _LogAudit.PropertyNames.PrimaryKeyValue;
					ht[FieldName] = _LogAudit.PropertyNames.FieldName;
					ht[OldValue] = _LogAudit.PropertyNames.OldValue;
					ht[NewValue] = _LogAudit.PropertyNames.NewValue;
					ht[LogChangeSetID] = _LogAudit.PropertyNames.LogChangeSetID;

				}
				return (string)ht[columnName];
			}

			static private Hashtable ht = null;			 
		}
		#endregion
		
		#region PropertyNames
		public class PropertyNames
		{  
            public const string LogAuditID = "LogAuditID";
            public const string Type = "Type";
            public const string TableName = "TableName";
            public const string PrimaryKeyField = "PrimaryKeyField";
            public const string PrimaryKeyValue = "PrimaryKeyValue";
            public const string FieldName = "FieldName";
            public const string OldValue = "OldValue";
            public const string NewValue = "NewValue";
            public const string LogChangeSetID = "LogChangeSetID";

			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[LogAuditID] = _LogAudit.ColumnNames.LogAuditID;
					ht[Type] = _LogAudit.ColumnNames.Type;
					ht[TableName] = _LogAudit.ColumnNames.TableName;
					ht[PrimaryKeyField] = _LogAudit.ColumnNames.PrimaryKeyField;
					ht[PrimaryKeyValue] = _LogAudit.ColumnNames.PrimaryKeyValue;
					ht[FieldName] = _LogAudit.ColumnNames.FieldName;
					ht[OldValue] = _LogAudit.ColumnNames.OldValue;
					ht[NewValue] = _LogAudit.ColumnNames.NewValue;
					ht[LogChangeSetID] = _LogAudit.ColumnNames.LogChangeSetID;

				}
				return (string)ht[propertyName];
			}

			static private Hashtable ht = null;			 
		}			 
		#endregion	

		#region StringPropertyNames
		public class StringPropertyNames
		{  
            public const string LogAuditID = "s_LogAuditID";
            public const string Type = "s_Type";
            public const string TableName = "s_TableName";
            public const string PrimaryKeyField = "s_PrimaryKeyField";
            public const string PrimaryKeyValue = "s_PrimaryKeyValue";
            public const string FieldName = "s_FieldName";
            public const string OldValue = "s_OldValue";
            public const string NewValue = "s_NewValue";
            public const string LogChangeSetID = "s_LogChangeSetID";

		}
		#endregion		
		
		#region Properties
	
		public virtual int LogAuditID
	    {
			get
	        {
				return base.Getint(ColumnNames.LogAuditID);
			}
			set
	        {
				base.Setint(ColumnNames.LogAuditID, value);
			}
		}

		public virtual string Type
	    {
			get
	        {
				return base.Getstring(ColumnNames.Type);
			}
			set
	        {
				base.Setstring(ColumnNames.Type, value);
			}
		}

		public virtual string TableName
	    {
			get
	        {
				return base.Getstring(ColumnNames.TableName);
			}
			set
	        {
				base.Setstring(ColumnNames.TableName, value);
			}
		}

		public virtual string PrimaryKeyField
	    {
			get
	        {
				return base.Getstring(ColumnNames.PrimaryKeyField);
			}
			set
	        {
				base.Setstring(ColumnNames.PrimaryKeyField, value);
			}
		}

		public virtual string PrimaryKeyValue
	    {
			get
	        {
				return base.Getstring(ColumnNames.PrimaryKeyValue);
			}
			set
	        {
				base.Setstring(ColumnNames.PrimaryKeyValue, value);
			}
		}

		public virtual string FieldName
	    {
			get
	        {
				return base.Getstring(ColumnNames.FieldName);
			}
			set
	        {
				base.Setstring(ColumnNames.FieldName, value);
			}
		}

		public virtual string OldValue
	    {
			get
	        {
				return base.Getstring(ColumnNames.OldValue);
			}
			set
	        {
				base.Setstring(ColumnNames.OldValue, value);
			}
		}

		public virtual string NewValue
	    {
			get
	        {
				return base.Getstring(ColumnNames.NewValue);
			}
			set
	        {
				base.Setstring(ColumnNames.NewValue, value);
			}
		}

		public virtual int LogChangeSetID
	    {
			get
	        {
				return base.Getint(ColumnNames.LogChangeSetID);
			}
			set
	        {
				base.Setint(ColumnNames.LogChangeSetID, value);
			}
		}


		#endregion
		
		#region String Properties
	
		public virtual string s_LogAuditID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.LogAuditID) ? string.Empty : base.GetintAsString(ColumnNames.LogAuditID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.LogAuditID);
				else
					this.LogAuditID = base.SetintAsString(ColumnNames.LogAuditID, value);
			}
		}

		public virtual string s_Type
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Type) ? string.Empty : base.GetstringAsString(ColumnNames.Type);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Type);
				else
					this.Type = base.SetstringAsString(ColumnNames.Type, value);
			}
		}

		public virtual string s_TableName
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.TableName) ? string.Empty : base.GetstringAsString(ColumnNames.TableName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.TableName);
				else
					this.TableName = base.SetstringAsString(ColumnNames.TableName, value);
			}
		}

		public virtual string s_PrimaryKeyField
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.PrimaryKeyField) ? string.Empty : base.GetstringAsString(ColumnNames.PrimaryKeyField);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.PrimaryKeyField);
				else
					this.PrimaryKeyField = base.SetstringAsString(ColumnNames.PrimaryKeyField, value);
			}
		}

		public virtual string s_PrimaryKeyValue
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.PrimaryKeyValue) ? string.Empty : base.GetstringAsString(ColumnNames.PrimaryKeyValue);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.PrimaryKeyValue);
				else
					this.PrimaryKeyValue = base.SetstringAsString(ColumnNames.PrimaryKeyValue, value);
			}
		}

		public virtual string s_FieldName
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.FieldName) ? string.Empty : base.GetstringAsString(ColumnNames.FieldName);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.FieldName);
				else
					this.FieldName = base.SetstringAsString(ColumnNames.FieldName, value);
			}
		}

		public virtual string s_OldValue
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.OldValue) ? string.Empty : base.GetstringAsString(ColumnNames.OldValue);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.OldValue);
				else
					this.OldValue = base.SetstringAsString(ColumnNames.OldValue, value);
			}
		}

		public virtual string s_NewValue
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.NewValue) ? string.Empty : base.GetstringAsString(ColumnNames.NewValue);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.NewValue);
				else
					this.NewValue = base.SetstringAsString(ColumnNames.NewValue, value);
			}
		}

		public virtual string s_LogChangeSetID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.LogChangeSetID) ? string.Empty : base.GetintAsString(ColumnNames.LogChangeSetID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.LogChangeSetID);
				else
					this.LogChangeSetID = base.SetintAsString(ColumnNames.LogChangeSetID, value);
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
				
				
				public WhereParameter LogAuditID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.LogAuditID, Parameters.LogAuditID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Type
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Type, Parameters.Type);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter TableName
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.TableName, Parameters.TableName);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter PrimaryKeyField
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.PrimaryKeyField, Parameters.PrimaryKeyField);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter PrimaryKeyValue
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.PrimaryKeyValue, Parameters.PrimaryKeyValue);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter FieldName
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.FieldName, Parameters.FieldName);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter OldValue
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.OldValue, Parameters.OldValue);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter NewValue
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.NewValue, Parameters.NewValue);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter LogChangeSetID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.LogChangeSetID, Parameters.LogChangeSetID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}


				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter LogAuditID
		    {
				get
		        {
					if(_LogAuditID_W == null)
	        	    {
						_LogAuditID_W = TearOff.LogAuditID;
					}
					return _LogAuditID_W;
				}
			}

			public WhereParameter Type
		    {
				get
		        {
					if(_Type_W == null)
	        	    {
						_Type_W = TearOff.Type;
					}
					return _Type_W;
				}
			}

			public WhereParameter TableName
		    {
				get
		        {
					if(_TableName_W == null)
	        	    {
						_TableName_W = TearOff.TableName;
					}
					return _TableName_W;
				}
			}

			public WhereParameter PrimaryKeyField
		    {
				get
		        {
					if(_PrimaryKeyField_W == null)
	        	    {
						_PrimaryKeyField_W = TearOff.PrimaryKeyField;
					}
					return _PrimaryKeyField_W;
				}
			}

			public WhereParameter PrimaryKeyValue
		    {
				get
		        {
					if(_PrimaryKeyValue_W == null)
	        	    {
						_PrimaryKeyValue_W = TearOff.PrimaryKeyValue;
					}
					return _PrimaryKeyValue_W;
				}
			}

			public WhereParameter FieldName
		    {
				get
		        {
					if(_FieldName_W == null)
	        	    {
						_FieldName_W = TearOff.FieldName;
					}
					return _FieldName_W;
				}
			}

			public WhereParameter OldValue
		    {
				get
		        {
					if(_OldValue_W == null)
	        	    {
						_OldValue_W = TearOff.OldValue;
					}
					return _OldValue_W;
				}
			}

			public WhereParameter NewValue
		    {
				get
		        {
					if(_NewValue_W == null)
	        	    {
						_NewValue_W = TearOff.NewValue;
					}
					return _NewValue_W;
				}
			}

			public WhereParameter LogChangeSetID
		    {
				get
		        {
					if(_LogChangeSetID_W == null)
	        	    {
						_LogChangeSetID_W = TearOff.LogChangeSetID;
					}
					return _LogChangeSetID_W;
				}
			}

			private WhereParameter _LogAuditID_W = null;
			private WhereParameter _Type_W = null;
			private WhereParameter _TableName_W = null;
			private WhereParameter _PrimaryKeyField_W = null;
			private WhereParameter _PrimaryKeyValue_W = null;
			private WhereParameter _FieldName_W = null;
			private WhereParameter _OldValue_W = null;
			private WhereParameter _NewValue_W = null;
			private WhereParameter _LogChangeSetID_W = null;

			public void WhereClauseReset()
			{
				_LogAuditID_W = null;
				_Type_W = null;
				_TableName_W = null;
				_PrimaryKeyField_W = null;
				_PrimaryKeyValue_W = null;
				_FieldName_W = null;
				_OldValue_W = null;
				_NewValue_W = null;
				_LogChangeSetID_W = null;

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
				
				
				public AggregateParameter LogAuditID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.LogAuditID, Parameters.LogAuditID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Type
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Type, Parameters.Type);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter TableName
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.TableName, Parameters.TableName);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter PrimaryKeyField
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.PrimaryKeyField, Parameters.PrimaryKeyField);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter PrimaryKeyValue
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.PrimaryKeyValue, Parameters.PrimaryKeyValue);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter FieldName
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.FieldName, Parameters.FieldName);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter OldValue
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.OldValue, Parameters.OldValue);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter NewValue
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.NewValue, Parameters.NewValue);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter LogChangeSetID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.LogChangeSetID, Parameters.LogChangeSetID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter LogAuditID
		    {
				get
		        {
					if(_LogAuditID_W == null)
	        	    {
						_LogAuditID_W = TearOff.LogAuditID;
					}
					return _LogAuditID_W;
				}
			}

			public AggregateParameter Type
		    {
				get
		        {
					if(_Type_W == null)
	        	    {
						_Type_W = TearOff.Type;
					}
					return _Type_W;
				}
			}

			public AggregateParameter TableName
		    {
				get
		        {
					if(_TableName_W == null)
	        	    {
						_TableName_W = TearOff.TableName;
					}
					return _TableName_W;
				}
			}

			public AggregateParameter PrimaryKeyField
		    {
				get
		        {
					if(_PrimaryKeyField_W == null)
	        	    {
						_PrimaryKeyField_W = TearOff.PrimaryKeyField;
					}
					return _PrimaryKeyField_W;
				}
			}

			public AggregateParameter PrimaryKeyValue
		    {
				get
		        {
					if(_PrimaryKeyValue_W == null)
	        	    {
						_PrimaryKeyValue_W = TearOff.PrimaryKeyValue;
					}
					return _PrimaryKeyValue_W;
				}
			}

			public AggregateParameter FieldName
		    {
				get
		        {
					if(_FieldName_W == null)
	        	    {
						_FieldName_W = TearOff.FieldName;
					}
					return _FieldName_W;
				}
			}

			public AggregateParameter OldValue
		    {
				get
		        {
					if(_OldValue_W == null)
	        	    {
						_OldValue_W = TearOff.OldValue;
					}
					return _OldValue_W;
				}
			}

			public AggregateParameter NewValue
		    {
				get
		        {
					if(_NewValue_W == null)
	        	    {
						_NewValue_W = TearOff.NewValue;
					}
					return _NewValue_W;
				}
			}

			public AggregateParameter LogChangeSetID
		    {
				get
		        {
					if(_LogChangeSetID_W == null)
	        	    {
						_LogChangeSetID_W = TearOff.LogChangeSetID;
					}
					return _LogChangeSetID_W;
				}
			}

			private AggregateParameter _LogAuditID_W = null;
			private AggregateParameter _Type_W = null;
			private AggregateParameter _TableName_W = null;
			private AggregateParameter _PrimaryKeyField_W = null;
			private AggregateParameter _PrimaryKeyValue_W = null;
			private AggregateParameter _FieldName_W = null;
			private AggregateParameter _OldValue_W = null;
			private AggregateParameter _NewValue_W = null;
			private AggregateParameter _LogChangeSetID_W = null;

			public void AggregateClauseReset()
			{
				_LogAuditID_W = null;
				_Type_W = null;
				_TableName_W = null;
				_PrimaryKeyField_W = null;
				_PrimaryKeyValue_W = null;
				_FieldName_W = null;
				_OldValue_W = null;
				_NewValue_W = null;
				_LogChangeSetID_W = null;

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
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_LogAuditInsert]";
	
			CreateParameters(cmd);
			
			SqlParameter p;
			p = cmd.Parameters[Parameters.LogAuditID.ParameterName];
			p.Direction = ParameterDirection.Output;
    
			return cmd;
		}
	
		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_LogAuditUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
	
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_LogAuditDelete]";
	
			SqlParameter p;
			p = cmd.Parameters.Add(Parameters.LogAuditID);
			p.SourceColumn = ColumnNames.LogAuditID;
			p.SourceVersion = DataRowVersion.Current;

  
			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
			SqlParameter p;
		
			p = cmd.Parameters.Add(Parameters.LogAuditID);
			p.SourceColumn = ColumnNames.LogAuditID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Type);
			p.SourceColumn = ColumnNames.Type;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.TableName);
			p.SourceColumn = ColumnNames.TableName;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.PrimaryKeyField);
			p.SourceColumn = ColumnNames.PrimaryKeyField;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.PrimaryKeyValue);
			p.SourceColumn = ColumnNames.PrimaryKeyValue;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.FieldName);
			p.SourceColumn = ColumnNames.FieldName;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.OldValue);
			p.SourceColumn = ColumnNames.OldValue;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.NewValue);
			p.SourceColumn = ColumnNames.NewValue;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.LogChangeSetID);
			p.SourceColumn = ColumnNames.LogChangeSetID;
			p.SourceVersion = DataRowVersion.Current;


			return cmd;
		}
	}
}
