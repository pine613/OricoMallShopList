﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OricoMallShopList
{
    static class HTMLDocumentUtility
    {
        public static List<mshtml.IHTMLElement> ToList(this mshtml.IHTMLElementCollection elements)
        {
            var results = new List<mshtml.IHTMLElement>();

            foreach (mshtml.IHTMLElement element in elements)
            {
                results.Add(element);
            }

            return results;
        }

        public static List<mshtml.IHTMLElement> getElementsByClassName(
            this mshtml.HTMLDocument document,
            string className
            )
        {
            var elements = document.getElementsByTagName("*");
            var results = new List<mshtml.IHTMLElement>();

            foreach (mshtml.IHTMLElement element in elements)
            {
                if (element.className != null)
                {
                    var classNames = element.className.Split(' ');

                    if (Array.IndexOf(classNames, className) > -1)
                    {
                        results.Add(element);
                    }
                }
            }

            return results;
        }

        public static List<mshtml.IHTMLElement> getElementsByTagName(
            this mshtml.IHTMLElement element,
            string tagName
            )
        {
            return ((mshtml.IHTMLElement2)element).getElementsByTagName(tagName).ToList();
        }

        public static void focus(this mshtml.IHTMLElement element)
        {
            ((mshtml.IHTMLElement2)element).focus();
        }

        public static bool attachEvent(
            this mshtml.IHTMLElement element, string @event, 
            DomEventHandler.Callback callback
            )
        {
            return ((mshtml.IHTMLElement2)element).attachEvent(@event, new DomEventHandler(callback));
        }
    }
}
