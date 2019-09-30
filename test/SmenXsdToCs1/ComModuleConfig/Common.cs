namespace CIM
{
    using System.Runtime.Serialization;

    /// <remarks/>
    public interface IGetRequestMessageType<TRequest, TPayload>
    {
        HeaderType Header { get; set; }
        TRequest Request { get; set; }
        TPayload Payload { get; set; }
    }
    /// <remarks/>
    public interface IRequestMessageType<TPayload>
    {
        HeaderType Header { get; set; }
        RequestType Request { get; set; }
        TPayload Payload { get; set; }
    }
    /// <remarks/>
    public interface IEventMessageType<TPayload>
    {
        HeaderType Header { get; set; }
        TPayload Payload { get; set; }
    }
    /// <remarks/>
    public interface IResponseMessageType<TPayload>
    {
        HeaderType Header { get; set; }
        TPayload Payload { get; set; }
        ReplyType Reply { get; set; }
    }
    /// <remarks/>
    [DataContract()]
    public class FaultMessageType
    {

        private ReplyType replyField;

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
    }
    /// <remarks/>
    [DataContract()]
    public class EventMessageType<TPayload>
    {

        private HeaderType headerField;

        private TPayload payloadField;

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
        public TPayload Payload
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
    /// <remarks/>
    [DataContract()]
    public class HeaderType
    {

        private HeaderTypeVerb verbField;

        private string nounField;

        private string revisionField;

        private ReplayDetectionType replayDetectionField;

        private HeaderTypeContext contextField;

        private bool contextFieldSpecified;

        private System.DateTime timestampField;

        private bool timestampFieldSpecified;

        private string sourceField;

        private bool asyncReplyFlagField;

        private bool asyncReplyFlagFieldSpecified;

        private string replyAddressField;

        private bool ackRequiredField;

        private bool ackRequiredFieldSpecified;

        private UserType userField;

        private string messageIDField;

        private string correlationIDField;

        private string commentField;

        private MessageProperty[] propertyField;

        private System.Xml.XmlElement[] anyField;

        /// <remarks/>
        [DataMember()]
        public HeaderTypeVerb Verb
        {
            get
            {
                return this.verbField;
            }
            set
            {
                this.verbField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string Noun
        {
            get
            {
                return this.nounField;
            }
            set
            {
                this.nounField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string Revision
        {
            get
            {
                return this.revisionField;
            }
            set
            {
                this.revisionField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public ReplayDetectionType ReplayDetection
        {
            get
            {
                return this.replayDetectionField;
            }
            set
            {
                this.replayDetectionField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public HeaderTypeContext Context
        {
            get
            {
                return this.contextField;
            }
            set
            {
                this.contextField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool ContextSpecified
        {
            get
            {
                return this.contextFieldSpecified;
            }
            set
            {
                this.contextFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public System.DateTime Timestamp
        {
            get
            {
                return this.timestampField;
            }
            set
            {
                this.timestampField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool TimestampSpecified
        {
            get
            {
                return this.timestampFieldSpecified;
            }
            set
            {
                this.timestampFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string Source
        {
            get
            {
                return this.sourceField;
            }
            set
            {
                this.sourceField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool AsyncReplyFlag
        {
            get
            {
                return this.asyncReplyFlagField;
            }
            set
            {
                this.asyncReplyFlagField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool AsyncReplyFlagSpecified
        {
            get
            {
                return this.asyncReplyFlagFieldSpecified;
            }
            set
            {
                this.asyncReplyFlagFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string ReplyAddress
        {
            get
            {
                return this.replyAddressField;
            }
            set
            {
                this.replyAddressField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool AckRequired
        {
            get
            {
                return this.ackRequiredField;
            }
            set
            {
                this.ackRequiredField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool AckRequiredSpecified
        {
            get
            {
                return this.ackRequiredFieldSpecified;
            }
            set
            {
                this.ackRequiredFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public UserType User
        {
            get
            {
                return this.userField;
            }
            set
            {
                this.userField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string MessageID
        {
            get
            {
                return this.messageIDField;
            }
            set
            {
                this.messageIDField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string CorrelationID
        {
            get
            {
                return this.correlationIDField;
            }
            set
            {
                this.correlationIDField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string Comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public MessageProperty[] Property
        {
            get
            {
                return this.propertyField;
            }
            set
            {
                this.propertyField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public class GetRequestType
    {

        private System.DateTime startTimeField;

        private bool startTimeFieldSpecified;

        private System.DateTime endTimeField;

        private bool endTimeFieldSpecified;

        private OptionType[] optionField;

        private string[] idField;

        /// <remarks/>
        [DataMember()]
        public System.DateTime StartTime
        {
            get
            {
                return this.startTimeField;
            }
            set
            {
                this.startTimeField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool StartTimeSpecified
        {
            get
            {
                return this.startTimeFieldSpecified;
            }
            set
            {
                this.startTimeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public System.DateTime EndTime
        {
            get
            {
                return this.endTimeField;
            }
            set
            {
                this.endTimeField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool EndTimeSpecified
        {
            get
            {
                return this.endTimeFieldSpecified;
            }
            set
            {
                this.endTimeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public OptionType[] Option
        {
            get
            {
                return this.optionField;
            }
            set
            {
                this.optionField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string[] ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public class RequestType
    {

        private System.DateTime startTimeField;

        private bool startTimeFieldSpecified;

        private System.DateTime endTimeField;

        private bool endTimeFieldSpecified;

        private OptionType[] optionField;

        private string[] idField;

        private System.Xml.XmlElement[] anyField;

        /// <remarks/>
        [DataMember()]
        public System.DateTime StartTime
        {
            get
            {
                return this.startTimeField;
            }
            set
            {
                this.startTimeField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool StartTimeSpecified
        {
            get
            {
                return this.startTimeFieldSpecified;
            }
            set
            {
                this.startTimeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public System.DateTime EndTime
        {
            get
            {
                return this.endTimeField;
            }
            set
            {
                this.endTimeField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool EndTimeSpecified
        {
            get
            {
                return this.endTimeFieldSpecified;
            }
            set
            {
                this.endTimeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public OptionType[] Option
        {
            get
            {
                return this.optionField;
            }
            set
            {
                this.optionField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string[] ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }
    /// <remarks/>
    public interface IPayloadType<T>
    {
        /// <remarks/>
        OperationSet OperationSet { get; set; }

        /// <remarks/>
        string Compressed { get; set; }

        /// <remarks/>
        string Format { get; set; }
    }
    /// <remarks/>
    [DataContract()]
    public class ReplyType
    {

        private ReplyTypeResult resultField;

        private ErrorType[] errorField;

        private string[] idField;

        private System.Xml.XmlElement[] anyField;

        private string operationIdField;

        /// <remarks/>
        [DataMember()]
        public ReplyTypeResult Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public ErrorType[] Error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string[] ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string operationId
        {
            get
            {
                return this.operationIdField;
            }
            set
            {
                this.operationIdField = value;
            }
        }
    }

    /// <remarks/>
    [DataContract()]
    public class MessageProperty
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [DataMember()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public class UserType
    {

        private string userIDField;

        private string organizationField;

        /// <remarks/>
        [DataMember()]
        public string UserID
        {
            get
            {
                return this.userIDField;
            }
            set
            {
                this.userIDField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string Organization
        {
            get
            {
                return this.organizationField;
            }
            set
            {
                this.organizationField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public enum HeaderTypeContext
    {

        /// <remarks/>
        [EnumMember()]
        PRODUCTION,

        /// <remarks/>
        [EnumMember()]
        TESTING,

        /// <remarks/>
        [EnumMember()]
        DEVELOPMENT,

        /// <remarks/>
        [EnumMember()]
        STUDY,

        /// <remarks/>
        [EnumMember()]
        TRAINING,
    }
    /// <remarks/>
    [DataContract()]
    public class ReplayDetectionType
    {

        private string nonceField;

        private System.DateTime createdField;

        /// <remarks/>
        [DataMember()]
        public string Nonce
        {
            get
            {
                return this.nonceField;
            }
            set
            {
                this.nonceField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public System.DateTime Created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public enum HeaderTypeVerb
    {

        /// <remarks/>
        [EnumMember()]
        cancel,

        /// <remarks/>
        [EnumMember()]
        canceled,

        /// <remarks/>
        [EnumMember()]
        change,

        /// <remarks/>
        [EnumMember()]
        changed,

        /// <remarks/>
        [EnumMember()]
        create,

        /// <remarks/>
        [EnumMember()]
        created,

        /// <remarks/>
        [EnumMember()]
        close,

        /// <remarks/>
        [EnumMember()]
        closed,

        /// <remarks/>
        [EnumMember()]
        delete,

        /// <remarks/>
        [EnumMember()]
        deleted,

        /// <remarks/>
        [EnumMember()]
        get,

        /// <remarks/>
        [EnumMember()]
        reply,

        /// <remarks/>
        [EnumMember()]
        execute,

        /// <remarks/>
        [EnumMember()]
        executed,
    }
    /// <remarks/>
    [DataContract()]
    public class OptionType
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [DataMember()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public class OperationType
    {

        private string operationIdField;

        private string nounField;

        private string verbField;

        private bool elementOperationField;

        private System.Xml.XmlElement anyField;

        public OperationType()
        {
            this.elementOperationField = false;
        }

        /// <remarks/>
        [DataMember()]
        public string operationId
        {
            get
            {
                return this.operationIdField;
            }
            set
            {
                this.operationIdField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string noun
        {
            get
            {
                return this.nounField;
            }
            set
            {
                this.nounField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string verb
        {
            get
            {
                return this.verbField;
            }
            set
            {
                this.verbField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool elementOperation
        {
            get
            {
                return this.elementOperationField;
            }
            set
            {
                this.elementOperationField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public System.Xml.XmlElement Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public class OperationSet
    {

        private bool enforceMsgSequenceField;

        private bool enforceMsgSequenceFieldSpecified;

        private bool enforceTransactionalIntegrityField;

        private bool enforceTransactionalIntegrityFieldSpecified;

        private OperationType[] operationField;

        /// <remarks/>
        [DataMember()]
        public bool enforceMsgSequence
        {
            get
            {
                return this.enforceMsgSequenceField;
            }
            set
            {
                this.enforceMsgSequenceField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool enforceMsgSequenceSpecified
        {
            get
            {
                return this.enforceMsgSequenceFieldSpecified;
            }
            set
            {
                this.enforceMsgSequenceFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool enforceTransactionalIntegrity
        {
            get
            {
                return this.enforceTransactionalIntegrityField;
            }
            set
            {
                this.enforceTransactionalIntegrityField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool enforceTransactionalIntegritySpecified
        {
            get
            {
                return this.enforceTransactionalIntegrityFieldSpecified;
            }
            set
            {
                this.enforceTransactionalIntegrityFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public OperationType[] Operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public enum ReplyTypeResult
    {

        /// <remarks/>
        [EnumMember()]
        OK,

        /// <remarks/>
        [EnumMember()]
        PARTIAL,

        /// <remarks/>
        [EnumMember()]
        FAILED,
    }
    
    /// <remarks/>
    [DataContract()]
    public class IdentifiedObject
    {

        private object mRIDField;

        private Name1[] nameField;

        private string objectTypeField;

        /// <remarks/>
        [DataMember()]
        public object mRID
        {
            get
            {
                return this.mRIDField;
            }
            set
            {
                this.mRIDField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public Name1[] Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string objectType
        {
            get
            {
                return this.objectTypeField;
            }
            set
            {
                this.objectTypeField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public class Name1
    {

        private object nameField;

        private NameType1 nameTypeField;

        /// <remarks/>
        [DataMember()]
        public object name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public NameType1 NameType
        {
            get
            {
                return this.nameTypeField;
            }
            set
            {
                this.nameTypeField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public class NameType1
    {

        private object nameField;

        private object descriptionField;

        private NameTypeAuthority1 nameTypeAuthorityField;

        /// <remarks/>
        [DataMember()]
        public object name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public object description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public NameTypeAuthority1 NameTypeAuthority
        {
            get
            {
                return this.nameTypeAuthorityField;
            }
            set
            {
                this.nameTypeAuthorityField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public class NameTypeAuthority1
    {

        private object nameField;

        private object descriptionField;

        /// <remarks/>
        [DataMember()]
        public object name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public object description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [DataContract()]
    public class ErrorType
    {

        private string codeField;

        private ErrorTypeLevel levelField;

        private bool levelFieldSpecified;

        private object reasonField;

        private string detailsField;

        private System.Xml.XmlQualifiedName xpathField;

        private string stackTraceField;

        private LocationType locationField;

        private IdentifiedObject objectField;

        private string operationIdField;

        /// <remarks/>
        [DataMember()]
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public ErrorTypeLevel level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool levelSpecified
        {
            get
            {
                return this.levelFieldSpecified;
            }
            set
            {
                this.levelFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public object reason
        {
            get
            {
                return this.reasonField;
            }
            set
            {
                this.reasonField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string details
        {
            get
            {
                return this.detailsField;
            }
            set
            {
                this.detailsField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public System.Xml.XmlQualifiedName xpath
        {
            get
            {
                return this.xpathField;
            }
            set
            {
                this.xpathField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string stackTrace
        {
            get
            {
                return this.stackTraceField;
            }
            set
            {
                this.stackTraceField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public LocationType Location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public IdentifiedObject @object
        {
            get
            {
                return this.objectField;
            }
            set
            {
                this.objectField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string operationId
        {
            get
            {
                return this.operationIdField;
            }
            set
            {
                this.operationIdField = value;
            }
        }
    }
    /// <remarks/>
    [DataContract()]
    public enum ErrorTypeLevel
    {

        /// <remarks/>
        [EnumMember()]
        INFORM,

        /// <remarks/>
        [EnumMember()]
        WARNING,

        /// <remarks/>
        [EnumMember()]
        FATAL,

        /// <remarks/>
        [EnumMember()]
        CATASTROPHIC,
    }
    /// <remarks/>
    [DataContract()]
    public class LocationType
    {

        private string nodeField;

        private string pipelineField;

        private string stageField;

        /// <remarks/>
        [DataMember()]
        public string node
        {
            get
            {
                return this.nodeField;
            }
            set
            {
                this.nodeField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string pipeline
        {
            get
            {
                return this.pipelineField;
            }
            set
            {
                this.pipelineField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string stage
        {
            get
            {
                return this.stageField;
            }
            set
            {
                this.stageField = value;
            }
        }
    }

    /// <remarks/>
    [DataContract()]
    public class Status
    {

        private System.DateTime dateTimeField;

        private bool dateTimeFieldSpecified;

        private string reasonField;

        private string remarkField;

        private string valueField;

        /// <remarks/>
        [DataMember()]
        public System.DateTime dateTime
        {
            get
            {
                return this.dateTimeField;
            }
            set
            {
                this.dateTimeField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public bool dateTimeSpecified
        {
            get
            {
                return this.dateTimeFieldSpecified;
            }
            set
            {
                this.dateTimeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string reason
        {
            get
            {
                return this.reasonField;
            }
            set
            {
                this.reasonField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string remark
        {
            get
            {
                return this.remarkField;
            }
            set
            {
                this.remarkField = value;
            }
        }

        /// <remarks/>
        [DataMember()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}
