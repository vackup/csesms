/* JEsMS (Romeo) -  A Java soccer management game
* Copyright (C) 2004  Angelo Scotto (scotto_a@hotmail.com)
* 
* This program is free software; you can redistribute it and/or
* modify it under the terms of the GNU General Public License
* as published by the Free Software Foundation; either version 2
* of the License, or (at your option) any later version.
* 
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License
* along with this program; if not, write to the Free Software
* Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/

/*
* XmlFileMerger.java
*
* Created on 23 agosto 2004, 21.18
*/
using System;

namespace CSEsMS.Engine
{
    /// <summary> This helper class simply merges xml files. It is totally useless now that
    /// DOM support is present in Java runtime anyway, until other classes are updated
    /// to use DOM instead of SAX it comes handy.
    /// OBSOLETE WHEN USING DOM.
    /// </summary>
    /// <author>   Angelo Scotto
    /// </author>
    public class XmlFileMerger
    {
		
        private System.Xml.XmlDocument oldFile;
        private System.Xml.XmlDocument newFile;
        private string fileName;
		
        public XmlFileMerger(System.IO.FileInfo oldFile, System.IO.FileInfo newFile, string[] ignoreKeyWords)
        {
            throw new NotImplementedException("Error en Engine.XmlFileMerger.XmlFileMerger(System.IO.FileInfo oldFile, System.IO.FileInfo newFile, string[] ignoreKeyWords) - HZ: dada un error de algo XML pero como el XML no se usa mas, habria que reemplazarlo por el DAL, ver logica.");
            
            //try
            //{
            //    //UPGRADE_TODO: Class 'javax.xml.parsers.DocumentBuilder' was converted to 'System.Xml.XmlDocument' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmlparsersDocumentBuilder'"
            //    //UPGRADE_ISSUE: Method 'javax.xml.parsers.DocumentBuilderFactory.newInstance' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersDocumentBuilderFactory'"
            //    DocumentBuilderFactory.newInstance();
            //    System.Xml.XmlDocument builder = new System.Xml.XmlDocument();
            //    System.Xml.XmlDocument tempDocument;
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.DocumentBuilder.parse' was converted to 'System.Xml.XmlDocument.Load' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmlparsersDocumentBuilderparse_javaioFile'"
            //    tempDocument = (System.Xml.XmlDocument) builder.Clone();
            //    tempDocument.Load(oldFile.OpenRead());
            //    this.oldFile = tempDocument;
            //    System.Xml.XmlDocument tempDocument2;
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.DocumentBuilder.parse' was converted to 'System.Xml.XmlDocument.Load' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmlparsersDocumentBuilderparse_javaioFile'"
            //    tempDocument2 = (System.Xml.XmlDocument) builder.Clone();
            //    tempDocument2.Load(newFile.OpenRead());
            //    this.newFile = tempDocument2;
            //    this.fileName = oldFile.FullName;
            //    this.ignoreList = new System.Collections.ArrayList();
            //    //UPGRADE_TODO: Method 'java.util.Arrays.asList' was converted to 'System.Collections.ArrayList' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilArraysasList_javalangObject[]'"
            //    this.ignoreList.AddRange(new System.Collections.ArrayList(ignoreKeyWords));
            //}
            //catch (System.Exception err)
            //{
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }
		
        private System.Collections.ArrayList ignoreList = new System.Collections.ArrayList();
		
        public XmlFileMerger(System.IO.FileInfo oldFile, System.IO.FileInfo newFile)
        {
            throw new NotImplementedException("Error en Engine.XmlFileMerger.XmlFileMerger(System.IO.FileInfo oldFile, System.IO.FileInfo newFile) - HZ: dada un error de algo XML pero como el XML no se usa mas, habria que reemplazarlo por el DAL, ver logica.");
            
            //try
            //{
            //    //UPGRADE_TODO: Class 'javax.xml.parsers.DocumentBuilder' was converted to 'System.Xml.XmlDocument' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmlparsersDocumentBuilder'"
            //    //UPGRADE_ISSUE: Method 'javax.xml.parsers.DocumentBuilderFactory.newInstance' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmlparsersDocumentBuilderFactory'"
            //    DocumentBuilderFactory.newInstance();
            //    System.Xml.XmlDocument builder = new System.Xml.XmlDocument();
            //    System.Xml.XmlDocument tempDocument;
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.DocumentBuilder.parse' was converted to 'System.Xml.XmlDocument.Load' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmlparsersDocumentBuilderparse_javaioFile'"
            //    tempDocument = (System.Xml.XmlDocument) builder.Clone();
            //    tempDocument.Load(oldFile.OpenRead());
            //    this.oldFile = tempDocument;
            //    System.Xml.XmlDocument tempDocument2;
            //    //UPGRADE_TODO: Method 'javax.xml.parsers.DocumentBuilder.parse' was converted to 'System.Xml.XmlDocument.Load' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmlparsersDocumentBuilderparse_javaioFile'"
            //    tempDocument2 = (System.Xml.XmlDocument) builder.Clone();
            //    tempDocument2.Load(newFile.OpenRead());
            //    this.newFile = tempDocument2;
            //    this.fileName = oldFile.FullName;
            //}
            //catch (System.Exception err)
            //{
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }
		
