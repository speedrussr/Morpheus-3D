#!/bin/sh

echo $1 > russ-temp-nmap-results.txt
/usr/local/bin/nmap $1 >> russ-temp-nmap-results.txt
