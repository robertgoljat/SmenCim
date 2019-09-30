namespace CIM.Extra.GetMeterReadSchedule {
    using System.Runtime.Serialization;
    using System;
    using System.ServiceModel;
    
    
    /// <remarks/>
    [DataContract()]
    public class GetMeterReadScheduleRequestMessageType : IGetRequestMessageType<GetMeterReadScheduleRequestType, MeterReadSchedulePayloadType> {
        
        private HeaderType headerField;
        
        private GetMeterReadScheduleRequestType requestField;
        
        private MeterReadSchedulePayloadType payloadField;
        
        /// <remarks/>
        [DataMember()]
        public HeaderType Header {
            get {
                return this.headerField;
            }
            set {
                this.headerField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public GetMeterReadScheduleRequestType Request {
            get {
                return this.requestField;
            }
            set {
                this.requestField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public MeterReadSchedulePayloadType Payload {
            get {
                return this.payloadField;
            }
            set {
                this.payloadField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class UsagePointGroup {
        
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
    
    /// <remarks/>
    [DataContract()]
    public class UsagePoint {
        
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
    public class TimePoint {
        
        private System.DateTime dateTimeField;
        
        private bool dateTimeFieldSpecified;
        
        private float relativeTimeIntervalField;
        
        private bool relativeTimeIntervalFieldSpecified;
        
        private string sequenceNumberField;
        
        private DateTimeInterval windowField;
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime dateTime {
            get {
                return this.dateTimeField;
            }
            set {
                this.dateTimeField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool dateTimeSpecified {
            get {
                return this.dateTimeFieldSpecified;
            }
            set {
                this.dateTimeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public float relativeTimeInterval {
            get {
                return this.relativeTimeIntervalField;
            }
            set {
                this.relativeTimeIntervalField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool relativeTimeIntervalSpecified {
            get {
                return this.relativeTimeIntervalFieldSpecified;
            }
            set {
                this.relativeTimeIntervalFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string sequenceNumber {
            get {
                return this.sequenceNumberField;
            }
            set {
                this.sequenceNumberField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public DateTimeInterval window {
            get {
                return this.windowField;
            }
            set {
                this.windowField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class DateTimeInterval {
        
        private System.DateTime endField;
        
        private bool endFieldSpecified;
        
        private System.DateTime startField;
        
        private bool startFieldSpecified;
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime end {
            get {
                return this.endField;
            }
            set {
                this.endField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool endSpecified {
            get {
                return this.endFieldSpecified;
            }
            set {
                this.endFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public System.DateTime start {
            get {
                return this.startField;
            }
            set {
                this.startField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool startSpecified {
            get {
                return this.startFieldSpecified;
            }
            set {
                this.startFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class TimeSchedule {
        
        private bool disabledField;
        
        private bool disabledFieldSpecified;
        
        private float offsetField;
        
        private bool offsetFieldSpecified;
        
        private string recurrencePatternField;
        
        private float recurrencePeriodField;
        
        private bool recurrencePeriodFieldSpecified;
        
        private DateTimeInterval scheduleIntervalField;
        
        private TimePoint[] timePointsField;
        
        /// <remarks/>
        [DataMember()]
        public bool disabled {
            get {
                return this.disabledField;
            }
            set {
                this.disabledField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool disabledSpecified {
            get {
                return this.disabledFieldSpecified;
            }
            set {
                this.disabledFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public float offset {
            get {
                return this.offsetField;
            }
            set {
                this.offsetField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool offsetSpecified {
            get {
                return this.offsetFieldSpecified;
            }
            set {
                this.offsetFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public string recurrencePattern {
            get {
                return this.recurrencePatternField;
            }
            set {
                this.recurrencePatternField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public float recurrencePeriod {
            get {
                return this.recurrencePeriodField;
            }
            set {
                this.recurrencePeriodField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public bool recurrencePeriodSpecified {
            get {
                return this.recurrencePeriodFieldSpecified;
            }
            set {
                this.recurrencePeriodFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public DateTimeInterval scheduleInterval {
            get {
                return this.scheduleIntervalField;
            }
            set {
                this.scheduleIntervalField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public TimePoint[] TimePoints {
            get {
                return this.timePointsField;
            }
            set {
                this.timePointsField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class ReadingType {
        
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
    public class EndDeviceGroup {
        
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
    public class EndDevice {
        
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
    public class CustomerAgreement {
        
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
    public class CustomerAccount {
        
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
    public class MeterReadSchedule {
        
        private CustomerAccount[] customerAccountField;
        
        private CustomerAgreement[] customerAgreementField;
        
        private EndDevice[] endDeviceField;
        
        private EndDeviceGroup[] endDeviceGroupField;
        
        private ReadingType[] readingTypeField;
        
        private TimeSchedule[] timeScheduleField;
        
        private UsagePoint[] usagePointField;
        
        private UsagePointGroup[] usagePointGroupField;
        
        /// <remarks/>
        [DataMember()]
        public CustomerAccount[] CustomerAccount {
            get {
                return this.customerAccountField;
            }
            set {
                this.customerAccountField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public CustomerAgreement[] CustomerAgreement {
            get {
                return this.customerAgreementField;
            }
            set {
                this.customerAgreementField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public EndDevice[] EndDevice {
            get {
                return this.endDeviceField;
            }
            set {
                this.endDeviceField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public EndDeviceGroup[] EndDeviceGroup {
            get {
                return this.endDeviceGroupField;
            }
            set {
                this.endDeviceGroupField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public ReadingType[] ReadingType {
            get {
                return this.readingTypeField;
            }
            set {
                this.readingTypeField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public TimeSchedule[] TimeSchedule {
            get {
                return this.timeScheduleField;
            }
            set {
                this.timeScheduleField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public UsagePoint[] UsagePoint {
            get {
                return this.usagePointField;
            }
            set {
                this.usagePointField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public UsagePointGroup[] UsagePointGroup {
            get {
                return this.usagePointGroupField;
            }
            set {
                this.usagePointGroupField = value;
            }
        }
    }
    
    /// <remarks/>
    [DataContract()]
    public class MeterReadSchedulePayloadType : IPayloadType<MeterReadSchedule> {
        
        private MeterReadSchedule meterReadScheduleField;
        
        private OperationSet operationSetField;
        
        private string compressedField;
        
        private string formatField;
        
        /// <remarks/>
        [DataMember()]
        public MeterReadSchedule MeterReadSchedule {
            get {
                return this.meterReadScheduleField;
            }
            set {
                this.meterReadScheduleField = value;
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
    
    /// <remarks/>
    [DataContract()]
    public class MeterReadScheduleResponseMessageType : IResponseMessageType<MeterReadSchedulePayloadType> {
        
        private HeaderType headerField;
        
        private ReplyType replyField;
        
        private MeterReadSchedulePayloadType payloadField;
        
        /// <remarks/>
        [DataMember()]
        public HeaderType Header {
            get {
                return this.headerField;
            }
            set {
                this.headerField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public ReplyType Reply {
            get {
                return this.replyField;
            }
            set {
                this.replyField = value;
            }
        }
        
        /// <remarks/>
        [DataMember()]
        public MeterReadSchedulePayloadType Payload {
            get {
                return this.payloadField;
            }
            set {
                this.payloadField = value;
            }
        }
    }
    
    public class GetMeterReadScheduleRequestType : GetRequestType {
    }
    
    public class MeterReadScheduleFaultMessageType : FaultMessageType {
    }
    
    [DataContract()]
    public class GetMeterReadScheduleRequest {
        
        private GetMeterReadScheduleRequestMessageType getMeterReadScheduleRequestMessage;
        
        [DataMember()]
        public GetMeterReadScheduleRequestMessageType GetMeterReadScheduleRequestMessage {
            get {
                return this.getMeterReadScheduleRequestMessage;
            }
            set {
                this.getMeterReadScheduleRequestMessage = value;
            }
        }
    }
    
    [DataContract()]
    public class GetMeterReadScheduleResponse {
        
        private MeterReadScheduleResponseMessageType meterReadScheduleResponseMessage;
        
        [DataMember()]
        public MeterReadScheduleResponseMessageType MeterReadScheduleResponseMessage {
            get {
                return this.meterReadScheduleResponseMessage;
            }
            set {
                this.meterReadScheduleResponseMessage = value;
            }
        }
    }
    
    [ServiceContract()]
    public interface IGetMeterReadScheduleService {
        
        [OperationContract()]
        GetMeterReadScheduleResponse GetMeterReadSchedule(GetMeterReadScheduleRequest request);
    }
    
    public class GetMeterReadScheduleService : IGetMeterReadScheduleService {
        
        private Func<GetMeterReadScheduleRequest, GetMeterReadScheduleResponse> getHandler;
        
        public Func<GetMeterReadScheduleRequest, GetMeterReadScheduleResponse> GetHandler {
            get {
                return this.getHandler;
            }
            set {
                this.getHandler = value;
            }
        }
        
        public GetMeterReadScheduleResponse GetMeterReadSchedule(GetMeterReadScheduleRequest request) {
            try {
                request.GetMeterReadScheduleRequestMessage.IsHeaderOk(false, false, false);
                request.GetMeterReadScheduleRequestMessage.IsRequestOk(true, true, true, true);

                return this.GetHandler(request);
            }
            catch (System.Exception e1) {

                return new GetMeterReadScheduleResponse()
                {
                    MeterReadScheduleResponseMessage = new MeterReadScheduleResponseMessageType()
                    {
                        Header = new HeaderType()
                        {
                            Verb = request.GetMeterReadScheduleRequestMessage.Header.Verb,
                            Noun = request.GetMeterReadScheduleRequestMessage.Header.Noun
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
}
