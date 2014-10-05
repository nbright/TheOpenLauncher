using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOpenLauncher.VersionPublisher {
    class PublisherInfo : Attribute {
        public PublisherInfo() {
            Description = "";
        }
        public String Name { get; set; }
        public String Description { get; set; }

        public override string ToString() {
            return Name;
        }
    }
}
