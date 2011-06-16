using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DotNetRocks.FluentSPRibbon
{
    public class Tab : RibbonElement<Tab,TabProperty>, IRibbonElementContainer<Tab,Group>
    {
        internal readonly IList<Group> _groups;
        private Scaling _scaling;

        internal Tab():this("NotSet")
        {
            
        }
        internal Tab(string id) : base(id)
        {
            _groups = new List<Group>();
        }

        public static new Tab Create(String id)
        {
            return RibbonElement<Tab>.Create(id);
        }

        public override Tab Set(TabProperty propertyName, String propertyValue)
        {
            AddOrUpdateProperty(propertyName, propertyValue);
            return this;
        }

        public override Tab Set(Dictionary<TabProperty, String> properties)
        {
            foreach (var property in properties)
            {
                AddOrUpdateProperty(property.Key, property.Value);
            }
            return this;
        }

        public Group this[string id]
        {
            get { return _groups.FirstOrDefault(g => g.OriginalId == id); }
        }

        public Scaling Scaling
        {
            get { return _scaling; }
        }

        public Tab With(Func<Group> expression )
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
            if (_groups.Count > 0)
            {
                writer.WriteStartElement("Groups");
                writer.WriteAttributeString("Id", String.Concat(Id, ".GroupsContainer"));
                _groups.ToList().ForEach(g =>
                                             {
                                                 writer.WriteStartElement("Group");
                                                 g.WriteXml(writer);
                                                 writer.WriteEndElement();
                                             });
                writer.WriteEndElement();
            }



        }
    }
}