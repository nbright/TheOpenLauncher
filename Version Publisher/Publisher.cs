using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheOpenLauncher.VersionPublisher {
    public abstract class Publisher : ISerializable{
        public abstract void PublishUpdate(Project project, UpdateInfo newUpdate);
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);

        public virtual void SetupSettingsPanel(MetroPanel panel) { }
        public virtual bool IsSettingsPanelComplete(MetroPanel panel) { return true; }
        public virtual void ApplySettingsPanel(MetroPanel panel) { }

        private static Type[] publisherTypes = null;
        public static Type[] PublisherTypes{
            get {
                if(publisherTypes == null){
                    publisherTypes = GetAllPublisherTypes().ToArray();
                }
                return publisherTypes;
            }
        }

        private static IEnumerable<Type> GetAllPublisherTypes() {
            foreach (Type type in Assembly.GetAssembly(typeof(Publisher)).GetTypes()) {
                if (type.GetCustomAttributes(typeof(PublisherInfo), true).Length > 0) {
                    yield return type;
                }
            }
        }
    }
}
