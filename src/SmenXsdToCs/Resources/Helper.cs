using System;

namespace CIM
{
    public static class Helper
    {
        public static bool IsRequestOk<TRequest, TPayload>(this IGetRequestMessageType<TRequest, TPayload> requestType, bool requireID, bool requireOption, bool requireStartTime, bool requireEndTime)
            where TRequest : GetRequestType
        {
            if (requestType == null)
                throw new Exception("Empty request object!");

            if (requestType.Request == null)
                throw new Exception("Empty request request!");

            if (requireID)
            {
                if (requestType.Request.ID == null)
                    throw new Exception("No identifiers in request!");

                if (requestType.Request.ID.Length == 0)
                    throw new Exception("No identifiers in request (empty array)!"); 
            }

            if (requireOption)
            {
                if (requestType.Request.Option == null)
                    throw new Exception("No options in request!");

                if (requestType.Request.Option.Length == 0)
                    throw new Exception("No options in request (empty array)!");
            }

            if (requireStartTime)
            {
                if (requestType.Request.StartTime == null)
                    throw new Exception("StartTime not specified!");

                //if (requestType.Request.StartTimeSpecified == false)
                //    throw new Exception("StartTime not specified!"); 
            }

            if (requireEndTime)
            {
                if (requestType.Request.EndTime == null)
                    throw new Exception("EndTime not specified!");

                //if (requestType.Request.EndTimeSpecified == false)
                //    throw new Exception("EndTime not specified!"); 
            }

            if (requireStartTime && requireEndTime)
            {
                if (requestType.Request.StartTime > requestType.Request.EndTime)
                    throw new Exception("EndTime must be greater or equal than StartTime!"); 
            }

            return true;
        }
        public static bool IsRequestOk<TPayload>(this IRequestMessageType<TPayload> requestType, bool requireID, bool requireOption, bool requireStartTime, bool requireEndTime)
        {
            if (requestType == null)
                throw new Exception("Empty request object!");

            if (requestType.Request == null)
                throw new Exception("Empty request request!");

            if (requireID)
            {
                if (requestType.Request.ID == null)
                    throw new Exception("No identifiers in request!");

                if (requestType.Request.ID.Length == 0)
                    throw new Exception("No identifiers in request (empty array)!");
            }

            if (requireOption)
            {
                if (requestType.Request.Option == null)
                    throw new Exception("No options in request!");

                if (requestType.Request.Option.Length == 0)
                    throw new Exception("No options in request (empty array)!");
            }

            if (requireStartTime)
            {
                if (requestType.Request.StartTime == null)
                    throw new Exception("StartTime not specified!");

                //if (requestType.Request.StartTimeSpecified == false)
                //    throw new Exception("StartTime not specified!"); 
            }

            if (requireEndTime)
            {
                if (requestType.Request.EndTime == null)
                    throw new Exception("EndTime not specified!");

                //if (requestType.Request.EndTimeSpecified == false)
                //    throw new Exception("EndTime not specified!"); 
            }

            if (requireStartTime && requireEndTime)
            {
                if (requestType.Request.StartTime > requestType.Request.EndTime)
                    throw new Exception("EndTime must be greater or equal than StartTime!");
            }

            return true;
        }
        public static bool IsHeaderOk<TRequest, TPayload>(this IGetRequestMessageType<TRequest, TPayload> requestType, bool requireCorrelationID, bool requireMessageID, bool requireAsync)
            where TRequest : GetRequestType
        {
            if (requestType == null)
                throw new Exception("Empty request object!");

            if (requestType.Header == null)
                throw new Exception("Empty request header!");

            if (requireCorrelationID)
            {
                if (requestType.Header.CorrelationID == null)
                    throw new Exception("No CorrelationID in request!");

                if (requestType.Header.CorrelationID == "")
                    throw new Exception("No CorrelationID in request!"); 
            }

            if (requireMessageID)
            {
                if (requestType.Header.MessageID == null)
                    throw new Exception("No MessageID in request!");

                if (requestType.Header.MessageID == "")
                    throw new Exception("No MessageID in request!"); 
            }

            if (requireAsync && requestType.Header.AsyncReplyFlag)
            {
                if (requestType.Header.ReplyAddress == null)
                    throw new Exception("No ReplyAddress in request!");

                if (requestType.Header.ReplyAddress == "")
                    throw new Exception("No ReplyAddress in request!");
            }

            return true;
        }
        public static bool IsHeaderOk<TPayload>(this IRequestMessageType<TPayload> requestType, bool requireCorrelationID, bool requireMessageID, bool requireAsync)
        {
            if (requestType == null)
                throw new Exception("Empty request object!");

            if (requestType.Header == null)
                throw new Exception("Empty request header!");

            if (requireCorrelationID)
            {
                if (requestType.Header.CorrelationID == null)
                    throw new Exception("No CorrelationID in request!");

                if (requestType.Header.CorrelationID == "")
                    throw new Exception("No CorrelationID in request!");
            }

            if (requireMessageID)
            {
                if (requestType.Header.MessageID == null)
                    throw new Exception("No MessageID in request!");

                if (requestType.Header.MessageID == "")
                    throw new Exception("No MessageID in request!");
            }

            if (requireAsync && requestType.Header.AsyncReplyFlag)
            {
                if (requestType.Header.ReplyAddress == null)
                    throw new Exception("No ReplyAddress in request!");

                if (requestType.Header.ReplyAddress == "")
                    throw new Exception("No ReplyAddress in request!");
            }

            return true;
        }
        public static bool IsHeaderOk<TPayload>(this IEventMessageType<TPayload> requestType, bool requireCorrelationID, bool requireMessageID)
        {
            if (requestType == null)
                throw new Exception("Empty request object!");

            if (requestType.Header == null)
                throw new Exception("Empty request header!");

            if (requireCorrelationID)
            {
                if (requestType.Header.CorrelationID == null)
                    throw new Exception("No CorrelationID in request!");

                if (requestType.Header.CorrelationID == "")
                    throw new Exception("No CorrelationID in request!");
            }

            if (requireMessageID)
            {
                if (requestType.Header.MessageID == null)
                    throw new Exception("No MessageID in request!");

                if (requestType.Header.MessageID == "")
                    throw new Exception("No MessageID in request!");
            }

            return true;
        }

    }
}
