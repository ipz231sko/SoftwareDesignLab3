using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LightElementNode : LightNode
    {
        public string TagName { get; }
        public DisplayType Display { get; }
        public TagType TagType { get; }
        public List<string> CssClasses { get; } = new List<string>();
        public List<LightNode> Children { get; } = new List<LightNode>();

        public LightElementNode(string tagName, DisplayType display, TagType tagType)
        {
            TagName = tagName;
            Display = display;
            TagType = tagType;
        }

        public void AddClass(string className)
        {
            CssClasses.Add(className);
        }

        public LightElementNode AddChild(LightNode node)
        {
            if (TagType == TagType.Single)
                throw new InvalidOperationException("Cannot add children to single (self-closing) tags.");
            Children.Add(node);
            return this;
        }

        public override string OuterHTML
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine($"<{TagName}{(CssClasses.Count > 0 ? " class=\"" + string.Join(" ", CssClasses) + "\"" : "")}{(TagType == TagType.Single ? " />" : ">")}");

                if (TagType == TagType.Paired)
                {
                    foreach (var child in Children)
                    {
                        sb.AppendLine(child.OuterHTML);
                    }
                    sb.AppendLine($"</{TagName}>");
                }

                return sb.ToString();
            }
        }

        public override string InnerHTML
        {
            get
            {
                if (TagType == TagType.Single)
                    return string.Empty;

                var sb = new StringBuilder();
                foreach (var child in Children)
                {
                    sb.Append(child.OuterHTML);
                }
                return sb.ToString();
            }
        }
    }
}
