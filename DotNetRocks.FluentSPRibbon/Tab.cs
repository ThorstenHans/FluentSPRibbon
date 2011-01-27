using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DotNetRocks.FluentSPRibbon
{
    public class Tab : InteractiveRibbonElement, IRibbonElementContainer<Tab,Group>
    {
        private readonly IList<Group> _groups;

        internal Tab():this("NotSet")
        {
            
        }
        internal Tab(string id) : base(id)
        {
            _groups = new List<Group>();
        }


        public Tab ApplyProperty(String name, String value)
        {
            SetProperty(name, value);
            return this;
        }

        public Tab ApplyProperties(Dictionary<String, String> properties)
        {
            SetProperties(properties);
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

        public Tab With(Func<Group> expression)
        {
            var group = expression.Invoke();
            group.Parent = this;
            this._groups.Add(group);
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