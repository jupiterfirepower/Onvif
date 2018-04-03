using Onvif.Contracts.Enums;

namespace Onvif.Contracts.Messages
{
    public class OnvifNotificationEmailMessage
    {
        public string CameraId { get; private set; }

        public string CameraUrl { get; private set; }

        public string EmailAddressTo { get; private set; }

        public string FullName { get; private set; }

        public EmailTarget Target { get; private set; }

        public string Subject { get; private set; }

        public string Message { get; private set; }

        public OnvifNotificationEmailMessage(string cameraId, string cameraUrl, string to, string fullName, EmailTarget target = EmailTarget.Mandrill)
        {
            CameraId = cameraId;
            CameraUrl = cameraUrl;
            EmailAddressTo = to;
            FullName = fullName;
            Target = target;
        }

        public OnvifNotificationEmailMessage(string subject, string message, EmailTarget target = EmailTarget.Mandrill)
        {
            Subject = subject;
            Message = message;
            Target  = target;
        }
    }
}