        public virtual void  start()
        {
            parseElement((System.Xml.XmlElement) oldFile.DocumentElement, (System.Xml.XmlElement) newFile.DocumentElement);
        }
		
        public virtual void  parseElement(System.Xml.XmlNode oldEl, System.Xml.XmlNode newEl)
        {
            System.Xml.XmlNamedNodeMap nl = (System.Xml.XmlAttributeCollection) oldEl.Attributes;
			
            if (nl != null)
            {
                for (int i = 0; i < nl.Count; i++)
                {
                    if (((System.Xml.XmlAttributeCollection) newEl.Attributes).GetNamedItem(nl.Item(i).Name) == null)
                    {
                        //System.out.println(nl.item(i).getNodeName()+" attribute not present, adding the attribute");
                        //UPGRADE_TODO: Method 'org.w3c.dom.Element.setAttribute' was converted to 'System.Xml.XmlElement.SetAttribute' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_orgw3cdomElementsetAttribute_javalangString_javalangString'"
                        ((System.Xml.XmlElement) newEl).SetAttribute(nl.Item(i).Name, nl.Item(i).Value);
                    }
                }
            }
            //UPGRADE_TODO: Method 'org.w3c.dom.Node.getChildNodes' was converted to 'System.Xml.XmlNode.ChildNodes' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            System.Xml.XmlNodeList oldNodes = oldEl.ChildNodes;
            //UPGRADE_TODO: Method 'org.w3c.dom.Node.getChildNodes' was converted to 'System.Xml.XmlNode.ChildNodes' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073'"
            System.Xml.XmlNodeList newNodes = newEl.ChildNodes;
			
            int i2 = 0;
            int j = 0;
            while (oldNodes.Item(i2) != null)
            {
                if (newNodes.Item(j) == null)
                {
                    //System.out.println(oldNodes.item(i)+" not present, adding the whole element");
                    if (!ignoreList.Contains(oldNodes.Item(i2).Name))
                    {
                        System.Xml.XmlNode n = newEl.OwnerDocument.ImportNode(oldNodes.Item(i2), true);
                        newEl.AppendChild(n);
                    }
                    i2++; j++;
                }
                else
                {
                    if ((System.Object) oldNodes.Item(i2).Name != (System.Object) newNodes.Item(j).Name)
                    {
                        if (!ignoreList.Contains(oldNodes.Item(i2).Name))
                        {
                            //System.out.println(oldNodes.item(i)+" not present, adding the whole element");
                            System.Xml.XmlNode n = newEl.OwnerDocument.ImportNode(oldNodes.Item(i2), true);
                            newEl.AppendChild(n);
                        }
                        i2++;
                    }
                    else
                    {
                        parseElement(oldNodes.Item(i2), newNodes.Item(j));
                        i2++; j++;
                    }
                }
            }
        }
		
        public virtual void  save()
        {
            throw new NotImplementedException("Error en Engine.XmlFileMerger.save() . HZ: dada un error de algo XML pero como el XML no se usa mas, habria que reemplazarlo por el DAL, ver logica.");

            //try
            //{
            //    //UPGRADE_TODO: Class 'javax.xml.transform.dom.DOMSource' was converted to 'DomSourceSupport' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmltransformdomDOMSource'"
            //    DomSourceSupport s = new DomSourceSupport(newFile);
            //    System.IO.FileInfo f = new System.IO.FileInfo(fileName);
            //    GenericResultSupport out_Renamed = new GenericResultSupport(f);
            //    //UPGRADE_TODO: Method 'javax.xml.transform.TransformerFactory.newTransformer' was converted to 'SupportClass.TransformerSupport.NewTransform' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaxxmltransformTransformerFactorynewTransformer'"
            //    TransformerSupport serializer = TransformerSupport.NewTransform(TransformerSupport.NewInstance());
            //    //UPGRADE_ISSUE: Method 'javax.xml.transform.Transformer.setOutputProperty' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmltransformTransformersetOutputProperty_javalangString_javalangString'"
            //    //UPGRADE_ISSUE: Field 'javax.xml.transform.OutputKeys.ENCODING' was not converted. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1000_javaxxmltransformOutputKeys'"
            //    serializer.setOutputProperty(OutputKeys.ENCODING, "ISO-8859-1");
            //    serializer.DoTransform(s, out_Renamed);
            //}
            //catch (System.Exception err)
            //{
            //    SupportClass.WriteStackTrace(err, Console.Error);
            //}
        }
		
        //[STAThread]
        //public static void  Main(string[] args)
        //{
        //    XmlFileMerger merger = new XmlFileMerger(new System.IO.FileInfo("c:\\programmazione\\workspaces\\jesms\\ManagerGui\\Teams\\dot2.xml"), new System.IO.FileInfo("c:\\programmazione\\workspaces\\jesms\\ManagerGui\\Teams\\dot.xml"));
        //    merger.start();
        //    merger.save();
        //    System.Console.Out.WriteLine("Ended.");
        //}
    }
}