﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeFixtures.EmployeeServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EmpIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmpNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private EmployeeFixtures.EmployeeServiceReference.Remarks RemarkField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EmpId {
            get {
                return this.EmpIdField;
            }
            set {
                if ((this.EmpIdField.Equals(value) != true)) {
                    this.EmpIdField = value;
                    this.RaisePropertyChanged("EmpId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EmpName {
            get {
                return this.EmpNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EmpNameField, value) != true)) {
                    this.EmpNameField = value;
                    this.RaisePropertyChanged("EmpName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public EmployeeFixtures.EmployeeServiceReference.Remarks Remark {
            get {
                return this.RemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkField, value) != true)) {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Remarks", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
    [System.SerializableAttribute()]
    public partial class Remarks : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime RemarkTimestampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime RemarkTimestamp {
            get {
                return this.RemarkTimestampField;
            }
            set {
                if ((this.RemarkTimestampField.Equals(value) != true)) {
                    this.RemarkTimestampField = value;
                    this.RaisePropertyChanged("RemarkTimestamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeServiceReference.ICreateOrModifyEmployee")]
    public interface ICreateOrModifyEmployee {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateOrModifyEmployee/CreateEmployee", ReplyAction="http://tempuri.org/ICreateOrModifyEmployee/CreateEmployeeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/ICreateOrModifyEmployee/CreateEmployeeFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        EmployeeFixtures.EmployeeServiceReference.Employee CreateEmployee(int id, string name, string remarks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateOrModifyEmployee/CreateEmployee", ReplyAction="http://tempuri.org/ICreateOrModifyEmployee/CreateEmployeeResponse")]
        System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee> CreateEmployeeAsync(int id, string name, string remarks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateOrModifyEmployee/AddRemarks", ReplyAction="http://tempuri.org/ICreateOrModifyEmployee/AddRemarksResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/ICreateOrModifyEmployee/AddRemarksFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        void AddRemarks(int id, string remarks);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICreateOrModifyEmployee/AddRemarks", ReplyAction="http://tempuri.org/ICreateOrModifyEmployee/AddRemarksResponse")]
        System.Threading.Tasks.Task AddRemarksAsync(int id, string remarks);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICreateOrModifyEmployeeChannel : EmployeeFixtures.EmployeeServiceReference.ICreateOrModifyEmployee, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateOrModifyEmployeeClient : System.ServiceModel.ClientBase<EmployeeFixtures.EmployeeServiceReference.ICreateOrModifyEmployee>, EmployeeFixtures.EmployeeServiceReference.ICreateOrModifyEmployee {
        
        public CreateOrModifyEmployeeClient() {
        }
        
        public CreateOrModifyEmployeeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CreateOrModifyEmployeeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateOrModifyEmployeeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CreateOrModifyEmployeeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EmployeeFixtures.EmployeeServiceReference.Employee CreateEmployee(int id, string name, string remarks) {
            return base.Channel.CreateEmployee(id, name, remarks);
        }
        
        public System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee> CreateEmployeeAsync(int id, string name, string remarks) {
            return base.Channel.CreateEmployeeAsync(id, name, remarks);
        }
        
        public void AddRemarks(int id, string remarks) {
            base.Channel.AddRemarks(id, remarks);
        }
        
        public System.Threading.Tasks.Task AddRemarksAsync(int id, string remarks) {
            return base.Channel.AddRemarksAsync(id, remarks);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeServiceReference.IRetrieveEmpDetails")]
    public interface IRetrieveEmpDetails {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmpDetails/GetEmployeeDetailsById", ReplyAction="http://tempuri.org/IRetrieveEmpDetails/GetEmployeeDetailsByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IRetrieveEmpDetails/GetEmployeeDetailsByIdFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        EmployeeFixtures.EmployeeServiceReference.Employee GetEmployeeDetailsById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmpDetails/GetEmployeeDetailsById", ReplyAction="http://tempuri.org/IRetrieveEmpDetails/GetEmployeeDetailsByIdResponse")]
        System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee> GetEmployeeDetailsByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmpDetails/GetAllEmployeeList", ReplyAction="http://tempuri.org/IRetrieveEmpDetails/GetAllEmployeeListResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IRetrieveEmpDetails/GetAllEmployeeListFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        EmployeeFixtures.EmployeeServiceReference.Employee[] GetAllEmployeeList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmpDetails/GetAllEmployeeList", ReplyAction="http://tempuri.org/IRetrieveEmpDetails/GetAllEmployeeListResponse")]
        System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee[]> GetAllEmployeeListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmpDetails/GetEmployeeDetailsByName", ReplyAction="http://tempuri.org/IRetrieveEmpDetails/GetEmployeeDetailsByNameResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IRetrieveEmpDetails/GetEmployeeDetailsByNameFaultExceptionFaul" +
            "t", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        EmployeeFixtures.EmployeeServiceReference.Employee GetEmployeeDetailsByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRetrieveEmpDetails/GetEmployeeDetailsByName", ReplyAction="http://tempuri.org/IRetrieveEmpDetails/GetEmployeeDetailsByNameResponse")]
        System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee> GetEmployeeDetailsByNameAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRetrieveEmpDetailsChannel : EmployeeFixtures.EmployeeServiceReference.IRetrieveEmpDetails, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RetrieveEmpDetailsClient : System.ServiceModel.ClientBase<EmployeeFixtures.EmployeeServiceReference.IRetrieveEmpDetails>, EmployeeFixtures.EmployeeServiceReference.IRetrieveEmpDetails {
        
        public RetrieveEmpDetailsClient() {
        }
        
        public RetrieveEmpDetailsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RetrieveEmpDetailsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RetrieveEmpDetailsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RetrieveEmpDetailsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EmployeeFixtures.EmployeeServiceReference.Employee GetEmployeeDetailsById(int id) {
            return base.Channel.GetEmployeeDetailsById(id);
        }
        
        public System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee> GetEmployeeDetailsByIdAsync(int id) {
            return base.Channel.GetEmployeeDetailsByIdAsync(id);
        }
        
        public EmployeeFixtures.EmployeeServiceReference.Employee[] GetAllEmployeeList() {
            return base.Channel.GetAllEmployeeList();
        }
        
        public System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee[]> GetAllEmployeeListAsync() {
            return base.Channel.GetAllEmployeeListAsync();
        }
        
        public EmployeeFixtures.EmployeeServiceReference.Employee GetEmployeeDetailsByName(string name) {
            return base.Channel.GetEmployeeDetailsByName(name);
        }
        
        public System.Threading.Tasks.Task<EmployeeFixtures.EmployeeServiceReference.Employee> GetEmployeeDetailsByNameAsync(string name) {
            return base.Channel.GetEmployeeDetailsByNameAsync(name);
        }
    }
}
