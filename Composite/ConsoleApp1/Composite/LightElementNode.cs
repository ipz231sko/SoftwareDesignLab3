using ConsoleApp1.Iterator;
using ConsoleApp1.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LightElementNode : LightNode
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

        private readonly Dictionary<string, List<IEventListener>> _eventListeners = new Dictionary<string, List<IEventListener>>();

        public void AddEventListener(string eventType, IEventListener listener)
        {
            if (!_eventListeners.ContainsKey(eventType))
                _eventListeners[eventType] = new List<IEventListener>();

            _eventListeners[eventType].Add(listener);
        }

        public void RemoveEventListener(string eventType, IEventListener listener)
        {
            if (_eventListeners.ContainsKey(eventType))
                _eventListeners[eventType].Remove(listener);
        }

        public void TriggerEvent(string eventType)
        {
            if (_eventListeners.ContainsKey(eventType))
            {
                foreach (var listener in _eventListeners[eventType])
                {
                    listener.HandleEvent(eventType, this);
                }
            }
        }

        public override void OnCreated()
        {
            Console.WriteLine($"[HOOK] <{TagName}> created");
        }
        public override void OnInserted()
        {
            Console.WriteLine($"[HOOK] <{TagName}> inserted into DOM");
        }
        public override void OnStylesApplied()
        {
            Console.WriteLine($"[HOOK] Styles applied to <{TagName}>");
        }
        public override void OnClassListApplied()
        {
            Console.WriteLine($"[HOOK] Class lost applied to <{TagName}>: {string.Join(", ", CssClasses)}");
        }
        public override void OnTextRendered()
        {
            Console.WriteLine($"[HOOK] Text rendered for <{TagName}>");
        }
        public override void OnRemoved()
        {
            Console.WriteLine($"[HOOK] <{TagName}> element removed from DOM");
        }
        public void RemoveChild(LightNode node)
        {
            if (Children.Contains(node))
            {
                node.OnRemoved();
                Children.Remove(node);
                Console.WriteLine($"[INFO] Child node removed from <{TagName}>");
            }
            else
            {
                Console.WriteLine($"[WARN] Attempted to remove node not in children of <{TagName}>");
            }
        }

        public ILightNodeIterator CreateDepthIterator()
        {
            return new DepthFirstIterator(this);
        }
        public ILightNodeIterator CreateBreadthIterator()
        {
            return new BreadthFirstIterator(this);
        }
    }
}
