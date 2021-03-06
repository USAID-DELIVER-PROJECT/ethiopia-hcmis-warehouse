﻿
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
    public abstract class _PurchaseOrderType : SqlClientEntity
    {
        public _PurchaseOrderType()
        {
            this.SchemaTableView = "Procurement].[";
            this.QuerySource = "PurchaseOrderType";
            this.MappingName = "PurchaseOrderType";

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

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_PurchaseOrderTypeLoadAll]", parameters);
        }

        //=================================================================
        // public Overridable Function LoadByPrimaryKey()  As Boolean
        //=================================================================
        //  Loads a single row of via the primary key
        //=================================================================
        public virtual bool LoadByPrimaryKey(int PurchaseOrderTypeID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.PurchaseOrderTypeID, PurchaseOrderTypeID);


            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "proc_PurchaseOrderTypeLoadByPrimaryKey]", parameters);
        }

        #region Parameters
        protected class Parameters
        {

            public static SqlParameter PurchaseOrderTypeID
            {
                get
                {
                    return new SqlParameter("@PurchaseOrderTypeID", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter Name
            {
                get
                {
                    return new SqlParameter("@Name", SqlDbType.NVarChar, 100);
                }
            }

            public static SqlParameter Description
            {
                get
                {
                    return new SqlParameter("@Description", SqlDbType.NVarChar, 400);
                }
            }

            public static SqlParameter ParentPurchaseOrderTypeID
            {
                get
                {
                    return new SqlParameter("@ParentPurchaseOrderTypeID", SqlDbType.Int, 0);
                }
            }

            public static SqlParameter IsActive
            {
                get
                {
                    return new SqlParameter("@IsActive", SqlDbType.Bit, 0);
                }
            }

            public static SqlParameter Rowguid
            {
                get
                {
                    return new SqlParameter("@Rowguid", SqlDbType.UniqueIdentifier, 0);
                }
            }

            public static SqlParameter ModifiedBy
            {
                get
                {
                    return new SqlParameter("@ModifiedBy", SqlDbType.NVarChar, 50);
                }
            }

            public static SqlParameter PurchaseOrderTypeCode
            {
                get
                {
                    return new SqlParameter("@PurchaseOrderTypeCode", SqlDbType.NVarChar, 5);
                }
            }

            public static SqlParameter SN
            {
                get
                {
                    return new SqlParameter("@SN", SqlDbType.Int, 0);
                }
            }

        }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public const string PurchaseOrderTypeID = "PurchaseOrderTypeID";
            public const string Name = "Name";
            public const string Description = "Description";
            public const string ParentPurchaseOrderTypeID = "ParentPurchaseOrderTypeID";
            public const string IsActive = "IsActive";
            public const string Rowguid = "rowguid";
            public const string ModifiedBy = "ModifiedBy";
            public const string PurchaseOrderTypeCode = "PurchaseOrderTypeCode";
            public const string SN = "SN";

            static public string ToPropertyName(string columnName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();

                    ht[PurchaseOrderTypeID] = _PurchaseOrderType.PropertyNames.PurchaseOrderTypeID;
                    ht[Name] = _PurchaseOrderType.PropertyNames.Name;
                    ht[Description] = _PurchaseOrderType.PropertyNames.Description;
                    ht[ParentPurchaseOrderTypeID] = _PurchaseOrderType.PropertyNames.ParentPurchaseOrderTypeID;
                    ht[IsActive] = _PurchaseOrderType.PropertyNames.IsActive;
                    ht[Rowguid] = _PurchaseOrderType.PropertyNames.Rowguid;
                    ht[ModifiedBy] = _PurchaseOrderType.PropertyNames.ModifiedBy;
                    ht[PurchaseOrderTypeCode] = _PurchaseOrderType.PropertyNames.PurchaseOrderTypeCode;
                    ht[SN] = _PurchaseOrderType.PropertyNames.SN;

                }
                return (string)ht[columnName];
            }

            static private Hashtable ht = null;
        }
        #endregion

        #region PropertyNames
        public class PropertyNames
        {
            public const string PurchaseOrderTypeID = "PurchaseOrderTypeID";
            public const string Name = "Name";
            public const string Description = "Description";
            public const string ParentPurchaseOrderTypeID = "ParentPurchaseOrderTypeID";
            public const string IsActive = "IsActive";
            public const string Rowguid = "Rowguid";
            public const string ModifiedBy = "ModifiedBy";
            public const string PurchaseOrderTypeCode = "PurchaseOrderTypeCode";
            public const string SN = "SN";

            static public string ToColumnName(string propertyName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();

                    ht[PurchaseOrderTypeID] = _PurchaseOrderType.ColumnNames.PurchaseOrderTypeID;
                    ht[Name] = _PurchaseOrderType.ColumnNames.Name;
                    ht[Description] = _PurchaseOrderType.ColumnNames.Description;
                    ht[ParentPurchaseOrderTypeID] = _PurchaseOrderType.ColumnNames.ParentPurchaseOrderTypeID;
                    ht[IsActive] = _PurchaseOrderType.ColumnNames.IsActive;
                    ht[Rowguid] = _PurchaseOrderType.ColumnNames.Rowguid;
                    ht[ModifiedBy] = _PurchaseOrderType.ColumnNames.ModifiedBy;
                    ht[PurchaseOrderTypeCode] = _PurchaseOrderType.ColumnNames.PurchaseOrderTypeCode;
                    ht[SN] = _PurchaseOrderType.ColumnNames.SN;

                }
                return (string)ht[propertyName];
            }

            static private Hashtable ht = null;
        }
        #endregion

        #region StringPropertyNames
        public class StringPropertyNames
        {
            public const string PurchaseOrderTypeID = "s_PurchaseOrderTypeID";
            public const string Name = "s_Name";
            public const string Description = "s_Description";
            public const string ParentPurchaseOrderTypeID = "s_ParentPurchaseOrderTypeID";
            public const string IsActive = "s_IsActive";
            public const string Rowguid = "s_Rowguid";
            public const string ModifiedBy = "s_ModifiedBy";
            public const string PurchaseOrderTypeCode = "s_PurchaseOrderTypeCode";
            public const string SN = "s_SN";

        }
        #endregion

        #region Properties

        public virtual int PurchaseOrderTypeID
        {
            get
            {
                return base.Getint(ColumnNames.PurchaseOrderTypeID);
            }
            set
            {
                base.Setint(ColumnNames.PurchaseOrderTypeID, value);
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

        public virtual int ParentPurchaseOrderTypeID
        {
            get
            {
                return base.Getint(ColumnNames.ParentPurchaseOrderTypeID);
            }
            set
            {
                base.Setint(ColumnNames.ParentPurchaseOrderTypeID, value);
            }
        }

        public virtual bool IsActive
        {
            get
            {
                return base.Getbool(ColumnNames.IsActive);
            }
            set
            {
                base.Setbool(ColumnNames.IsActive, value);
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

        public virtual string ModifiedBy
        {
            get
            {
                return base.Getstring(ColumnNames.ModifiedBy);
            }
            set
            {
                base.Setstring(ColumnNames.ModifiedBy, value);
            }
        }

        public virtual string PurchaseOrderTypeCode
        {
            get
            {
                return base.Getstring(ColumnNames.PurchaseOrderTypeCode);
            }
            set
            {
                base.Setstring(ColumnNames.PurchaseOrderTypeCode, value);
            }
        }

        public virtual int SN
        {
            get
            {
                return base.Getint(ColumnNames.SN);
            }
            set
            {
                base.Setint(ColumnNames.SN, value);
            }
        }


        #endregion

        #region String Properties

        public virtual string s_PurchaseOrderTypeID
        {
            get
            {
                return this.IsColumnNull(ColumnNames.PurchaseOrderTypeID) ? string.Empty : base.GetintAsString(ColumnNames.PurchaseOrderTypeID);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.PurchaseOrderTypeID);
                else
                    this.PurchaseOrderTypeID = base.SetintAsString(ColumnNames.PurchaseOrderTypeID, value);
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
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Name);
                else
                    this.Name = base.SetstringAsString(ColumnNames.Name, value);
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
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Description);
                else
                    this.Description = base.SetstringAsString(ColumnNames.Description, value);
            }
        }

        public virtual string s_ParentPurchaseOrderTypeID
        {
            get
            {
                return this.IsColumnNull(ColumnNames.ParentPurchaseOrderTypeID) ? string.Empty : base.GetintAsString(ColumnNames.ParentPurchaseOrderTypeID);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.ParentPurchaseOrderTypeID);
                else
                    this.ParentPurchaseOrderTypeID = base.SetintAsString(ColumnNames.ParentPurchaseOrderTypeID, value);
            }
        }

        public virtual string s_IsActive
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IsActive) ? string.Empty : base.GetboolAsString(ColumnNames.IsActive);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IsActive);
                else
                    this.IsActive = base.SetboolAsString(ColumnNames.IsActive, value);
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
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Rowguid);
                else
                    this.Rowguid = base.SetGuidAsString(ColumnNames.Rowguid, value);
            }
        }

        public virtual string s_ModifiedBy
        {
            get
            {
                return this.IsColumnNull(ColumnNames.ModifiedBy) ? string.Empty : base.GetstringAsString(ColumnNames.ModifiedBy);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.ModifiedBy);
                else
                    this.ModifiedBy = base.SetstringAsString(ColumnNames.ModifiedBy, value);
            }
        }

        public virtual string s_PurchaseOrderTypeCode
        {
            get
            {
                return this.IsColumnNull(ColumnNames.PurchaseOrderTypeCode) ? string.Empty : base.GetstringAsString(ColumnNames.PurchaseOrderTypeCode);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.PurchaseOrderTypeCode);
                else
                    this.PurchaseOrderTypeCode = base.SetstringAsString(ColumnNames.PurchaseOrderTypeCode, value);
            }
        }

        public virtual string s_SN
        {
            get
            {
                return this.IsColumnNull(ColumnNames.SN) ? string.Empty : base.GetintAsString(ColumnNames.SN);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.SN);
                else
                    this.SN = base.SetintAsString(ColumnNames.SN, value);
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
                    if (_tearOff == null)
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


                public WhereParameter PurchaseOrderTypeID
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.PurchaseOrderTypeID, Parameters.PurchaseOrderTypeID);
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

                public WhereParameter Description
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Description, Parameters.Description);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter ParentPurchaseOrderTypeID
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.ParentPurchaseOrderTypeID, Parameters.ParentPurchaseOrderTypeID);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter IsActive
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IsActive, Parameters.IsActive);
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

                public WhereParameter ModifiedBy
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.ModifiedBy, Parameters.ModifiedBy);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter PurchaseOrderTypeCode
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.PurchaseOrderTypeCode, Parameters.PurchaseOrderTypeCode);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter SN
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.SN, Parameters.SN);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }


                private WhereClause _clause;
            }
            #endregion

            public WhereParameter PurchaseOrderTypeID
            {
                get
                {
                    if (_PurchaseOrderTypeID_W == null)
                    {
                        _PurchaseOrderTypeID_W = TearOff.PurchaseOrderTypeID;
                    }
                    return _PurchaseOrderTypeID_W;
                }
            }

            public WhereParameter Name
            {
                get
                {
                    if (_Name_W == null)
                    {
                        _Name_W = TearOff.Name;
                    }
                    return _Name_W;
                }
            }

            public WhereParameter Description
            {
                get
                {
                    if (_Description_W == null)
                    {
                        _Description_W = TearOff.Description;
                    }
                    return _Description_W;
                }
            }

            public WhereParameter ParentPurchaseOrderTypeID
            {
                get
                {
                    if (_ParentPurchaseOrderTypeID_W == null)
                    {
                        _ParentPurchaseOrderTypeID_W = TearOff.ParentPurchaseOrderTypeID;
                    }
                    return _ParentPurchaseOrderTypeID_W;
                }
            }

            public WhereParameter IsActive
            {
                get
                {
                    if (_IsActive_W == null)
                    {
                        _IsActive_W = TearOff.IsActive;
                    }
                    return _IsActive_W;
                }
            }

            public WhereParameter Rowguid
            {
                get
                {
                    if (_Rowguid_W == null)
                    {
                        _Rowguid_W = TearOff.Rowguid;
                    }
                    return _Rowguid_W;
                }
            }

            public WhereParameter ModifiedBy
            {
                get
                {
                    if (_ModifiedBy_W == null)
                    {
                        _ModifiedBy_W = TearOff.ModifiedBy;
                    }
                    return _ModifiedBy_W;
                }
            }

            public WhereParameter PurchaseOrderTypeCode
            {
                get
                {
                    if (_PurchaseOrderTypeCode_W == null)
                    {
                        _PurchaseOrderTypeCode_W = TearOff.PurchaseOrderTypeCode;
                    }
                    return _PurchaseOrderTypeCode_W;
                }
            }

            public WhereParameter SN
            {
                get
                {
                    if (_SN_W == null)
                    {
                        _SN_W = TearOff.SN;
                    }
                    return _SN_W;
                }
            }

            private WhereParameter _PurchaseOrderTypeID_W = null;
            private WhereParameter _Name_W = null;
            private WhereParameter _Description_W = null;
            private WhereParameter _ParentPurchaseOrderTypeID_W = null;
            private WhereParameter _IsActive_W = null;
            private WhereParameter _Rowguid_W = null;
            private WhereParameter _ModifiedBy_W = null;
            private WhereParameter _PurchaseOrderTypeCode_W = null;
            private WhereParameter _SN_W = null;

            public void WhereClauseReset()
            {
                _PurchaseOrderTypeID_W = null;
                _Name_W = null;
                _Description_W = null;
                _ParentPurchaseOrderTypeID_W = null;
                _IsActive_W = null;
                _Rowguid_W = null;
                _ModifiedBy_W = null;
                _PurchaseOrderTypeCode_W = null;
                _SN_W = null;

                this._entity.Query.FlushWhereParameters();

            }

            private BusinessEntity _entity;
            private TearOffWhereParameter _tearOff;

        }

        public WhereClause Where
        {
            get
            {
                if (_whereClause == null)
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
                    if (_tearOff == null)
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


                public AggregateParameter PurchaseOrderTypeID
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.PurchaseOrderTypeID, Parameters.PurchaseOrderTypeID);
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

                public AggregateParameter Description
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Description, Parameters.Description);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter ParentPurchaseOrderTypeID
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.ParentPurchaseOrderTypeID, Parameters.ParentPurchaseOrderTypeID);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter IsActive
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IsActive, Parameters.IsActive);
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

                public AggregateParameter ModifiedBy
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.ModifiedBy, Parameters.ModifiedBy);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter PurchaseOrderTypeCode
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.PurchaseOrderTypeCode, Parameters.PurchaseOrderTypeCode);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter SN
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.SN, Parameters.SN);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }


                private AggregateClause _clause;
            }
            #endregion

            public AggregateParameter PurchaseOrderTypeID
            {
                get
                {
                    if (_PurchaseOrderTypeID_W == null)
                    {
                        _PurchaseOrderTypeID_W = TearOff.PurchaseOrderTypeID;
                    }
                    return _PurchaseOrderTypeID_W;
                }
            }

            public AggregateParameter Name
            {
                get
                {
                    if (_Name_W == null)
                    {
                        _Name_W = TearOff.Name;
                    }
                    return _Name_W;
                }
            }

            public AggregateParameter Description
            {
                get
                {
                    if (_Description_W == null)
                    {
                        _Description_W = TearOff.Description;
                    }
                    return _Description_W;
                }
            }

            public AggregateParameter ParentPurchaseOrderTypeID
            {
                get
                {
                    if (_ParentPurchaseOrderTypeID_W == null)
                    {
                        _ParentPurchaseOrderTypeID_W = TearOff.ParentPurchaseOrderTypeID;
                    }
                    return _ParentPurchaseOrderTypeID_W;
                }
            }

            public AggregateParameter IsActive
            {
                get
                {
                    if (_IsActive_W == null)
                    {
                        _IsActive_W = TearOff.IsActive;
                    }
                    return _IsActive_W;
                }
            }

            public AggregateParameter Rowguid
            {
                get
                {
                    if (_Rowguid_W == null)
                    {
                        _Rowguid_W = TearOff.Rowguid;
                    }
                    return _Rowguid_W;
                }
            }

            public AggregateParameter ModifiedBy
            {
                get
                {
                    if (_ModifiedBy_W == null)
                    {
                        _ModifiedBy_W = TearOff.ModifiedBy;
                    }
                    return _ModifiedBy_W;
                }
            }

            public AggregateParameter PurchaseOrderTypeCode
            {
                get
                {
                    if (_PurchaseOrderTypeCode_W == null)
                    {
                        _PurchaseOrderTypeCode_W = TearOff.PurchaseOrderTypeCode;
                    }
                    return _PurchaseOrderTypeCode_W;
                }
            }

            public AggregateParameter SN
            {
                get
                {
                    if (_SN_W == null)
                    {
                        _SN_W = TearOff.SN;
                    }
                    return _SN_W;
                }
            }

            private AggregateParameter _PurchaseOrderTypeID_W = null;
            private AggregateParameter _Name_W = null;
            private AggregateParameter _Description_W = null;
            private AggregateParameter _ParentPurchaseOrderTypeID_W = null;
            private AggregateParameter _IsActive_W = null;
            private AggregateParameter _Rowguid_W = null;
            private AggregateParameter _ModifiedBy_W = null;
            private AggregateParameter _PurchaseOrderTypeCode_W = null;
            private AggregateParameter _SN_W = null;

            public void AggregateClauseReset()
            {
                _PurchaseOrderTypeID_W = null;
                _Name_W = null;
                _Description_W = null;
                _ParentPurchaseOrderTypeID_W = null;
                _IsActive_W = null;
                _Rowguid_W = null;
                _ModifiedBy_W = null;
                _PurchaseOrderTypeCode_W = null;
                _SN_W = null;

                this._entity.Query.FlushAggregateParameters();

            }

            private BusinessEntity _entity;
            private TearOffAggregateParameter _tearOff;

        }

        public AggregateClause Aggregate
        {
            get
            {
                if (_aggregateClause == null)
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
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_PurchaseOrderTypeInsert]";

            CreateParameters(cmd);

            SqlParameter p;
            p = cmd.Parameters[Parameters.PurchaseOrderTypeID.ParameterName];
            p.Direction = ParameterDirection.Output;

            return cmd;
        }

        protected override IDbCommand GetUpdateCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_PurchaseOrderTypeUpdate]";

            CreateParameters(cmd);

            return cmd;
        }

        protected override IDbCommand GetDeleteCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "proc_PurchaseOrderTypeDelete]";

            SqlParameter p;
            p = cmd.Parameters.Add(Parameters.PurchaseOrderTypeID);
            p.SourceColumn = ColumnNames.PurchaseOrderTypeID;
            p.SourceVersion = DataRowVersion.Current;


            return cmd;
        }

        private IDbCommand CreateParameters(SqlCommand cmd)
        {
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.PurchaseOrderTypeID);
            p.SourceColumn = ColumnNames.PurchaseOrderTypeID;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Name);
            p.SourceColumn = ColumnNames.Name;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Description);
            p.SourceColumn = ColumnNames.Description;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.ParentPurchaseOrderTypeID);
            p.SourceColumn = ColumnNames.ParentPurchaseOrderTypeID;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IsActive);
            p.SourceColumn = ColumnNames.IsActive;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Rowguid);
            p.SourceColumn = ColumnNames.Rowguid;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.ModifiedBy);
            p.SourceColumn = ColumnNames.ModifiedBy;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.PurchaseOrderTypeCode);
            p.SourceColumn = ColumnNames.PurchaseOrderTypeCode;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.SN);
            p.SourceColumn = ColumnNames.SN;
            p.SourceVersion = DataRowVersion.Current;


            return cmd;
        }
    }
}


