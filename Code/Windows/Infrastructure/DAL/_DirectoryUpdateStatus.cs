
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
	public abstract class _DirectoryUpdateStatus : SqlClientEntity
	{
		public _DirectoryUpdateStatus()
		{
			this.QuerySource = "DirectoryUpdateStatus";
			this.MappingName = "DirectoryUpdateStatus";

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
			
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_DirectoryUpdateStatusLoadAll]", parameters);
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

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_DirectoryUpdateStatusLoadByPrimaryKey]", parameters);
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
			
			public static SqlParameter Name
			{
				get
				{
					return new SqlParameter("@Name", SqlDbType.NVarChar, 50);
				}
			}
			
			public static SqlParameter LastVersion
			{
				get
				{
					return new SqlParameter("@LastVersion", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter LastUpdated
			{
				get
				{
					return new SqlParameter("@LastUpdated", SqlDbType.DateTime, 0);
				}
			}
			
		}
		#endregion		
	
		#region ColumnNames
		public class ColumnNames
		{  
            public const string ID = "ID";
            public const string Name = "Name";
            public const string LastVersion = "LastVersion";
            public const string LastUpdated = "LastUpdated";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[ID] = _DirectoryUpdateStatus.PropertyNames.ID;
					ht[Name] = _DirectoryUpdateStatus.PropertyNames.Name;
					ht[LastVersion] = _DirectoryUpdateStatus.PropertyNames.LastVersion;
					ht[LastUpdated] = _DirectoryUpdateStatus.PropertyNames.LastUpdated;

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
            public const string Name = "Name";
            public const string LastVersion = "LastVersion";
            public const string LastUpdated = "LastUpdated";

			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[ID] = _DirectoryUpdateStatus.ColumnNames.ID;
					ht[Name] = _DirectoryUpdateStatus.ColumnNames.Name;
					ht[LastVersion] = _DirectoryUpdateStatus.ColumnNames.LastVersion;
					ht[LastUpdated] = _DirectoryUpdateStatus.ColumnNames.LastUpdated;

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
            public const string Name = "s_Name";
            public const string LastVersion = "s_LastVersion";
            public const string LastUpdated = "s_LastUpdated";

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

		public virtual string Name
	    {
			get
	        {
				return base.Getstring(ColumnNames.Name);
			}
			set
	        {
				base.Setstring(ColumnNames.Name, value);
			}
		}

		public virtual int LastVersion
	    {
			get
	        {
				return base.Getint(ColumnNames.LastVersion);
			}
			set
	        {
				base.Setint(ColumnNames.LastVersion, value);
			}
		}

		public virtual DateTime LastUpdated
	    {
			get
	        {
				return base.GetDateTime(ColumnNames.LastUpdated);
			}
			set
	        {
				base.SetDateTime(ColumnNames.LastUpdated, value);
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

		public virtual string s_Name
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Name) ? string.Empty : base.GetstringAsString(ColumnNames.Name);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Name);
				else
					this.Name = base.SetstringAsString(ColumnNames.Name, value);
			}
		}

		public virtual string s_LastVersion
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.LastVersion) ? string.Empty : base.GetintAsString(ColumnNames.LastVersion);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.LastVersion);
				else
					this.LastVersion = base.SetintAsString(ColumnNames.LastVersion, value);
			}
		}

		public virtual string s_LastUpdated
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.LastUpdated) ? string.Empty : base.GetDateTimeAsString(ColumnNames.LastUpdated);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.LastUpdated);
				else
					this.LastUpdated = base.SetDateTimeAsString(ColumnNames.LastUpdated, value);
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

				public WhereParameter Name
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Name, Parameters.Name);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter LastVersion
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.LastVersion, Parameters.LastVersion);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter LastUpdated
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.LastUpdated, Parameters.LastUpdated);
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

			public WhereParameter Name
		    {
				get
		        {
					if(_Name_W == null)
	        	    {
						_Name_W = TearOff.Name;
					}
					return _Name_W;
				}
			}

			public WhereParameter LastVersion
		    {
				get
		        {
					if(_LastVersion_W == null)
	        	    {
						_LastVersion_W = TearOff.LastVersion;
					}
					return _LastVersion_W;
				}
			}

			public WhereParameter LastUpdated
		    {
				get
		        {
					if(_LastUpdated_W == null)
	        	    {
						_LastUpdated_W = TearOff.LastUpdated;
					}
					return _LastUpdated_W;
				}
			}

			private WhereParameter _ID_W = null;
			private WhereParameter _Name_W = null;
			private WhereParameter _LastVersion_W = null;
			private WhereParameter _LastUpdated_W = null;

			public void WhereClauseReset()
			{
				_ID_W = null;
				_Name_W = null;
				_LastVersion_W = null;
				_LastUpdated_W = null;

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

				public AggregateParameter Name
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Name, Parameters.Name);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter LastVersion
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.LastVersion, Parameters.LastVersion);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter LastUpdated
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.LastUpdated, Parameters.LastUpdated);
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

			public AggregateParameter Name
		    {
				get
		        {
					if(_Name_W == null)
	        	    {
						_Name_W = TearOff.Name;
					}
					return _Name_W;
				}
			}

			public AggregateParameter LastVersion
		    {
				get
		        {
					if(_LastVersion_W == null)
	        	    {
						_LastVersion_W = TearOff.LastVersion;
					}
					return _LastVersion_W;
				}
			}

			public AggregateParameter LastUpdated
		    {
				get
		        {
					if(_LastUpdated_W == null)
	        	    {
						_LastUpdated_W = TearOff.LastUpdated;
					}
					return _LastUpdated_W;
				}
			}

			private AggregateParameter _ID_W = null;
			private AggregateParameter _Name_W = null;
			private AggregateParameter _LastVersion_W = null;
			private AggregateParameter _LastUpdated_W = null;

			public void AggregateClauseReset()
			{
				_ID_W = null;
				_Name_W = null;
				_LastVersion_W = null;
				_LastUpdated_W = null;

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
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_DirectoryUpdateStatusInsert]";
	
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
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_DirectoryUpdateStatusUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
	
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_DirectoryUpdateStatusDelete]";
	
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

			p = cmd.Parameters.Add(Parameters.Name);
			p.SourceColumn = ColumnNames.Name;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.LastVersion);
			p.SourceColumn = ColumnNames.LastVersion;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.LastUpdated);
			p.SourceColumn = ColumnNames.LastUpdated;
			p.SourceVersion = DataRowVersion.Current;


			return cmd;
		}
	}
}