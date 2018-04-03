using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using onvif.utils;
using Onvif.Contracts.Constants;

namespace Onvif.Contracts.Model
{
    public static class EventDescriptorExtensions
    {
        public static T Match<T>(this EventDescriptor descriptor, Func<EventDescriptor.EventDescriptorData, T> data, Func<EventDescriptor.EventDescriptorEmpty, T> empty)
        {
            var descriptorData = descriptor as EventDescriptor.EventDescriptorData;
            if (descriptorData != null)
            {
                var x = descriptorData;
                return data(x);
            }
            var y = (EventDescriptor.EventDescriptorEmpty)descriptor;
            return empty(y);
        }
    }
    public abstract class EventDescriptor
    {
        private const string KeyValueFormat = "{0}: {1}";

        private EventDescriptor(){}

        public virtual bool IsStarted()
        {
            return false;
        }

        public virtual bool IsStopped()
        {
            return false;
        }

        public static EventDescriptor Create(OnvifEvent ev)
        {
            if (ev == null || ev.message == null) return new EventDescriptorEmpty();
            return new EventDescriptorData(ev);
        }

        public virtual bool IsEmpty()
        {
            return true;
        }

        public sealed class EventDescriptorEmpty : EventDescriptor
        {
            public override bool IsEmpty()
            {
                return true;
            }
        }

        public sealed class EventDescriptorData : EventDescriptor
        {

            public EventDescriptorData(OnvifEvent ev)
            {
                _onvifEvent = ev;
            }

            private readonly OnvifEvent _onvifEvent;

            public string PropertyOperation
            {
                get
                {
                    string val = string.Empty;
                    if (IsEmpty()) return val;

                    return _onvifEvent.message.propertyOperation.ToString();
                }
            }

            public string ArrivalTime
            {
                get
                {
                    string val = string.Empty;
                    if (IsEmpty()) return val;
                    try
                    {
                        val = _onvifEvent.message.utcTime.ToLongTimeString();
                    }
                    catch
                    {
                        // ignored
                    }

                    return val;
                }
            }

            public string Key
            {
                get
                {
                    if (IsEmpty() || _onvifEvent.message.key == null) return string.Empty;

                    StringBuilder sb = new StringBuilder();

                    var key = _onvifEvent.message.key;
                    if (key.simpleItem != null)
                    {
                        foreach (var item in key.simpleItem) sb.AppendLine(string.Format(KeyValueFormat, item.name, item.value));
                    }

                    return sb.ToString().Trim();
                }
            }

            public string Time
            {
                get
                {
                    if (Key.Contains(Constant.Time+":"))
                    {
                        return Key.Substring(6);
                    }
                    return string.Empty;
                }
            }

            public string Topic
            {
                get
                {
                    string val = string.Empty;
                    if (_onvifEvent == null) return val;
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        int c = 0;
                        Array.ForEach(
                            _onvifEvent.topic.Any,
                            x =>
                            {
                                if (c != 0) sb.AppendLine();
                                sb.Append(x.Value);
                                c++;
                            });
                        Array.ForEach(
                            _onvifEvent.topic.AnyAttr,
                            x =>
                            {
                                if (c != 0) sb.AppendLine();
                                sb.Append(x.Value);
                                c++;
                            });

                        val = sb.ToString();
                    }
                    catch
                    {
                        // ignored
                    }

                    return val;
                }
            }

            public string Details
            {
                get
                {
                    string val = string.Empty;
                    if (_onvifEvent == null) return val;
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        int c = 0;
                        if (_onvifEvent.message.extension != null)
                        {
                            Array.ForEach(
                                _onvifEvent.message.extension.any,
                                x =>
                                {
                                    if (c != 0) sb.AppendLine();
                                    sb.Append(string.Format(KeyValueFormat, x.Name, x.Value));
                                    c++;
                                });
                        }

                        val = sb.ToString();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    return val;
                }
            }

            public string Source
            {
                get
                {
                    if (IsEmpty() || _onvifEvent.message.data == null) return string.Empty;

                    StringBuilder sb = new StringBuilder();

                    var source = _onvifEvent.message.source;
                    if (source.simpleItem != null)
                    {
                        foreach (var item in source.simpleItem) sb.AppendLine(string.Format(KeyValueFormat, item.name, item.value));
                    }

                    return sb.ToString().Trim();
                }
            }

            public string Data
            {
                get
                {
                    if (IsEmpty() || _onvifEvent.message.data == null) return string.Empty;

                    StringBuilder sb = new StringBuilder();

                    var data = _onvifEvent.message.data;
                    if (data.simpleItem != null)
                    {
                        foreach (var item in data.simpleItem) sb.AppendLine(string.Format(KeyValueFormat, item.name, item.value));
                    }

                    return sb.ToString().Trim();
                }
            }

            public override bool IsStarted()
            {
                if (IsEmpty() || _onvifEvent.message.data == null) return false;
                return Data.EndsWith("true") || Data.EndsWith("1");
            }

            public override bool IsStopped()
            {
                if (IsEmpty() || _onvifEvent.message.data == null) return false;
                return Data.EndsWith("false") || Data.EndsWith("0");
            }

            public override bool IsEmpty()
            {
                return _onvifEvent == null || _onvifEvent.message == null;
            }

            public override string ToString()
            {
                var log = Topic + Environment.NewLine + Key + Environment.NewLine + PropertyOperation + Environment.NewLine
                      + Data + Environment.NewLine + Details + Environment.NewLine + Environment.NewLine;
                return log;
            }

            private static readonly object Gate = new object();

            private static XslCompiledTransform _sXml2Html;

            private static XslCompiledTransform Xml2Html
            {
                get
                {
                    lock (Gate)
                    {
                        if (_sXml2Html == null)
                        {
                            var xslt = new XslCompiledTransform();

                            var xmlReaderSettings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse };
                            XsltSettings xsltSettings = new XsltSettings
                            {
                                EnableScript = false,
                                EnableDocumentFunction = false
                            };

                            using (var xmlReader = XmlReader.Create(@"xml2html/XmlToHtml10Basic.xslt", xmlReaderSettings))
                            {
                                xslt.Load(xmlReader, xsltSettings, new XmlUrlResolver());
                                xmlReader.Close();
                            }
                            _sXml2Html = xslt;
                        }
                    }
                    return _sXml2Html;
                }
            }

            private string ConvertToString(string doc)
            {
                try
                {
                    var html = new StringBuilder();
                    var writer = new StringWriter(html);

                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(doc);

                    Xml2Html.Transform(xdoc, null, writer);
                    return html.ToString();
                }
                catch (Exception err)
                {
                    return err.Message;
                }
            }
        }
    }
}
