using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DotNetRocks.FluentSPRibbon
{
    public class Tab : InteractiveRibbonElement, IRibbonElementContainer<Tab,Group>
    {
        private readonly IList<Group> _groups;
        private Scaling _scaling;

        internal Tab():this("NotSet")
        {
            
        }
        internal Tab(string id) : base(id)
        {
            _groups = new List<Group>();
        }

        public String GetProperty(TabProperty propertyKey)
        {
            return GetPropertyValue(propertyKey.ToString());
        }

        public Tab SetProperty(TabProperty propertyKey, String value)
        {
            AddOrUpdateProperty(propertyKey.ToString(), value);
            return this;
        }

        public Tab SetProperties(Dictionary<TabProperty, String> properties)
        {
            AddOrUpdateProperties(properties.ToDictionary(e=>e.Key.ToString(), e=>e.Value));
            return this;
        }

        public Group this[int index]
        {
            get
            {
                if (_groups.Count >= index)
                    return _groups[index];
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
        }

        public Group this[string id]
        {
            get { return _groups.FirstOrDefault(g => g.OriginalId == id); }
        }

        public int ChildItemCount
        {
            get { return _groups.Count; }
        }

        public Scaling Scaling
        {
            get { return _scaling; }
        }

        public Tab With(Func<Group> expression)
        {
            var group = expression.Invoke();
            group.Parent = this;
            this._groups.Add(group);
            return this;
        }

        public Tab With(Func<Scaling> expression)
        {
            var scaling = expression.Invoke();
            scaling.Parent = this;
            this._scaling = scaling;
            return this;
        }

        protected override void WriteChildren(XmlWriter writer)
        {
            writer.WriteStartElement("Groups");
            writer.WriteAttributeString("Id",String.Concat(Id, ".GroupsContainer"));
            _groups.ToList().ForEach(g=>
                                         {
                                             writer.WriteStartElement("Group");
                                             g.WriteXml(writer);
                                             writer.WriteEndElement();
                                         });
            writer.WriteEndElement();
            
        }
    }
}