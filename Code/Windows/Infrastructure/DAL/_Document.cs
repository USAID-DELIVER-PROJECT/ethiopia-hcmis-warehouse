
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
	public abstract class _Document : SqlClientEntity
	{
		public _Document()
		{
			this.QuerySource = "Document";
			this.MappingName = "Document";

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
			
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_DocumentLoadAll]", parameters);
		}
	
		//=================================================================
		// public Overridable Function LoadByPrimaryKey()  As Boolean
		//=================================================================
		//  Loads a single row of via the primary key
		//=================================================================
		public virtual bool LoadByPrimaryKey(int DocumentID)
		{
			ListDictionary parameters = new ListDictionary();
			parameters.Add(Parameters.DocumentID, DocumentID);

		
			return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_DocumentLoadByPrimaryKey]", parameters);
		}
		
		#region Parameters
		protected class Parameters
		{
			
			public static SqlParameter DocumentID
			{
				get
				{
					return new SqlParameter("@DocumentID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter DocumentTypeID
			{
				get
				{
					return new SqlParameter("@DocumentTypeID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter SenderID
			{
				get
				{
					return new SqlParameter("@SenderID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter RecipientID
			{
				get
				{
					return new SqlParameter("@RecipientID", SqlDbType.Int, 0);
				}
			}
			
			public static SqlParameter DocumentContent
			{
				get
				{
					return new SqlParameter("@DocumentContent", SqlDbType.Xml, 1073741823);
				}
			}
			
			public static SqlParameter Rowguid
			{
				get
				{
					return new SqlParameter("@Rowguid", SqlDbType.UniqueIdentifier, 0);
				}
			}
			
			public static SqlParameter ModifiedDate
			{
				get
				{
					return new SqlParameter("@ModifiedDate", SqlDbType.DateTime, 0);
				}
			}
			
		}
		#endregion		
	
		#region ColumnNames
		public class ColumnNames
		{  
            public const string DocumentID = "DocumentID";
            public const string DocumentTypeID = "DocumentTypeID";
            public const string SenderID = "SenderID";
            public const string RecipientID = "RecipientID";
            public const string DocumentContent = "DocumentContent";
            public const string Rowguid = "rowguid";
            public const string ModifiedDate = "ModifiedDate";

			static public string ToPropertyName(string columnName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[DocumentID] = _Document.PropertyNames.DocumentID;
					ht[DocumentTypeID] = _Document.PropertyNames.DocumentTypeID;
					ht[SenderID] = _Document.PropertyNames.SenderID;
					ht[RecipientID] = _Document.PropertyNames.RecipientID;
					ht[DocumentContent] = _Document.PropertyNames.DocumentContent;
					ht[Rowguid] = _Document.PropertyNames.Rowguid;
					ht[ModifiedDate] = _Document.PropertyNames.ModifiedDate;

				}
				return (string)ht[columnName];
			}

			static private Hashtable ht = null;			 
		}
		#endregion
		
		#region PropertyNames
		public class PropertyNames
		{  
            public const string DocumentID = "DocumentID";
            public const string DocumentTypeID = "DocumentTypeID";
            public const string SenderID = "SenderID";
            public const string RecipientID = "RecipientID";
            public const string DocumentContent = "DocumentContent";
            public const string Rowguid = "Rowguid";
            public const string ModifiedDate = "ModifiedDate";

			static public string ToColumnName(string propertyName)
			{
				if(ht == null)
				{
					ht = new Hashtable();
					
					ht[DocumentID] = _Document.ColumnNames.DocumentID;
					ht[DocumentTypeID] = _Document.ColumnNames.DocumentTypeID;
					ht[SenderID] = _Document.ColumnNames.SenderID;
					ht[RecipientID] = _Document.ColumnNames.RecipientID;
					ht[DocumentContent] = _Document.ColumnNames.DocumentContent;
					ht[Rowguid] = _Document.ColumnNames.Rowguid;
					ht[ModifiedDate] = _Document.ColumnNames.ModifiedDate;

				}
				return (string)ht[propertyName];
			}

			static private Hashtable ht = null;			 
		}			 
		#endregion	

		#region StringPropertyNames
		public class StringPropertyNames
		{  
            public const string DocumentID = "s_DocumentID";
            public const string DocumentTypeID = "s_DocumentTypeID";
            public const string SenderID = "s_SenderID";
            public const string RecipientID = "s_RecipientID";
            public const string DocumentContent = "s_DocumentContent";
            public const string Rowguid = "s_Rowguid";
            public const string ModifiedDate = "s_ModifiedDate";

		}
		#endregion		
		
		#region Properties
	
		public virtual int DocumentID
	    {
			get
	        {
				return base.Getint(ColumnNames.DocumentID);
			}
			set
	        {
				base.Setint(ColumnNames.DocumentID, value);
			}
		}

		public virtual int DocumentTypeID
	    {
			get
	        {
				return base.Getint(ColumnNames.DocumentTypeID);
			}
			set
	        {
				base.Setint(ColumnNames.DocumentTypeID, value);
			}
		}

		public virtual int SenderID
	    {
			get
	        {
				return base.Getint(ColumnNames.SenderID);
			}
			set
	        {
				base.Setint(ColumnNames.SenderID, value);
			}
		}

		public virtual int RecipientID
	    {
			get
	        {
				return base.Getint(ColumnNames.RecipientID);
			}
			set
	        {
				base.Setint(ColumnNames.RecipientID, value);
			}
		}

		public virtual string DocumentContent
	    {
			get
	        {
				return base.Getstring(ColumnNames.DocumentContent);
			}
			set
	        {
				base.Setstring(ColumnNames.DocumentContent, value);
			}
		}

		public virtual Guid Rowguid
	    {
			get
	        {
				return base.GetGuid(ColumnNames.Rowguid);
			}
			set
	        {
				base.SetGuid(ColumnNames.Rowguid, value);
			}
		}

		public virtual DateTime ModifiedDate
	    {
			get
	        {
				return base.GetDateTime(ColumnNames.ModifiedDate);
			}
			set
	        {
				base.SetDateTime(ColumnNames.ModifiedDate, value);
			}
		}


		#endregion
		
		#region String Properties
	
		public virtual string s_DocumentID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.DocumentID) ? string.Empty : base.GetintAsString(ColumnNames.DocumentID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.DocumentID);
				else
					this.DocumentID = base.SetintAsString(ColumnNames.DocumentID, value);
			}
		}

		public virtual string s_DocumentTypeID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.DocumentTypeID) ? string.Empty : base.GetintAsString(ColumnNames.DocumentTypeID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.DocumentTypeID);
				else
					this.DocumentTypeID = base.SetintAsString(ColumnNames.DocumentTypeID, value);
			}
		}

		public virtual string s_SenderID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.SenderID) ? string.Empty : base.GetintAsString(ColumnNames.SenderID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.SenderID);
				else
					this.SenderID = base.SetintAsString(ColumnNames.SenderID, value);
			}
		}

		public virtual string s_RecipientID
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.RecipientID) ? string.Empty : base.GetintAsString(ColumnNames.RecipientID);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.RecipientID);
				else
					this.RecipientID = base.SetintAsString(ColumnNames.RecipientID, value);
			}
		}

		public virtual string s_DocumentContent
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.DocumentContent) ? string.Empty : base.GetstringAsString(ColumnNames.DocumentContent);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.DocumentContent);
				else
					this.DocumentContent = base.SetstringAsString(ColumnNames.DocumentContent, value);
			}
		}

		public virtual string s_Rowguid
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.Rowguid) ? string.Empty : base.GetGuidAsString(ColumnNames.Rowguid);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.Rowguid);
				else
					this.Rowguid = base.SetGuidAsString(ColumnNames.Rowguid, value);
			}
		}

		public virtual string s_ModifiedDate
	    {
			get
	        {
				return this.IsColumnNull(ColumnNames.ModifiedDate) ? string.Empty : base.GetDateTimeAsString(ColumnNames.ModifiedDate);
			}
			set
	        {
				if(string.Empty == value)
					this.SetColumnNull(ColumnNames.ModifiedDate);
				else
					this.ModifiedDate = base.SetDateTimeAsString(ColumnNames.ModifiedDate, value);
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
				
				
				public WhereParameter DocumentID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.DocumentID, Parameters.DocumentID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter DocumentTypeID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.DocumentTypeID, Parameters.DocumentTypeID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter SenderID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.SenderID, Parameters.SenderID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter RecipientID
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.RecipientID, Parameters.RecipientID);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter DocumentContent
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.DocumentContent, Parameters.DocumentContent);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter Rowguid
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.Rowguid, Parameters.Rowguid);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}

				public WhereParameter ModifiedDate
				{
					get
					{
							WhereParameter where = new WhereParameter(ColumnNames.ModifiedDate, Parameters.ModifiedDate);
							this._clause._entity.Query.AddWhereParameter(where);
							return where;
					}
				}


				private WhereClause _clause;
			}
			#endregion
		
			public WhereParameter DocumentID
		    {
				get
		        {
					if(_DocumentID_W == null)
	        	    {
						_DocumentID_W = TearOff.DocumentID;
					}
					return _DocumentID_W;
				}
			}

			public WhereParameter DocumentTypeID
		    {
				get
		        {
					if(_DocumentTypeID_W == null)
	        	    {
						_DocumentTypeID_W = TearOff.DocumentTypeID;
					}
					return _DocumentTypeID_W;
				}
			}

			public WhereParameter SenderID
		    {
				get
		        {
					if(_SenderID_W == null)
	        	    {
						_SenderID_W = TearOff.SenderID;
					}
					return _SenderID_W;
				}
			}

			public WhereParameter RecipientID
		    {
				get
		        {
					if(_RecipientID_W == null)
	        	    {
						_RecipientID_W = TearOff.RecipientID;
					}
					return _RecipientID_W;
				}
			}

			public WhereParameter DocumentContent
		    {
				get
		        {
					if(_DocumentContent_W == null)
	        	    {
						_DocumentContent_W = TearOff.DocumentContent;
					}
					return _DocumentContent_W;
				}
			}

			public WhereParameter Rowguid
		    {
				get
		        {
					if(_Rowguid_W == null)
	        	    {
						_Rowguid_W = TearOff.Rowguid;
					}
					return _Rowguid_W;
				}
			}

			public WhereParameter ModifiedDate
		    {
				get
		        {
					if(_ModifiedDate_W == null)
	        	    {
						_ModifiedDate_W = TearOff.ModifiedDate;
					}
					return _ModifiedDate_W;
				}
			}

			private WhereParameter _DocumentID_W = null;
			private WhereParameter _DocumentTypeID_W = null;
			private WhereParameter _SenderID_W = null;
			private WhereParameter _RecipientID_W = null;
			private WhereParameter _DocumentContent_W = null;
			private WhereParameter _Rowguid_W = null;
			private WhereParameter _ModifiedDate_W = null;

			public void WhereClauseReset()
			{
				_DocumentID_W = null;
				_DocumentTypeID_W = null;
				_SenderID_W = null;
				_RecipientID_W = null;
				_DocumentContent_W = null;
				_Rowguid_W = null;
				_ModifiedDate_W = null;

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
				
				
				public AggregateParameter DocumentID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.DocumentID, Parameters.DocumentID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter DocumentTypeID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.DocumentTypeID, Parameters.DocumentTypeID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter SenderID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.SenderID, Parameters.SenderID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter RecipientID
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.RecipientID, Parameters.RecipientID);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter DocumentContent
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.DocumentContent, Parameters.DocumentContent);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter Rowguid
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.Rowguid, Parameters.Rowguid);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}

				public AggregateParameter ModifiedDate
				{
					get
					{
							AggregateParameter aggregate = new AggregateParameter(ColumnNames.ModifiedDate, Parameters.ModifiedDate);
							this._clause._entity.Query.AddAggregateParameter(aggregate);
							return aggregate;
					}
				}


				private AggregateClause _clause;
			}
			#endregion
		
			public AggregateParameter DocumentID
		    {
				get
		        {
					if(_DocumentID_W == null)
	        	    {
						_DocumentID_W = TearOff.DocumentID;
					}
					return _DocumentID_W;
				}
			}

			public AggregateParameter DocumentTypeID
		    {
				get
		        {
					if(_DocumentTypeID_W == null)
	        	    {
						_DocumentTypeID_W = TearOff.DocumentTypeID;
					}
					return _DocumentTypeID_W;
				}
			}

			public AggregateParameter SenderID
		    {
				get
		        {
					if(_SenderID_W == null)
	        	    {
						_SenderID_W = TearOff.SenderID;
					}
					return _SenderID_W;
				}
			}

			public AggregateParameter RecipientID
		    {
				get
		        {
					if(_RecipientID_W == null)
	        	    {
						_RecipientID_W = TearOff.RecipientID;
					}
					return _RecipientID_W;
				}
			}

			public AggregateParameter DocumentContent
		    {
				get
		        {
					if(_DocumentContent_W == null)
	        	    {
						_DocumentContent_W = TearOff.DocumentContent;
					}
					return _DocumentContent_W;
				}
			}

			public AggregateParameter Rowguid
		    {
				get
		        {
					if(_Rowguid_W == null)
	        	    {
						_Rowguid_W = TearOff.Rowguid;
					}
					return _Rowguid_W;
				}
			}

			public AggregateParameter ModifiedDate
		    {
				get
		        {
					if(_ModifiedDate_W == null)
	        	    {
						_ModifiedDate_W = TearOff.ModifiedDate;
					}
					return _ModifiedDate_W;
				}
			}

			private AggregateParameter _DocumentID_W = null;
			private AggregateParameter _DocumentTypeID_W = null;
			private AggregateParameter _SenderID_W = null;
			private AggregateParameter _RecipientID_W = null;
			private AggregateParameter _DocumentContent_W = null;
			private AggregateParameter _Rowguid_W = null;
			private AggregateParameter _ModifiedDate_W = null;

			public void AggregateClauseReset()
			{
				_DocumentID_W = null;
				_DocumentTypeID_W = null;
				_SenderID_W = null;
				_RecipientID_W = null;
				_DocumentContent_W = null;
				_Rowguid_W = null;
				_ModifiedDate_W = null;

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
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_DocumentInsert]";
	
			CreateParameters(cmd);
			
			SqlParameter p;
			p = cmd.Parameters[Parameters.DocumentID.ParameterName];
			p.Direction = ParameterDirection.Output;
    
			return cmd;
		}
	
		protected override IDbCommand GetUpdateCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_DocumentUpdate]";
	
			CreateParameters(cmd);
			      
			return cmd;
		}
	
		protected override IDbCommand GetDeleteCommand()
		{
		
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_DocumentDelete]";
	
			SqlParameter p;
			p = cmd.Parameters.Add(Parameters.DocumentID);
			p.SourceColumn = ColumnNames.DocumentID;
			p.SourceVersion = DataRowVersion.Current;

  
			return cmd;
		}
		
		private IDbCommand CreateParameters(SqlCommand cmd)
		{
			SqlParameter p;
		
			p = cmd.Parameters.Add(Parameters.DocumentID);
			p.SourceColumn = ColumnNames.DocumentID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.DocumentTypeID);
			p.SourceColumn = ColumnNames.DocumentTypeID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.SenderID);
			p.SourceColumn = ColumnNames.SenderID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.RecipientID);
			p.SourceColumn = ColumnNames.RecipientID;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.DocumentContent);
			p.SourceColumn = ColumnNames.DocumentContent;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.Rowguid);
			p.SourceColumn = ColumnNames.Rowguid;
			p.SourceVersion = DataRowVersion.Current;

			p = cmd.Parameters.Add(Parameters.ModifiedDate);
			p.SourceColumn = ColumnNames.ModifiedDate;
			p.SourceVersion = DataRowVersion.Current;


			return cmd;
		}
	}
}
