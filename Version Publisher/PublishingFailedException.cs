using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOpenLauncher.VersionPublisher {
    class PublishingFailedException : Exception{
        public PublishingFailedException(string message) : base(message){}
        public PublishingFailedException(string message, Exception innerException) : base(message, innerException) {}
    }
}
