using UnityEngine;
using System.Collections;
using System;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.UI;

namespace XMLTest3
{

	[XmlRoot("nmaprun")]
	public class ImportXML : MonoBehaviour
	{
		public Text output;
		// Define starting index for Instantiation Array
		public int startIndex;
		public InstantiateNetwork myInstantiationScript;

		string currentText;
		string newHost;
		string newPort;

		//public static void Main(string[] args)
		public void Import()
		{
			// Start by assigning a variable for a counter (how many hosts responded?)
			int counter = 0;
			// Let's set our XmlReaderSettings to allow XML from any source
			XmlReaderSettings readerSettings = new XmlReaderSettings();
			readerSettings.ProhibitDtd = false;
			//readerSettings.DtdProcessing = DtdProcessing.Parse;
			// Use the System.XML.XmlReader class to open the current.xml output from NMAP
			XmlReader reader = XmlReader.Create("./current.xml", readerSettings);
			// While we still have data to read from current.xml....
			while (reader.Read())
			{
				// Look for the Elements in the XML file that are named "host"
				if (reader.NodeType == XmlNodeType.Element && reader.Name == "host")
				{
					// If a found "host" element has attributes, that means it responded
					if (reader.NodeType== XmlNodeType.Element && reader.HasAttributes)
					{
						// Since it responded, let's update our counter + 1
						counter += 1;
						// Then we'll go to the child element of "host", called "address"
						reader.ReadToDescendant("address");
						if (reader.Name == "address")
						{
							// If "address" has attributes, we'll output the IP address, identified by "addr" attribute
							if (reader.HasAttributes)
							{
								newHost = (reader.GetAttribute("addr") + "\n");
								currentText = (output.text + "Host: " + newHost);
								output.text = currentText;
							}
							startIndex++;
							myInstantiationScript.instantiateEntity(newHost);
							// If Host has ports open, let's reiteratively list those.
							reader.ReadToFollowing("port");
							if (reader.Name == "port" && reader.HasAttributes)
							{
								string portHeader = "Ports: ";
								output.text = output.text + portHeader;
								// While we still have port elements left in this host, cycle through them all.
								while (reader.Name == "port" && reader.HasAttributes)
								{
									// Collect all the new data, concatenate to existing text, re-output to text window
									newPort = (reader.GetAttribute("portid") + ", ");
									//newPort = (" - port: " + reader.GetAttribute("portid") + "\n");
									currentText = output.text + newPort;
									output.text = currentText;
									reader.ReadToNextSibling("port");
								}
								output.text = output.text + "\n-----\n";
							}
						}
					}
				}
			}
			output.text = output.text + "END OF FILE\n";
			output.text = output.text + counter + " hosts responded during scanning.\n";
		}
	}
}


