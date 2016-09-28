# Morpheus-3D

Current Morpheus controls:

Forward = W or up arrow
Backward = S or down arrow
Left Turn = A or left arrow
Right Turn = D or right arrow
Jump = Space Bar
Run = Left Shift + Forward

Terminal Controls:

Open / Close Terminal = ~

INPUT and OUTPUT Interactions:

There are two methods of input, and 1 method of output. The Terminal window 
is at the top of the canvas when you press ~. This is the ONLY output window
for Morpheus functions, within the application.

(METHOD 1)
There is an input bar at the bottom of the Terminal. This is used for CUSTOM
user scripts, only. In this case, your version comes with a russ-nmap.sh, that
should be installed in the same directory as the application. You can enter
an IP range in the Input Bar, that gets sent to the back end script.
(i.e. 192.168.1.1/24).  Input ends when you press the <ENTER> key. You can
check on the progress of the scan, by watching the files in the application 
directory. When the script is complete, the results are copied to current.xml.

Once you have a current.xml, you can click the LOAD button, to display the
results in the output window. You can also click on the MAP button, which
creates physical game objects for each of the network devices found.

(METHOD 2)
There is another window on the canvas, that includes pre-programmed, built-in
network functions. These are written in C#, and included as part of the 
default Morpheus. Currently we have Ping, NSlookup, WHOIS, and Portscan. Ping
and Portscan use only IP address.  NSlookup and WHOIS use domain names. As with
the previous Input field, these fields all begin operation when the user
presses the <ENTER> key.

Output for built-in functions is displayed in the Terminal Output window.
