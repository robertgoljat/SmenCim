namespace CIM.GetComModuleConfig {
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;


    /// <remarks/>
    [DataContract()]
    public class GetComModuleConfigRequestMessageType : IGetRequestMessageType<GetComModuleConfigRequestType, ComModuleConfigPayloadType>
    {

        private HeaderType headerField;

        private GetComModuleConfigRequestType requestField;

        private ComModuleConfigPayloadType payloadField;

        /// <remarks/>
        [DataMember()]
        public HeaderType Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public GetComModuleConfigRequestType Request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public ComModuleConfigPayloadType Payload
        {
            get
            {
                return this.payloadField;
            }
            set
            {
                this.payloadField = value;
            }
        }
    }

    ///// <remarks/>
    //[DataContract()]
    //public class HeaderType {

    //    private HeaderTypeVerb verbField;

    //    private string nounField;

    //    private string revisionField;

    //    private ReplayDetectionType replayDetectionField;

    //    private HeaderTypeContext contextField;

    //    private bool contextFieldSpecified;

    //    private System.DateTime timestampField;

    //    private bool timestampFieldSpecified;

    //    private string sourceField;

    //    private bool asyncReplyFlagField;

    //    private bool asyncReplyFlagFieldSpecified;

    //    private string replyAddressField;

    //    private bool ackRequiredField;

    //    private bool ackRequiredFieldSpecified;

    //    private UserType userField;

    //    private string messageIDField;

    //    private string correlationIDField;

    //    private string commentField;

    //    private MessageProperty[] propertyField;

    //    private System.Xml.XmlElement[] anyField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public HeaderTypeVerb Verb {
    //        get {
    //            return this.verbField;
    //        }
    //        set {
    //            this.verbField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string Noun {
    //        get {
    //            return this.nounField;
    //        }
    //        set {
    //            this.nounField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string Revision {
    //        get {
    //            return this.revisionField;
    //        }
    //        set {
    //            this.revisionField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public ReplayDetectionType ReplayDetection {
    //        get {
    //            return this.replayDetectionField;
    //        }
    //        set {
    //            this.replayDetectionField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public HeaderTypeContext Context {
    //        get {
    //            return this.contextField;
    //        }
    //        set {
    //            this.contextField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool ContextSpecified {
    //        get {
    //            return this.contextFieldSpecified;
    //        }
    //        set {
    //            this.contextFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public System.DateTime Timestamp {
    //        get {
    //            return this.timestampField;
    //        }
    //        set {
    //            this.timestampField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool TimestampSpecified {
    //        get {
    //            return this.timestampFieldSpecified;
    //        }
    //        set {
    //            this.timestampFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string Source {
    //        get {
    //            return this.sourceField;
    //        }
    //        set {
    //            this.sourceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool AsyncReplyFlag {
    //        get {
    //            return this.asyncReplyFlagField;
    //        }
    //        set {
    //            this.asyncReplyFlagField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool AsyncReplyFlagSpecified {
    //        get {
    //            return this.asyncReplyFlagFieldSpecified;
    //        }
    //        set {
    //            this.asyncReplyFlagFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string ReplyAddress {
    //        get {
    //            return this.replyAddressField;
    //        }
    //        set {
    //            this.replyAddressField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool AckRequired {
    //        get {
    //            return this.ackRequiredField;
    //        }
    //        set {
    //            this.ackRequiredField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool AckRequiredSpecified {
    //        get {
    //            return this.ackRequiredFieldSpecified;
    //        }
    //        set {
    //            this.ackRequiredFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public UserType User {
    //        get {
    //            return this.userField;
    //        }
    //        set {
    //            this.userField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string MessageID {
    //        get {
    //            return this.messageIDField;
    //        }
    //        set {
    //            this.messageIDField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string CorrelationID {
    //        get {
    //            return this.correlationIDField;
    //        }
    //        set {
    //            this.correlationIDField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string Comment {
    //        get {
    //            return this.commentField;
    //        }
    //        set {
    //            this.commentField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public MessageProperty[] Property {
    //        get {
    //            return this.propertyField;
    //        }
    //        set {
    //            this.propertyField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public System.Xml.XmlElement[] Any {
    //        get {
    //            return this.anyField;
    //        }
    //        set {
    //            this.anyField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public enum HeaderTypeVerb {

    //    /// <remarks/>
    //    [EnumMember()]
    //    cancel,

    //    /// <remarks/>
    //    [EnumMember()]
    //    canceled,

    //    /// <remarks/>
    //    [EnumMember()]
    //    change,

    //    /// <remarks/>
    //    [EnumMember()]
    //    changed,

    //    /// <remarks/>
    //    [EnumMember()]
    //    create,

    //    /// <remarks/>
    //    [EnumMember()]
    //    created,

    //    /// <remarks/>
    //    [EnumMember()]
    //    close,

    //    /// <remarks/>
    //    [EnumMember()]
    //    closed,

    //    /// <remarks/>
    //    [EnumMember()]
    //    delete,

    //    /// <remarks/>
    //    [EnumMember()]
    //    deleted,

    //    /// <remarks/>
    //    [EnumMember()]
    //    get,

    //    /// <remarks/>
    //    [EnumMember()]
    //    reply,

    //    /// <remarks/>
    //    [EnumMember()]
    //    execute,

    //    /// <remarks/>
    //    [EnumMember()]
    //    executed,
    //}

    ///// <remarks/>
    //[DataContract()]
    //public class ReplayDetectionType {

    //    private string nonceField;

    //    private System.DateTime createdField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public string Nonce {
    //        get {
    //            return this.nonceField;
    //        }
    //        set {
    //            this.nonceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public System.DateTime Created {
    //        get {
    //            return this.createdField;
    //        }
    //        set {
    //            this.createdField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public class OperationType {

    //    private string operationIdField;

    //    private string nounField;

    //    private string verbField;

    //    private bool elementOperationField;

    //    private System.Xml.XmlElement anyField;

    //    public OperationType() {
    //        this.elementOperationField = false;
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string operationId {
    //        get {
    //            return this.operationIdField;
    //        }
    //        set {
    //            this.operationIdField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string noun {
    //        get {
    //            return this.nounField;
    //        }
    //        set {
    //            this.nounField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string verb {
    //        get {
    //            return this.verbField;
    //        }
    //        set {
    //            this.verbField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool elementOperation {
    //        get {
    //            return this.elementOperationField;
    //        }
    //        set {
    //            this.elementOperationField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public System.Xml.XmlElement Any {
    //        get {
    //            return this.anyField;
    //        }
    //        set {
    //            this.anyField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public class OperationSet {

    //    private bool enforceMsgSequenceField;

    //    private bool enforceMsgSequenceFieldSpecified;

    //    private bool enforceTransactionalIntegrityField;

    //    private bool enforceTransactionalIntegrityFieldSpecified;

    //    private OperationType[] operationField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool enforceMsgSequence {
    //        get {
    //            return this.enforceMsgSequenceField;
    //        }
    //        set {
    //            this.enforceMsgSequenceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool enforceMsgSequenceSpecified {
    //        get {
    //            return this.enforceMsgSequenceFieldSpecified;
    //        }
    //        set {
    //            this.enforceMsgSequenceFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool enforceTransactionalIntegrity {
    //        get {
    //            return this.enforceTransactionalIntegrityField;
    //        }
    //        set {
    //            this.enforceTransactionalIntegrityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool enforceTransactionalIntegritySpecified {
    //        get {
    //            return this.enforceTransactionalIntegrityFieldSpecified;
    //        }
    //        set {
    //            this.enforceTransactionalIntegrityFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public OperationType[] Operation {
    //        get {
    //            return this.operationField;
    //        }
    //        set {
    //            this.operationField = value;
    //        }
    //    }
    //}

    /// <remarks/>
    [DataContract()]
    public class LifecycleDate {
        
        private System.DateTime installationDateField;
        
        private bool installationDateFieldSpecified;
        
        private System.DateTime manufacturedDateField;
        
        private bool manufacturedDateFieldSpecified;
        
        private System.DateTime purchaseDateField;
        
        private bool purchaseDateFieldSpecified;
        
        private System.DateTime receivedDateField;
        
        private bool receivedDateFieldSpecified;
        
        private System.DateTime removalDateField;
        
        private bool removalDateFieldSpecified;
        
        private System.DateTime retiredDateField;
        
        private bool retiredDateFieldSpecified;
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime installationDate {
            get {
                return this.installationDateField;
            }
            set {
                this.installationDateField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool installationDateSpecified {
            get {
                return this.installationDateFieldSpecified;
            }
            set {
                this.installationDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime manufacturedDate {
            get {
                return this.manufacturedDateField;
            }
            set {
                this.manufacturedDateField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool manufacturedDateSpecified {
            get {
                return this.manufacturedDateFieldSpecified;
            }
            set {
                this.manufacturedDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime purchaseDate {
            get {
                return this.purchaseDateField;
            }
            set {
                this.purchaseDateField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool purchaseDateSpecified {
            get {
                return this.purchaseDateFieldSpecified;
            }
            set {
                this.purchaseDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime receivedDate {
            get {
                return this.receivedDateField;
            }
            set {
                this.receivedDateField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool receivedDateSpecified {
            get {
                return this.receivedDateFieldSpecified;
            }
            set {
                this.receivedDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime removalDate {
            get {
                return this.removalDateField;
            }
            set {
                this.removalDateField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool removalDateSpecified {
            get {
                return this.removalDateFieldSpecified;
            }
            set {
                this.removalDateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime retiredDate {
            get {
                return this.retiredDateField;
            }
            set {
                this.retiredDateField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool retiredDateSpecified {
            get {
                return this.retiredDateFieldSpecified;
            }
            set {
                this.retiredDateFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class ElectronicAddress {
        
        private string email1Field;
        
        private string email2Field;
        
        private string lanField;
        
        private string macField;
        
        private string passwordField;
        
        private string radioField;
        
        private string userIDField;
        
        private string webField;
        
        /// <remarks/>
        [DataMember()]
        public string email1 {
            get {
                return this.email1Field;
            }
            set {
                this.email1Field = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string email2 {
            get {
                return this.email2Field;
            }
            set {
                this.email2Field = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string lan {
            get {
                return this.lanField;
            }
            set {
                this.lanField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string mac {
            get {
                return this.macField;
            }
            set {
                this.macField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string radio {
            get {
                return this.radioField;
            }
            set {
                this.radioField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string userID {
            get {
                return this.userIDField;
            }
            set {
                this.userIDField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string web {
            get {
                return this.webField;
            }
            set {
                this.webField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class ConfigurationEvent {
        
        private string mRIDField;
        
        private System.DateTime createdDateTimeField;
        
        private bool createdDateTimeFieldSpecified;
        
        private System.DateTime effectiveDateTimeField;
        
        private bool effectiveDateTimeFieldSpecified;
        
        private string modifiedByField;
        
        private string reasonField;
        
        private string remarkField;
        
        private string severityField;
        
        private string typeField;
        
        private Name[] namesField;
        
        private Status statusField;
        
        /// <remarks/>
        [DataMember()]
        public string mRID {
            get {
                return this.mRIDField;
            }
            set {
                this.mRIDField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime createdDateTime {
            get {
                return this.createdDateTimeField;
            }
            set {
                this.createdDateTimeField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool createdDateTimeSpecified {
            get {
                return this.createdDateTimeFieldSpecified;
            }
            set {
                this.createdDateTimeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime effectiveDateTime {
            get {
                return this.effectiveDateTimeField;
            }
            set {
                this.effectiveDateTimeField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool effectiveDateTimeSpecified {
            get {
                return this.effectiveDateTimeFieldSpecified;
            }
            set {
                this.effectiveDateTimeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string modifiedBy {
            get {
                return this.modifiedByField;
            }
            set {
                this.modifiedByField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string reason {
            get {
                return this.reasonField;
            }
            set {
                this.reasonField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string remark {
            get {
                return this.remarkField;
            }
            set {
                this.remarkField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string severity {
            get {
                return this.severityField;
            }
            set {
                this.severityField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public Name[] Names {
            get {
                return this.namesField;
            }
            set {
                this.namesField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public Status status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class Name {
        
        private string nameField;
        
        private NameType nameTypeField;
        
        /// <remarks/>
        [DataMember()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public NameType NameType {
            get {
                return this.nameTypeField;
            }
            set {
                this.nameTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class NameType {
        
        private string descriptionField;
        
        private string nameField;
        
        private NameTypeAuthority nameTypeAuthorityField;
        
        /// <remarks/>
        [DataMember()]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public NameTypeAuthority NameTypeAuthority {
            get {
                return this.nameTypeAuthorityField;
            }
            set {
                this.nameTypeAuthorityField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class NameTypeAuthority {
        
        private string descriptionField;
        
        private string nameField;
        
        /// <remarks/>
        [DataMember()]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    ///// <remarks/>
    //[DataContract()]
    //public class Status {
        
    //    private System.DateTime dateTimeField;
        
    //    private bool dateTimeFieldSpecified;
        
    //    private string reasonField;
        
    //    private string remarkField;
        
    //    private string valueField;
        
    //    /// <remarks/>
    //    [DataMember()]
    //    public System.DateTime dateTime {
    //        get {
    //            return this.dateTimeField;
    //        }
    //        set {
    //            this.dateTimeField = value;
    //        }
    //    }
        
    //    /// <remarks/>
    //    [DataMember()]
    //    public bool dateTimeSpecified {
    //        get {
    //            return this.dateTimeFieldSpecified;
    //        }
    //        set {
    //            this.dateTimeFieldSpecified = value;
    //        }
    //    }
        
    //    /// <remarks/>
    //    [DataMember()]
    //    public string reason {
    //        get {
    //            return this.reasonField;
    //        }
    //        set {
    //            this.reasonField = value;
    //        }
    //    }
        
    //    /// <remarks/>
    //    [DataMember()]
    //    public string remark {
    //        get {
    //            return this.remarkField;
    //        }
    //        set {
    //            this.remarkField = value;
    //        }
    //    }
        
    //    /// <remarks/>
    //    [DataMember()]
    //    public string value {
    //        get {
    //            return this.valueField;
    //        }
    //        set {
    //            this.valueField = value;
    //        }
    //    }
    //}
    
    /// <remarks/>
    [DataContract()]
    public class Manufacturer {
        
        private string mRIDField;
        
        private Name[] namesField;
        
        /// <remarks/>
        [DataMember()]
        public string mRID {
            get {
                return this.mRIDField;
            }
            set {
                this.mRIDField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public Name[] Names {
            get {
                return this.namesField;
            }
            set {
                this.namesField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class ProductAssetModel {
        
        private CorporateStandardKind corporateStandardKindField;
        
        private bool corporateStandardKindFieldSpecified;
        
        private string modelNumberField;
        
        private string modelVersionField;
        
        private AssetModelUsageKind usageKindField;
        
        private bool usageKindFieldSpecified;
        
        private Manufacturer manufacturerField;
        
        /// <remarks/>
        [DataMember()]
        public CorporateStandardKind corporateStandardKind {
            get {
                return this.corporateStandardKindField;
            }
            set {
                this.corporateStandardKindField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool corporateStandardKindSpecified {
            get {
                return this.corporateStandardKindFieldSpecified;
            }
            set {
                this.corporateStandardKindFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string modelNumber {
            get {
                return this.modelNumberField;
            }
            set {
                this.modelNumberField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string modelVersion {
            get {
                return this.modelVersionField;
            }
            set {
                this.modelVersionField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public AssetModelUsageKind usageKind {
            get {
                return this.usageKindField;
            }
            set {
                this.usageKindField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool usageKindSpecified {
            get {
                return this.usageKindFieldSpecified;
            }
            set {
                this.usageKindFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public Manufacturer Manufacturer {
            get {
                return this.manufacturerField;
            }
            set {
                this.manufacturerField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public enum CorporateStandardKind {
        
        /// <remarks/>
        [EnumMember()]
        experimental,
        
        /// <remarks/>
        [EnumMember()]
        other,
        
        /// <remarks/>
        [EnumMember()]
        standard,
        
        /// <remarks/>
        [EnumMember()]
        underEvaluation,
    }
    
    /// <remarks/>
    [DataContract()]
    public enum AssetModelUsageKind {
        
        /// <remarks/>
        [EnumMember()]
        customerSubstation,
        
        /// <remarks/>
        [EnumMember()]
        distributionOverhead,
        
        /// <remarks/>
        [EnumMember()]
        distributionUnderground,
        
        /// <remarks/>
        [EnumMember()]
        other,
        
        /// <remarks/>
        [EnumMember()]
        streetlight,
        
        /// <remarks/>
        [EnumMember()]
        substation,
        
        /// <remarks/>
        [EnumMember()]
        transmission,
        
        /// <remarks/>
        [EnumMember()]
        unknown,
    }
    
    /// <remarks/>
    [DataContract()]
    public class EndDeviceInfo {
        
        private ProductAssetModel assetModelField;
        
        /// <remarks/>
        [DataMember()]
        public ProductAssetModel AssetModel {
            get {
                return this.assetModelField;
            }
            set {
                this.assetModelField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class ActivityRecord {
        
        private string mRIDField;
        
        private System.DateTime createdDateTimeField;
        
        private bool createdDateTimeFieldSpecified;
        
        private string reasonField;
        
        private string severityField;
        
        private string typeField;
        
        private Name[] namesField;
        
        private Status statusField;
        
        /// <remarks/>
        [DataMember()]
        public string mRID {
            get {
                return this.mRIDField;
            }
            set {
                this.mRIDField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime createdDateTime {
            get {
                return this.createdDateTimeField;
            }
            set {
                this.createdDateTimeField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool createdDateTimeSpecified {
            get {
                return this.createdDateTimeFieldSpecified;
            }
            set {
                this.createdDateTimeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string reason {
            get {
                return this.reasonField;
            }
            set {
                this.reasonField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string severity {
            get {
                return this.severityField;
            }
            set {
                this.severityField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public Name[] Names {
            get {
                return this.namesField;
            }
            set {
                this.namesField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public Status status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class ComModule {
        
        private string mRIDField;
        
        private string amrSystemField;
        
        private string initialConditionField;
        
        private float initialLossOfLifeField;
        
        private bool initialLossOfLifeFieldSpecified;
        
        private string lotNumberField;
        
        private decimal purchasePriceField;
        
        private bool purchasePriceFieldSpecified;
        
        private string serialNumberField;
        
        private bool supportsAutonomousDstField;
        
        private bool supportsAutonomousDstFieldSpecified;
        
        private float timeZoneOffsetField;
        
        private bool timeZoneOffsetFieldSpecified;
        
        private string typeField;
        
        private string utcNumberField;
        
        private ActivityRecord[] activityRecordsField;
        
        private EndDeviceInfo assetInfoField;
        
        private ComModuleComFunctions[] comFunctionsField;
        
        private ConfigurationEvent configurationEventsField;
        
        private ElectronicAddress electronicAddressField;
        
        private LifecycleDate lifecycleField;
        
        private Name[] namesField;
        
        private Status statusField;
        
        /// <remarks/>
        [DataMember()]
        public string mRID {
            get {
                return this.mRIDField;
            }
            set {
                this.mRIDField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string amrSystem {
            get {
                return this.amrSystemField;
            }
            set {
                this.amrSystemField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string initialCondition {
            get {
                return this.initialConditionField;
            }
            set {
                this.initialConditionField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public float initialLossOfLife {
            get {
                return this.initialLossOfLifeField;
            }
            set {
                this.initialLossOfLifeField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool initialLossOfLifeSpecified {
            get {
                return this.initialLossOfLifeFieldSpecified;
            }
            set {
                this.initialLossOfLifeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string lotNumber {
            get {
                return this.lotNumberField;
            }
            set {
                this.lotNumberField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public decimal purchasePrice {
            get {
                return this.purchasePriceField;
            }
            set {
                this.purchasePriceField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool purchasePriceSpecified {
            get {
                return this.purchasePriceFieldSpecified;
            }
            set {
                this.purchasePriceFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string serialNumber {
            get {
                return this.serialNumberField;
            }
            set {
                this.serialNumberField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool supportsAutonomousDst {
            get {
                return this.supportsAutonomousDstField;
            }
            set {
                this.supportsAutonomousDstField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool supportsAutonomousDstSpecified {
            get {
                return this.supportsAutonomousDstFieldSpecified;
            }
            set {
                this.supportsAutonomousDstFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public float timeZoneOffset {
            get {
                return this.timeZoneOffsetField;
            }
            set {
                this.timeZoneOffsetField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool timeZoneOffsetSpecified {
            get {
                return this.timeZoneOffsetFieldSpecified;
            }
            set {
                this.timeZoneOffsetFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string utcNumber {
            get {
                return this.utcNumberField;
            }
            set {
                this.utcNumberField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public ActivityRecord[] ActivityRecords {
            get {
                return this.activityRecordsField;
            }
            set {
                this.activityRecordsField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public EndDeviceInfo AssetInfo {
            get {
                return this.assetInfoField;
            }
            set {
                this.assetInfoField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public ComModuleComFunctions[] ComFunctions {
            get {
                return this.comFunctionsField;
            }
            set {
                this.comFunctionsField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public ConfigurationEvent ConfigurationEvents {
            get {
                return this.configurationEventsField;
            }
            set {
                this.configurationEventsField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public ElectronicAddress electronicAddress {
            get {
                return this.electronicAddressField;
            }
            set {
                this.electronicAddressField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public LifecycleDate lifecycle {
            get {
                return this.lifecycleField;
            }
            set {
                this.lifecycleField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public Name[] Names {
            get {
                return this.namesField;
            }
            set {
                this.namesField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public Status status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class ComModuleComFunctions {
        
        private string refField;
        
        /// <remarks/>
        [DataMember()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class ComFunction {
        
        private string mRIDField;
        
        private string amrAddressField;
        
        private string amrRouterField;
        
        private string configIDField;
        
        private ComDirectionKind directionField;
        
        private bool directionFieldSpecified;
        
        private bool enabledField;
        
        private bool enabledFieldSpecified;
        
        private string firmwareIDField;
        
        private string hardwareIDField;
        
        private string passwordField;
        
        private string programIDField;
        
        private ComTechnologyKind technologyField;
        
        private bool technologyFieldSpecified;
        
        private Name[] namesField;
        
        /// <remarks/>
        [DataMember()]
        public string mRID {
            get {
                return this.mRIDField;
            }
            set {
                this.mRIDField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string amrAddress {
            get {
                return this.amrAddressField;
            }
            set {
                this.amrAddressField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string amrRouter {
            get {
                return this.amrRouterField;
            }
            set {
                this.amrRouterField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string configID {
            get {
                return this.configIDField;
            }
            set {
                this.configIDField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public ComDirectionKind direction {
            get {
                return this.directionField;
            }
            set {
                this.directionField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool directionSpecified {
            get {
                return this.directionFieldSpecified;
            }
            set {
                this.directionFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool enabled {
            get {
                return this.enabledField;
            }
            set {
                this.enabledField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool enabledSpecified {
            get {
                return this.enabledFieldSpecified;
            }
            set {
                this.enabledFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string firmwareID {
            get {
                return this.firmwareIDField;
            }
            set {
                this.firmwareIDField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string hardwareID {
            get {
                return this.hardwareIDField;
            }
            set {
                this.hardwareIDField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string programID {
            get {
                return this.programIDField;
            }
            set {
                this.programIDField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public ComTechnologyKind technology {
            get {
                return this.technologyField;
            }
            set {
                this.technologyField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool technologySpecified {
            get {
                return this.technologyFieldSpecified;
            }
            set {
                this.technologyFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public Name[] Names {
            get {
                return this.namesField;
            }
            set {
                this.namesField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public enum ComDirectionKind {
        
        /// <remarks/>
        [EnumMember()]
        biDirectional,
        
        /// <remarks/>
        [EnumMember()]
        fromDevice,
        
        /// <remarks/>
        [EnumMember()]
        toDevice,
    }
    
    /// <remarks/>
    [DataContract()]
    public enum ComTechnologyKind {
        
        /// <remarks/>
        [EnumMember()]
        cellular,
        
        /// <remarks/>
        [EnumMember()]
        ethernet,
        
        /// <remarks/>
        [EnumMember()]
        homePlug,
        
        /// <remarks/>
        [EnumMember()]
        pager,
        
        /// <remarks/>
        [EnumMember()]
        phone,
        
        /// <remarks/>
        [EnumMember()]
        plc,
        
        /// <remarks/>
        [EnumMember()]
        rf,
        
        /// <remarks/>
        [EnumMember()]
        rfMesh,
        
        /// <remarks/>
        [EnumMember()]
        zigbee,
    }
    
    /// <remarks/>
    [DataContract()]
    public class ComModuleConfig {
        
        private ComFunction[] comFunctionField;
        
        private ComModule[] comModuleField;
        
        /// <remarks/>
        [DataMember()]
        public ComFunction[] ComFunction {
            get {
                return this.comFunctionField;
            }
            set {
                this.comFunctionField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public ComModule[] ComModule {
            get {
                return this.comModuleField;
            }
            set {
                this.comModuleField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class ComModuleConfigPayloadType : IPayloadType<ComModuleConfig>
    {
        
        private ComModuleConfig comModuleConfigField;
        
        private OperationSet operationSetField;
        
        private string compressedField;
        
        private string formatField;
        
        /// <remarks/>
        [DataMember()]
        public ComModuleConfig ComModuleConfig {
            get {
                return this.comModuleConfigField;
            }
            set {
                this.comModuleConfigField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public OperationSet OperationSet {
            get {
                return this.operationSetField;
            }
            set {
                this.operationSetField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string Compressed {
            get {
                return this.compressedField;
            }
            set {
                this.compressedField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string Format {
            get {
                return this.formatField;
            }
            set {
                this.formatField = value;
            }
        }
    }

    ///// <remarks/>
    //[DataContract()]
    //public class OptionType {

    //    private string nameField;

    //    private string valueField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public string name {
    //        get {
    //            return this.nameField;
    //        }
    //        set {
    //            this.nameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string value {
    //        get {
    //            return this.valueField;
    //        }
    //        set {
    //            this.valueField = value;
    //        }
    //    }
    //}

    public class GetComModuleConfigRequestType : GetRequestType
    { }

    ///// <remarks/>
    //[DataContract()]
    //public class GetComModuleConfigRequestType {

    //    private System.DateTime startTimeField;

    //    private bool startTimeFieldSpecified;

    //    private System.DateTime endTimeField;

    //    private bool endTimeFieldSpecified;

    //    private OptionType[] optionField;

    //    private string[] idField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public System.DateTime StartTime {
    //        get {
    //            return this.startTimeField;
    //        }
    //        set {
    //            this.startTimeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool StartTimeSpecified {
    //        get {
    //            return this.startTimeFieldSpecified;
    //        }
    //        set {
    //            this.startTimeFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public System.DateTime EndTime {
    //        get {
    //            return this.endTimeField;
    //        }
    //        set {
    //            this.endTimeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool EndTimeSpecified {
    //        get {
    //            return this.endTimeFieldSpecified;
    //        }
    //        set {
    //            this.endTimeFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public OptionType[] Option {
    //        get {
    //            return this.optionField;
    //        }
    //        set {
    //            this.optionField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string[] ID {
    //        get {
    //            return this.idField;
    //        }
    //        set {
    //            this.idField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public class MessageProperty {

    //    private string nameField;

    //    private string valueField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public string Name {
    //        get {
    //            return this.nameField;
    //        }
    //        set {
    //            this.nameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string Value {
    //        get {
    //            return this.valueField;
    //        }
    //        set {
    //            this.valueField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public class UserType {

    //    private string userIDField;

    //    private string organizationField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public string UserID {
    //        get {
    //            return this.userIDField;
    //        }
    //        set {
    //            this.userIDField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string Organization {
    //        get {
    //            return this.organizationField;
    //        }
    //        set {
    //            this.organizationField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public enum HeaderTypeContext {

    //    /// <remarks/>
    //    [EnumMember()]
    //    PRODUCTION,

    //    /// <remarks/>
    //    [EnumMember()]
    //    TESTING,

    //    /// <remarks/>
    //    [EnumMember()]
    //    DEVELOPMENT,

    //    /// <remarks/>
    //    [EnumMember()]
    //    STUDY,

    //    /// <remarks/>
    //    [EnumMember()]
    //    TRAINING,
    //}

    /// <remarks/>
    [DataContract()]
    public class ComModuleConfigResponseMessageType : IResponseMessageType<ComModuleConfigPayloadType>
    {

        private HeaderType headerField;

        private ReplyType replyField;

        private ComModuleConfigPayloadType payloadField;

        /// <remarks/>
        [DataMember()]
        public HeaderType Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public ReplyType Reply
        {
            get
            {
                return this.replyField;
            }
            set
            {
                this.replyField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public ComModuleConfigPayloadType Payload
        {
            get
            {
                return this.payloadField;
            }
            set
            {
                this.payloadField = value;
            }
        }
    }

    ///// <remarks/>
    //[DataContract()]
    //public class ReplyType {

    //    private ReplyTypeResult resultField;

    //    private ErrorType[] errorField;

    //    private string[] idField;

    //    private System.Xml.XmlElement[] anyField;

    //    private string operationIdField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public ReplyTypeResult Result {
    //        get {
    //            return this.resultField;
    //        }
    //        set {
    //            this.resultField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public ErrorType[] Error {
    //        get {
    //            return this.errorField;
    //        }
    //        set {
    //            this.errorField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string[] ID {
    //        get {
    //            return this.idField;
    //        }
    //        set {
    //            this.idField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public System.Xml.XmlElement[] Any {
    //        get {
    //            return this.anyField;
    //        }
    //        set {
    //            this.anyField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string operationId {
    //        get {
    //            return this.operationIdField;
    //        }
    //        set {
    //            this.operationIdField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public enum ReplyTypeResult {

    //    /// <remarks/>
    //    [EnumMember()]
    //    OK,

    //    /// <remarks/>
    //    [EnumMember()]
    //    PARTIAL,

    //    /// <remarks/>
    //    [EnumMember()]
    //    FAILED,
    //}

    ///// <remarks/>
    //[DataContract()]
    //public class ErrorType {

    //    private string codeField;

    //    private ErrorTypeLevel levelField;

    //    private bool levelFieldSpecified;

    //    private object reasonField;

    //    private string detailsField;

    //    private System.Xml.XmlQualifiedName xpathField;

    //    private string stackTraceField;

    //    private LocationType locationField;

    //    private IdentifiedObject objectField;

    //    private string operationIdField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public string code {
    //        get {
    //            return this.codeField;
    //        }
    //        set {
    //            this.codeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public ErrorTypeLevel level {
    //        get {
    //            return this.levelField;
    //        }
    //        set {
    //            this.levelField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public bool levelSpecified {
    //        get {
    //            return this.levelFieldSpecified;
    //        }
    //        set {
    //            this.levelFieldSpecified = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public object reason {
    //        get {
    //            return this.reasonField;
    //        }
    //        set {
    //            this.reasonField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string details {
    //        get {
    //            return this.detailsField;
    //        }
    //        set {
    //            this.detailsField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public System.Xml.XmlQualifiedName xpath {
    //        get {
    //            return this.xpathField;
    //        }
    //        set {
    //            this.xpathField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string stackTrace {
    //        get {
    //            return this.stackTraceField;
    //        }
    //        set {
    //            this.stackTraceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public LocationType Location {
    //        get {
    //            return this.locationField;
    //        }
    //        set {
    //            this.locationField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public IdentifiedObject @object {
    //        get {
    //            return this.objectField;
    //        }
    //        set {
    //            this.objectField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string operationId {
    //        get {
    //            return this.operationIdField;
    //        }
    //        set {
    //            this.operationIdField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public enum ErrorTypeLevel {

    //    /// <remarks/>
    //    [EnumMember()]
    //    INFORM,

    //    /// <remarks/>
    //    [EnumMember()]
    //    WARNING,

    //    /// <remarks/>
    //    [EnumMember()]
    //    FATAL,

    //    /// <remarks/>
    //    [EnumMember()]
    //    CATASTROPHIC,
    //}

    ///// <remarks/>
    //[DataContract()]
    //public class LocationType {

    //    private string nodeField;

    //    private string pipelineField;

    //    private string stageField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public string node {
    //        get {
    //            return this.nodeField;
    //        }
    //        set {
    //            this.nodeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string pipeline {
    //        get {
    //            return this.pipelineField;
    //        }
    //        set {
    //            this.pipelineField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string stage {
    //        get {
    //            return this.stageField;
    //        }
    //        set {
    //            this.stageField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public class IdentifiedObject {

    //    private object mRIDField;

    //    private Name1[] nameField;

    //    private string objectTypeField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public object mRID {
    //        get {
    //            return this.mRIDField;
    //        }
    //        set {
    //            this.mRIDField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public Name1[] Name {
    //        get {
    //            return this.nameField;
    //        }
    //        set {
    //            this.nameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public string objectType {
    //        get {
    //            return this.objectTypeField;
    //        }
    //        set {
    //            this.objectTypeField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public class Name1 {

    //    private object nameField;

    //    private NameType1 nameTypeField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public object name {
    //        get {
    //            return this.nameField;
    //        }
    //        set {
    //            this.nameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public NameType1 NameType {
    //        get {
    //            return this.nameTypeField;
    //        }
    //        set {
    //            this.nameTypeField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public class NameType1 {

    //    private object nameField;

    //    private object descriptionField;

    //    private NameTypeAuthority1 nameTypeAuthorityField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public object name {
    //        get {
    //            return this.nameField;
    //        }
    //        set {
    //            this.nameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public object description {
    //        get {
    //            return this.descriptionField;
    //        }
    //        set {
    //            this.descriptionField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public NameTypeAuthority1 NameTypeAuthority {
    //        get {
    //            return this.nameTypeAuthorityField;
    //        }
    //        set {
    //            this.nameTypeAuthorityField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[DataContract()]
    //public class NameTypeAuthority1 {

    //    private object nameField;

    //    private object descriptionField;

    //    /// <remarks/>
    //    [DataMember()]
    //    public object name {
    //        get {
    //            return this.nameField;
    //        }
    //        set {
    //            this.nameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [DataMember()]
    //    public object description {
    //        get {
    //            return this.descriptionField;
    //        }
    //        set {
    //            this.descriptionField = value;
    //        }
    //    }
    //}

    /// <remarks/>
    [DataContract()]
    public class ComModuleConfigFaultMessageType : FaultMessageType
    { }
    
    [DataContract()]
    public class GetComModuleConfigRequest
    {
        private GetComModuleConfigRequestMessageType getComModuleConfigRequestMessage;

        [DataMember()]
        public GetComModuleConfigRequestMessageType GetComModuleConfigRequestMessage
        {
            get
            {
                return this.getComModuleConfigRequestMessage;
            }
            set
            {
                this.getComModuleConfigRequestMessage = value;
            }
        }
    }
    
    [DataContract()]
    public class GetComModuleConfigResponse
    {
        private ComModuleConfigResponseMessageType comModuleConfigResponseMessage;

        [DataMember()]
        public ComModuleConfigResponseMessageType ComModuleConfigResponseMessage
        {
            get
            {
                return this.comModuleConfigResponseMessage;
            }
            set
            {
                this.comModuleConfigResponseMessage = value;
            }
        }
    }

    public class GetComModuleConfigService : IGetComModuleConfigService
    {
        public Func<GetComModuleConfigRequest, GetComModuleConfigResponse> GetHandler { get; set; }

        public virtual GetComModuleConfigResponse GetComModuleConfig(GetComModuleConfigRequest request)
        {
            try
            {
                request.GetComModuleConfigRequestMessage.IsHeaderOk(false, false, false);
                request.GetComModuleConfigRequestMessage.IsRequestOk(true, true, true, true);

                return this.GetHandler(request);
            }
            catch (Exception e1)
            {
                return new GetComModuleConfigResponse()
                {
                    ComModuleConfigResponseMessage = new ComModuleConfigResponseMessageType()
                    {
                        Header = new HeaderType()
                        {
                            Verb = request.GetComModuleConfigRequestMessage.Header.Verb,
                            Noun = request.GetComModuleConfigRequestMessage.Header.Noun
                        },
                        Reply = new ReplyType()
                        {
                            Result = ReplyTypeResult.FAILED,
                            Error = new ErrorType[] { new ErrorType() { level = ErrorTypeLevel.FATAL, details = e1.Message } }
                        }
                    }
                };
            }
        }
    }

    [ServiceContract]
    public interface IGetComModuleConfigService
    {
        [OperationContract]
        GetComModuleConfigResponse GetComModuleConfig(GetComModuleConfigRequest request);
    }
}
