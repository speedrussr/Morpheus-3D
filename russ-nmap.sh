#!/bin/sh

now=`date +%m%d%Y%H%M`
/usr/local/bin/nmap $1 -oX ./russ-nmap-results-$now.xml;cp ./russ-nmap-results-$now.xml current.xml
