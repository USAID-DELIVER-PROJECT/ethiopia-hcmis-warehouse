﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCMIS.Desktop.GeneralLookups {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Region", Namespace="http://ds.pfsa.org/")]
    [System.SerializableAttribute()]
    public partial class Region : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Nullable<int> IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RegionNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RegionCodeField;
        
        private System.Nullable<bool> IsDeletedField;
        
        private System.Nullable<System.DateTime> UpdateTimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Nullable<int> ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string RegionName {
            get {
                return this.RegionNameField;
            }
            set {
                if ((object.ReferenceEquals(this.RegionNameField, value) != true)) {
                    this.RegionNameField = value;
                    this.RaisePropertyChanged("RegionName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string RegionCode {
            get {
                return this.RegionCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.RegionCodeField, value) != true)) {
                    this.RegionCodeField = value;
                    this.RaisePropertyChanged("RegionCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public System.Nullable<bool> IsDeleted {
            get {
                return this.IsDeletedField;
            }
            set {
                if ((this.IsDeletedField.Equals(value) != true)) {
                    this.IsDeletedField = value;
                    this.RaisePropertyChanged("IsDeleted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.Nullable<System.DateTime> UpdateTime {
            get {
                return this.UpdateTimeField;
            }
            set {
                if ((this.UpdateTimeField.Equals(value) != true)) {
                    this.UpdateTimeField = value;
                    this.RaisePropertyChanged("UpdateTime");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfZone", Namespace="http://ds.pfsa.org/", ItemName="zone")]
    [System.SerializableAttribute()]
    public class ArrayOfZone : System.Collections.Generic.List<HCMIS.Desktop.GeneralLookups.zone> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="zone", Namespace="http://ds.pfsa.org/")]
    [System.SerializableAttribute()]
    public partial class zone : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Nullable<int> IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ZoneNameField;
        
        private System.Nullable<int> RegionIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ZoneCodeField;
        
        private System.Nullable<bool> IsDeletedField;
        
        private System.Nullable<System.DateTime> UpdateTimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Nullable<int> ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ZoneName {
            get {
                return this.ZoneNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ZoneNameField, value) != true)) {
                    this.ZoneNameField = value;
                    this.RaisePropertyChanged("ZoneName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public System.Nullable<int> RegionId {
            get {
                return this.RegionIdField;
            }
            set {
                if ((this.RegionIdField.Equals(value) != true)) {
                    this.RegionIdField = value;
                    this.RaisePropertyChanged("RegionId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string ZoneCode {
            get {
                return this.ZoneCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ZoneCodeField, value) != true)) {
                    this.ZoneCodeField = value;
                    this.RaisePropertyChanged("ZoneCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.Nullable<bool> IsDeleted {
            get {
                return this.IsDeletedField;
            }
            set {
                if ((this.IsDeletedField.Equals(value) != true)) {
                    this.IsDeletedField = value;
                    this.RaisePropertyChanged("IsDeleted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public System.Nullable<System.DateTime> UpdateTime {
            get {
                return this.UpdateTimeField;
            }
            set {
                if ((this.UpdateTimeField.Equals(value) != true)) {
                    this.UpdateTimeField = value;
                    this.RaisePropertyChanged("UpdateTime");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Woreda", Namespace="http://ds.pfsa.org/")]
    [System.SerializableAttribute()]
    public partial class Woreda : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Nullable<int> IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WoredaNameField;
        
        private System.Nullable<int> ZoneIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WoredaCodeField;
        
        private System.Nullable<bool> IsDeletedField;
        
        private System.Nullable<System.DateTime> UpdateTimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Nullable<int> ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string WoredaName {
            get {
                return this.WoredaNameField;
            }
            set {
                if ((object.ReferenceEquals(this.WoredaNameField, value) != true)) {
                    this.WoredaNameField = value;
                    this.RaisePropertyChanged("WoredaName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Nullable<int> ZoneID {
            get {
                return this.ZoneIDField;
            }
            set {
                if ((this.ZoneIDField.Equals(value) != true)) {
                    this.ZoneIDField = value;
                    this.RaisePropertyChanged("ZoneID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string WoredaCode {
            get {
                return this.WoredaCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.WoredaCodeField, value) != true)) {
                    this.WoredaCodeField = value;
                    this.RaisePropertyChanged("WoredaCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.Nullable<bool> IsDeleted {
            get {
                return this.IsDeletedField;
            }
            set {
                if ((this.IsDeletedField.Equals(value) != true)) {
                    this.IsDeletedField = value;
                    this.RaisePropertyChanged("IsDeleted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public System.Nullable<System.DateTime> UpdateTime {
            get {
                return this.UpdateTimeField;
            }
            set {
                if ((this.UpdateTimeField.Equals(value) != true)) {
                    this.UpdateTimeField = value;
                    this.RaisePropertyChanged("UpdateTime");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ds.pfsa.org/", ConfigurationName="GeneralLookups.Service1Soap")]
    public interface Service1Soap {
        
        // CODEGEN: Generating message contract since element name userName from namespace http://ds.pfsa.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://ds.pfsa.org/GetLastVersion", ReplyAction="*")]
        HCMIS.Desktop.GeneralLookups.GetLastVersionResponse GetLastVersion(HCMIS.Desktop.GeneralLookups.GetLastVersionRequest request);
        
        // CODEGEN: Generating message contract since element name userName from namespace http://ds.pfsa.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://ds.pfsa.org/GetRegions", ReplyAction="*")]
        HCMIS.Desktop.GeneralLookups.GetRegionsResponse GetRegions(HCMIS.Desktop.GeneralLookups.GetRegionsRequest request);
        
        // CODEGEN: Generating message contract since element name userName from namespace http://ds.pfsa.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://ds.pfsa.org/GetZones", ReplyAction="*")]
        HCMIS.Desktop.GeneralLookups.GetZonesResponse GetZones(HCMIS.Desktop.GeneralLookups.GetZonesRequest request);
        
        // CODEGEN: Generating message contract since element name userName from namespace http://ds.pfsa.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://ds.pfsa.org/GetWoredas", ReplyAction="*")]
        HCMIS.Desktop.GeneralLookups.GetWoredasResponse GetWoredas(HCMIS.Desktop.GeneralLookups.GetWoredasRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetLastVersionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetLastVersion", Namespace="http://ds.pfsa.org/", Order=0)]
        public HCMIS.Desktop.GeneralLookups.GetLastVersionRequestBody Body;
        
        public GetLastVersionRequest() {
        }
        
        public GetLastVersionRequest(HCMIS.Desktop.GeneralLookups.GetLastVersionRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ds.pfsa.org/")]
    public partial class GetLastVersionRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string password;
        
        public GetLastVersionRequestBody() {
        }
        
        public GetLastVersionRequestBody(string userName, string password) {
            this.userName = userName;
            this.password = password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetLastVersionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetLastVersionResponse", Namespace="http://ds.pfsa.org/", Order=0)]
        public HCMIS.Desktop.GeneralLookups.GetLastVersionResponseBody Body;
        
        public GetLastVersionResponse() {
        }
        
        public GetLastVersionResponse(HCMIS.Desktop.GeneralLookups.GetLastVersionResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ds.pfsa.org/")]
    public partial class GetLastVersionResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long GetLastVersionResult;
        
        public GetLastVersionResponseBody() {
        }
        
        public GetLastVersionResponseBody(long GetLastVersionResult) {
            this.GetLastVersionResult = GetLastVersionResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetRegionsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetRegions", Namespace="http://ds.pfsa.org/", Order=0)]
        public HCMIS.Desktop.GeneralLookups.GetRegionsRequestBody Body;
        
        public GetRegionsRequest() {
        }
        
        public GetRegionsRequest(HCMIS.Desktop.GeneralLookups.GetRegionsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ds.pfsa.org/")]
    public partial class GetRegionsRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string password;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public System.Nullable<int> lastVersion;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public System.Nullable<System.DateTime> lastDateTime;
        
        public GetRegionsRequestBody() {
        }
        
        public GetRegionsRequestBody(string userName, string password, System.Nullable<int> lastVersion, System.Nullable<System.DateTime> lastDateTime) {
            this.userName = userName;
            this.password = password;
            this.lastVersion = lastVersion;
            this.lastDateTime = lastDateTime;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetRegionsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetRegionsResponse", Namespace="http://ds.pfsa.org/", Order=0)]
        public HCMIS.Desktop.GeneralLookups.GetRegionsResponseBody Body;
        
        public GetRegionsResponse() {
        }
        
        public GetRegionsResponse(HCMIS.Desktop.GeneralLookups.GetRegionsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ds.pfsa.org/")]
    public partial class GetRegionsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<HCMIS.Desktop.GeneralLookups.Region> GetRegionsResult;
        
        public GetRegionsResponseBody() {
        }
        
        public GetRegionsResponseBody(System.Collections.Generic.List<HCMIS.Desktop.GeneralLookups.Region> GetRegionsResult) {
            this.GetRegionsResult = GetRegionsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetZonesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetZones", Namespace="http://ds.pfsa.org/", Order=0)]
        public HCMIS.Desktop.GeneralLookups.GetZonesRequestBody Body;
        
        public GetZonesRequest() {
        }
        
        public GetZonesRequest(HCMIS.Desktop.GeneralLookups.GetZonesRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ds.pfsa.org/")]
    public partial class GetZonesRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string password;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public System.Nullable<int> lastVersion;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public System.Nullable<System.DateTime> lastDateTime;
        
        public GetZonesRequestBody() {
        }
        
        public GetZonesRequestBody(string userName, string password, System.Nullable<int> lastVersion, System.Nullable<System.DateTime> lastDateTime) {
            this.userName = userName;
            this.password = password;
            this.lastVersion = lastVersion;
            this.lastDateTime = lastDateTime;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetZonesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetZonesResponse", Namespace="http://ds.pfsa.org/", Order=0)]
        public HCMIS.Desktop.GeneralLookups.GetZonesResponseBody Body;
        
        public GetZonesResponse() {
        }
        
        public GetZonesResponse(HCMIS.Desktop.GeneralLookups.GetZonesResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ds.pfsa.org/")]
    public partial class GetZonesResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public HCMIS.Desktop.GeneralLookups.ArrayOfZone GetZonesResult;
        
        public GetZonesResponseBody() {
        }
        
        public GetZonesResponseBody(HCMIS.Desktop.GeneralLookups.ArrayOfZone GetZonesResult) {
            this.GetZonesResult = GetZonesResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWoredasRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWoredas", Namespace="http://ds.pfsa.org/", Order=0)]
        public HCMIS.Desktop.GeneralLookups.GetWoredasRequestBody Body;
        
        public GetWoredasRequest() {
        }
        
        public GetWoredasRequest(HCMIS.Desktop.GeneralLookups.GetWoredasRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ds.pfsa.org/")]
    public partial class GetWoredasRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string password;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public System.Nullable<int> lastVersion;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public System.Nullable<System.DateTime> lastDateTime;
        
        public GetWoredasRequestBody() {
        }
        
        public GetWoredasRequestBody(string userName, string password, System.Nullable<int> lastVersion, System.Nullable<System.DateTime> lastDateTime) {
            this.userName = userName;
            this.password = password;
            this.lastVersion = lastVersion;
            this.lastDateTime = lastDateTime;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWoredasResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWoredasResponse", Namespace="http://ds.pfsa.org/", Order=0)]
        public HCMIS.Desktop.GeneralLookups.GetWoredasResponseBody Body;
        
        public GetWoredasResponse() {
        }
        
        public GetWoredasResponse(HCMIS.Desktop.GeneralLookups.GetWoredasResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://ds.pfsa.org/")]
    public partial class GetWoredasResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Collections.Generic.List<HCMIS.Desktop.GeneralLookups.Woreda> GetWoredasResult;
        
        public GetWoredasResponseBody() {
        }
        
        public GetWoredasResponseBody(System.Collections.Generic.List<HCMIS.Desktop.GeneralLookups.Woreda> GetWoredasResult) {
            this.GetWoredasResult = GetWoredasResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Service1SoapChannel : HCMIS.Desktop.GeneralLookups.Service1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1SoapClient : System.ServiceModel.ClientBase<HCMIS.Desktop.GeneralLookups.Service1Soap>, HCMIS.Desktop.GeneralLookups.Service1Soap {
        
        public Service1SoapClient() {
        }
        
        public Service1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCMIS.Desktop.GeneralLookups.GetLastVersionResponse HCMIS.Desktop.GeneralLookups.Service1Soap.GetLastVersion(HCMIS.Desktop.GeneralLookups.GetLastVersionRequest request) {
            return base.Channel.GetLastVersion(request);
        }
        
        public long GetLastVersion(string userName, string password) {
            HCMIS.Desktop.GeneralLookups.GetLastVersionRequest inValue = new HCMIS.Desktop.GeneralLookups.GetLastVersionRequest();
            inValue.Body = new HCMIS.Desktop.GeneralLookups.GetLastVersionRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            HCMIS.Desktop.GeneralLookups.GetLastVersionResponse retVal = ((HCMIS.Desktop.GeneralLookups.Service1Soap)(this)).GetLastVersion(inValue);
            return retVal.Body.GetLastVersionResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCMIS.Desktop.GeneralLookups.GetRegionsResponse HCMIS.Desktop.GeneralLookups.Service1Soap.GetRegions(HCMIS.Desktop.GeneralLookups.GetRegionsRequest request) {
            return base.Channel.GetRegions(request);
        }
        
        public System.Collections.Generic.List<HCMIS.Desktop.GeneralLookups.Region> GetRegions(string userName, string password, System.Nullable<int> lastVersion, System.Nullable<System.DateTime> lastDateTime) {
            HCMIS.Desktop.GeneralLookups.GetRegionsRequest inValue = new HCMIS.Desktop.GeneralLookups.GetRegionsRequest();
            inValue.Body = new HCMIS.Desktop.GeneralLookups.GetRegionsRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            inValue.Body.lastVersion = lastVersion;
            inValue.Body.lastDateTime = lastDateTime;
            HCMIS.Desktop.GeneralLookups.GetRegionsResponse retVal = ((HCMIS.Desktop.GeneralLookups.Service1Soap)(this)).GetRegions(inValue);
            return retVal.Body.GetRegionsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCMIS.Desktop.GeneralLookups.GetZonesResponse HCMIS.Desktop.GeneralLookups.Service1Soap.GetZones(HCMIS.Desktop.GeneralLookups.GetZonesRequest request) {
            return base.Channel.GetZones(request);
        }
        
        public HCMIS.Desktop.GeneralLookups.ArrayOfZone GetZones(string userName, string password, System.Nullable<int> lastVersion, System.Nullable<System.DateTime> lastDateTime) {
            HCMIS.Desktop.GeneralLookups.GetZonesRequest inValue = new HCMIS.Desktop.GeneralLookups.GetZonesRequest();
            inValue.Body = new HCMIS.Desktop.GeneralLookups.GetZonesRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            inValue.Body.lastVersion = lastVersion;
            inValue.Body.lastDateTime = lastDateTime;
            HCMIS.Desktop.GeneralLookups.GetZonesResponse retVal = ((HCMIS.Desktop.GeneralLookups.Service1Soap)(this)).GetZones(inValue);
            return retVal.Body.GetZonesResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HCMIS.Desktop.GeneralLookups.GetWoredasResponse HCMIS.Desktop.GeneralLookups.Service1Soap.GetWoredas(HCMIS.Desktop.GeneralLookups.GetWoredasRequest request) {
            return base.Channel.GetWoredas(request);
        }
        
        public System.Collections.Generic.List<HCMIS.Desktop.GeneralLookups.Woreda> GetWoredas(string userName, string password, System.Nullable<int> lastVersion, System.Nullable<System.DateTime> lastDateTime) {
            HCMIS.Desktop.GeneralLookups.GetWoredasRequest inValue = new HCMIS.Desktop.GeneralLookups.GetWoredasRequest();
            inValue.Body = new HCMIS.Desktop.GeneralLookups.GetWoredasRequestBody();
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            inValue.Body.lastVersion = lastVersion;
            inValue.Body.lastDateTime = lastDateTime;
            HCMIS.Desktop.GeneralLookups.GetWoredasResponse retVal = ((HCMIS.Desktop.GeneralLookups.Service1Soap)(this)).GetWoredas(inValue);
            return retVal.Body.GetWoredasResult;
        }
    }
}
